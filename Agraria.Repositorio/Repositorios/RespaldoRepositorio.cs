using System;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;

namespace Agraria.Repositorio.Repositorios
{
	[SupportedOSPlatform("windows")]
	public class RespaldoRepositorio : BaseRepositorio, IRespaldoRepositorio
	{
		/// <summary>
		/// Crea un respaldo completo de la base de datos de forma síncrona
		/// </summary>
		/// <param name="rutaDestino">Ruta completa donde se guardará el archivo .bak</param>
		/// <returns>true si el respaldo fue exitoso, false en caso contrario</returns>
		public bool CrearRespaldo(string rutaDestino)
		{
			SqlConnection conexion = null;
			try
			{
				// Log inicial
				System.Diagnostics.Debug.WriteLine($"=== INICIANDO RESPALDO ===");
				System.Diagnostics.Debug.WriteLine($"Ruta destino original: {rutaDestino}");

				// Validar que la ruta de destino sea válida
				string directorio = Path.GetDirectoryName(rutaDestino);
				System.Diagnostics.Debug.WriteLine($"Directorio: {directorio}");

				if (string.IsNullOrEmpty(directorio))
				{
					throw new Exception("La ruta del directorio no es válida");
				}

				if (!Directory.Exists(directorio))
				{
					System.Diagnostics.Debug.WriteLine($"Creando directorio: {directorio}");
					Directory.CreateDirectory(directorio);
				}

				// Asegurar extensión .bak
				if (!rutaDestino.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
				{
					rutaDestino += ".bak";
				}

				System.Diagnostics.Debug.WriteLine($"Ruta destino final: {rutaDestino}");

				conexion = Conexion();
				System.Diagnostics.Debug.WriteLine($"Conexión creada");

				conexion.Open();
				System.Diagnostics.Debug.WriteLine($"Conexión abierta exitosamente");

				// Obtener el nombre de la base de datos desde la cadena de conexión
				string nombreBD = conexion.Database;
				System.Diagnostics.Debug.WriteLine($"Base de datos: {nombreBD}");
				System.Diagnostics.Debug.WriteLine($"Servidor: {conexion.DataSource}");
				System.Diagnostics.Debug.WriteLine($"Usuario: {conexion.ConnectionString}");

				// Verificar permisos
				using (SqlCommand cmdPermisos = new SqlCommand(
					"SELECT IS_SRVROLEMEMBER('sysadmin') AS EsSysAdmin, " +
					"HAS_PERMS_BY_NAME(NULL, NULL, 'BACKUP DATABASE') AS TienePermisoBackup",
					conexion))
				{
					using (SqlDataReader reader = cmdPermisos.ExecuteReader())
					{
						if (reader.Read())
						{
							System.Diagnostics.Debug.WriteLine($"Es SysAdmin: {reader["EsSysAdmin"]}");
							System.Diagnostics.Debug.WriteLine($"Tiene permiso BACKUP: {reader["TienePermisoBackup"]}");
						}
					}
				}

				string comandoSQL = $@"
                    BACKUP DATABASE [{nombreBD}] 
                    TO DISK = @RutaDestino 
                    WITH FORMAT, 
                         MEDIANAME = 'SQLServerBackup',
                         NAME = 'Respaldo completo de {nombreBD}',
                         COMPRESSION,
                         STATS = 10";

				System.Diagnostics.Debug.WriteLine($"Comando SQL: {comandoSQL}");

				using (SqlCommand comando = new SqlCommand(comandoSQL, conexion))
				{
					comando.CommandTimeout = 600; // 10 minutos de timeout
					comando.Parameters.AddWithValue("@RutaDestino", rutaDestino);

					System.Diagnostics.Debug.WriteLine($"Ejecutando comando BACKUP...");

					// Capturar mensajes de SQL Server
					conexion.InfoMessage += (sender, e) =>
					{
						System.Diagnostics.Debug.WriteLine($"SQL Server Info: {e.Message}");
					};
					conexion.FireInfoMessageEventOnUserErrors = true;

					comando.ExecuteNonQuery();

					System.Diagnostics.Debug.WriteLine($"Comando ejecutado exitosamente");
				}

				// Verificar que el archivo existe
				if (File.Exists(rutaDestino))
				{
					FileInfo fileInfo = new FileInfo(rutaDestino);
					System.Diagnostics.Debug.WriteLine($"Archivo creado exitosamente");
					System.Diagnostics.Debug.WriteLine($"Tamaño: {fileInfo.Length / 1024 / 1024} MB");
					System.Diagnostics.Debug.WriteLine($"=== RESPALDO COMPLETADO ===");
					return true;
				}
				else
				{
					System.Diagnostics.Debug.WriteLine($"ADVERTENCIA: El comando se ejecutó pero el archivo no existe");
					return false;
				}
			}
			catch (SqlException sqlEx)
			{
				// Log detallado de errores SQL
				System.Diagnostics.Debug.WriteLine($"=== ERROR SQL ===");
				System.Diagnostics.Debug.WriteLine($"Número: {sqlEx.Number}");
				System.Diagnostics.Debug.WriteLine($"Mensaje: {sqlEx.Message}");
				System.Diagnostics.Debug.WriteLine($"Procedimiento: {sqlEx.Procedure}");
				System.Diagnostics.Debug.WriteLine($"LineNumber: {sqlEx.LineNumber}");
				System.Diagnostics.Debug.WriteLine($"StackTrace: {sqlEx.StackTrace}");

				throw new Exception($"Error SQL al crear el respaldo:\n" +
					$"Número de error: {sqlEx.Number}\n" +
					$"Mensaje: {sqlEx.Message}\n" +
					$"Línea: {sqlEx.LineNumber}", sqlEx);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"=== ERROR GENERAL ===");
				System.Diagnostics.Debug.WriteLine($"Tipo: {ex.GetType().Name}");
				System.Diagnostics.Debug.WriteLine($"Mensaje: {ex.Message}");
				System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");

				throw new Exception($"Error al crear el respaldo de la base de datos:\n{ex.Message}", ex);
			}
			finally
			{
				if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
				{
					conexion.Close();
					System.Diagnostics.Debug.WriteLine($"Conexión cerrada");
				}
			}
		}

		/// <summary>
		/// Crea un respaldo completo de la base de datos de forma asíncrona
		/// </summary>
		/// <param name="rutaDestino">Ruta completa donde se guardará el archivo .bak</param>
		/// <param name="progress">Delegado para reportar el progreso (opcional)</param>
		/// <returns>true si el respaldo fue exitoso</returns>
		public async Task<bool> CrearRespaldoAsync(string rutaDestino, IProgress<int> progress = null)
		{
			return await Task.Run(() =>
			{
				SqlConnection conexion = null;
				try
				{
					// Log inicial
					System.Diagnostics.Debug.WriteLine($"=== ASYNC: INICIANDO RESPALDO ===");
					System.Diagnostics.Debug.WriteLine($"ASYNC: Ruta destino original: {rutaDestino}");

					// Validar que la ruta de destino sea válida
					string directorio = Path.GetDirectoryName(rutaDestino);
					System.Diagnostics.Debug.WriteLine($"ASYNC: Directorio: {directorio}");

					if (string.IsNullOrEmpty(directorio))
					{
						throw new Exception("La ruta del directorio no es válida");
					}

					if (!Directory.Exists(directorio))
					{
						System.Diagnostics.Debug.WriteLine($"ASYNC: Creando directorio: {directorio}");
						Directory.CreateDirectory(directorio);
					}
					else
					{
						System.Diagnostics.Debug.WriteLine($"ASYNC: Directorio ya existe");
					}

					// Asegurar extensión .bak
					if (!rutaDestino.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
					{
						rutaDestino += ".bak";
					}

					System.Diagnostics.Debug.WriteLine($"ASYNC: Ruta destino final: {rutaDestino}");

					conexion = Conexion();
					System.Diagnostics.Debug.WriteLine($"ASYNC: Conexión creada");

					conexion.Open();
					System.Diagnostics.Debug.WriteLine($"ASYNC: Conexión abierta exitosamente");

					string nombreBD = conexion.Database;
					System.Diagnostics.Debug.WriteLine($"ASYNC: Base de datos: {nombreBD}");
					System.Diagnostics.Debug.WriteLine($"ASYNC: Servidor: {conexion.DataSource}");

					string comandoSQL = $@"
                        BACKUP DATABASE [{nombreBD}] 
                        TO DISK = @RutaDestino 
                        WITH FORMAT, 
                             MEDIANAME = 'SQLServerBackup',
                             NAME = 'Respaldo completo de {nombreBD}',
                             COMPRESSION,
                             STATS = 10";

					System.Diagnostics.Debug.WriteLine($"ASYNC: Comando SQL preparado");

					using (SqlCommand comando = new SqlCommand(comandoSQL, conexion))
					{
						comando.CommandTimeout = 600;
						comando.Parameters.AddWithValue("@RutaDestino", rutaDestino);

						System.Diagnostics.Debug.WriteLine($"ASYNC: Parámetro @RutaDestino = {rutaDestino}");

						// Configurar evento de progreso si se proporciona
						if (progress != null)
						{
							conexion.InfoMessage += (sender, e) =>
							{
								System.Diagnostics.Debug.WriteLine($"ASYNC SQL Info: {e.Message}");

								// SQL Server envía mensajes con el porcentaje completado
								if (e.Message.Contains("percent processed"))
								{
									string[] partes = e.Message.Split(' ');
									if (int.TryParse(partes[0], out int porcentaje))
									{
										progress.Report(porcentaje);
									}
								}
							};
							conexion.FireInfoMessageEventOnUserErrors = true;
						}

						System.Diagnostics.Debug.WriteLine($"ASYNC: Ejecutando comando BACKUP...");
						comando.ExecuteNonQuery();
						System.Diagnostics.Debug.WriteLine($"ASYNC: Comando ejecutado exitosamente");
					}

					// Verificar que el archivo existe
					System.Diagnostics.Debug.WriteLine($"ASYNC: Verificando existencia del archivo...");
					if (File.Exists(rutaDestino))
					{
						FileInfo fileInfo = new FileInfo(rutaDestino);
						System.Diagnostics.Debug.WriteLine($"ASYNC: ¡Archivo creado exitosamente!");
						System.Diagnostics.Debug.WriteLine($"ASYNC: Ruta completa: {fileInfo.FullName}");
						System.Diagnostics.Debug.WriteLine($"ASYNC: Tamaño: {fileInfo.Length / 1024 / 1024} MB");
						System.Diagnostics.Debug.WriteLine($"ASYNC: Fecha creación: {fileInfo.CreationTime}");
						System.Diagnostics.Debug.WriteLine($"=== ASYNC: RESPALDO COMPLETADO ===");

						progress?.Report(100);
						return true;
					}
					else
					{
						System.Diagnostics.Debug.WriteLine($"ASYNC: ¡ADVERTENCIA! El comando se ejecutó pero el archivo NO existe en: {rutaDestino}");

						// Intentar buscar el archivo en ubicaciones alternativas
						string nombreArchivo = Path.GetFileName(rutaDestino);
						System.Diagnostics.Debug.WriteLine($"ASYNC: Buscando archivo '{nombreArchivo}' en ubicaciones alternativas...");

						// Buscar en carpeta de respaldos predeterminada
						string[] posiblesRutas = new string[]
						{
							@"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\" + nombreArchivo,
							Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nombreArchivo),
							Path.Combine(Path.GetTempPath(), nombreArchivo)
						};

						foreach (string ruta in posiblesRutas)
						{
							if (File.Exists(ruta))
							{
								System.Diagnostics.Debug.WriteLine($"ASYNC: ¡Archivo encontrado en ubicación alternativa!: {ruta}");
								return true;
							}
						}

						progress?.Report(100);
						return false;
					}
				}
				catch (SqlException sqlEx)
				{
					System.Diagnostics.Debug.WriteLine($"=== ASYNC: ERROR SQL ===");
					System.Diagnostics.Debug.WriteLine($"ASYNC: Número: {sqlEx.Number}");
					System.Diagnostics.Debug.WriteLine($"ASYNC: Mensaje: {sqlEx.Message}");
					System.Diagnostics.Debug.WriteLine($"ASYNC: StackTrace: {sqlEx.StackTrace}");

					throw new Exception($"Error SQL al crear el respaldo:\n" +
						$"Número de error: {sqlEx.Number}\n" +
						$"Mensaje: {sqlEx.Message}", sqlEx);
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine($"=== ASYNC: ERROR GENERAL ===");
					System.Diagnostics.Debug.WriteLine($"ASYNC: Tipo: {ex.GetType().Name}");
					System.Diagnostics.Debug.WriteLine($"ASYNC: Mensaje: {ex.Message}");
					System.Diagnostics.Debug.WriteLine($"ASYNC: StackTrace: {ex.StackTrace}");

					throw new Exception($"Error al crear el respaldo de la base de datos:\n{ex.Message}", ex);
				}
				finally
				{
					if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
					{
						conexion.Close();
						System.Diagnostics.Debug.WriteLine($"ASYNC: Conexión cerrada");
					}
				}
			});
		}

		/// <summary>
		/// Obtiene la ruta predeterminada de respaldos de SQL Server
		/// </summary>
		/// <returns>Ruta predeterminada configurada en SQL Server</returns>
		public string ObtenerRutaPredeterminadaRespaldos()
		{
			try
			{
				using (SqlConnection conexion = Conexion())
				{
					conexion.Open();

					string comandoSQL = @"
                        DECLARE @BackupDirectory NVARCHAR(500);
                        EXEC master.dbo.xp_instance_regread 
                            N'HKEY_LOCAL_MACHINE',
                            N'Software\Microsoft\MSSQLServer\MSSQLServer',
                            N'BackupDirectory',
                            @BackupDirectory OUTPUT;
                        SELECT @BackupDirectory AS RutaRespaldo;";

					using (SqlCommand comando = new SqlCommand(comandoSQL, conexion))
					{
						object resultado = comando.ExecuteScalar();
						if (resultado != null && resultado != DBNull.Value)
						{
							return resultado.ToString();
						}
					}
				}

				// Si no se pudo obtener, usar ruta predeterminada común
				return @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup";
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"Error al obtener ruta predeterminada: {ex.Message}");
				return @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup";
			}
		}

		/// <summary>
		/// Crea un respaldo en la ubicación predeterminada de SQL Server y opcionalmente lo copia a otra ubicación
		/// Este método garantiza que el respaldo se cree exitosamente
		/// </summary>
		/// <param name="rutaDestino">Ruta final donde se copiará el respaldo (opcional)</param>
		/// <param name="progress">Reporte de progreso</param>
		/// <returns>Ruta donde finalmente quedó el archivo</returns>
		public async Task<string> CrearRespaldoSeguroAsync(string rutaDestino = null, IProgress<int> progress = null)
		{
			string rutaTemporal = null;

			try
			{
				// Primero crear en la ubicación predeterminada de SQL Server
				string rutaPredeterminada = ObtenerRutaPredeterminadaRespaldos();
				string nombreArchivo = $"Agraria_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
				rutaTemporal = Path.Combine(rutaPredeterminada, nombreArchivo);

				System.Diagnostics.Debug.WriteLine($"Creando respaldo temporal en: {rutaTemporal}");

				// Crear el respaldo en la ubicación segura
				bool exitoso = await CrearRespaldoAsync(rutaTemporal, progress);

				if (!exitoso || !File.Exists(rutaTemporal))
				{
					throw new Exception("No se pudo crear el archivo de respaldo");
				}

				// Si se especificó una ruta de destino diferente, copiar el archivo
				if (!string.IsNullOrEmpty(rutaDestino) && rutaDestino != rutaTemporal)
				{
					System.Diagnostics.Debug.WriteLine($"Copiando respaldo a: {rutaDestino}");

					// Asegurar que el directorio destino existe
					string directorioDestino = Path.GetDirectoryName(rutaDestino);
					if (!Directory.Exists(directorioDestino))
					{
						Directory.CreateDirectory(directorioDestino);
					}

					// Copiar el archivo
					File.Copy(rutaTemporal, rutaDestino, true);

					System.Diagnostics.Debug.WriteLine($"Archivo copiado exitosamente");

					// Eliminar el archivo temporal (opcional)
					// File.Delete(rutaTemporal);

					return rutaDestino;
				}

				return rutaTemporal;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"Error en CrearRespaldoSeguro: {ex.Message}");
				throw;
			}
		}

		/// <summary>
		/// Restaura una base de datos desde un archivo de respaldo
		/// PRECAUCIÓN: Esta operación sobrescribirá la base de datos actual
		/// </summary>
		/// <param name="rutaRespaldo">Ruta del archivo .bak a restaurar</param>
		/// <param name="forzarReemplazo">Si es true, reemplaza la BD existente</param>
		public bool RestaurarRespaldo(string rutaRespaldo, bool forzarReemplazo = false)
		{
			try
			{
				if (!File.Exists(rutaRespaldo))
				{
					throw new FileNotFoundException("El archivo de respaldo no existe", rutaRespaldo);
				}

				using (SqlConnection conexion = Conexion())
				{
					conexion.Open();
					string nombreBD = conexion.Database;

					// Poner la base de datos en modo de usuario único para la restauración
					string comandoPreparacion = $@"
                        ALTER DATABASE [{nombreBD}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

					string comandoRestaurar = $@"
                        RESTORE DATABASE [{nombreBD}] 
                        FROM DISK = @RutaRespaldo 
                        WITH {(forzarReemplazo ? "REPLACE," : "")} 
                             STATS = 10;";

					string comandoFinal = $@"
                        ALTER DATABASE [{nombreBD}] SET MULTI_USER;";

					try
					{
						using (SqlCommand cmd = new SqlCommand(comandoPreparacion, conexion))
						{
							cmd.ExecuteNonQuery();
						}

						using (SqlCommand cmd = new SqlCommand(comandoRestaurar, conexion))
						{
							cmd.CommandTimeout = 600;
							cmd.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);
							cmd.ExecuteNonQuery();
						}

						using (SqlCommand cmd = new SqlCommand(comandoFinal, conexion))
						{
							cmd.ExecuteNonQuery();
						}
					}
					catch
					{
						// Intentar volver a modo multi-usuario en caso de error
						try
						{
							using (SqlCommand cmd = new SqlCommand(comandoFinal, conexion))
							{
								cmd.ExecuteNonQuery();
							}
						}
						catch { }
						throw;
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"Error al restaurar respaldo: {ex.Message}");
				throw new Exception($"Error al restaurar el respaldo: {ex.Message}", ex);
			}
		}

		/// <summary>
		/// Verifica si un archivo de respaldo es válido
		/// </summary>
		/// <param name="rutaRespaldo">Ruta del archivo .bak a verificar</param>
		/// <returns>true si el respaldo es válido</returns>
		public bool VerificarRespaldo(string rutaRespaldo)
		{
			try
			{
				if (!File.Exists(rutaRespaldo))
				{
					return false;
				}

				using (SqlConnection conexion = Conexion())
				{
					conexion.Open();

					string comandoSQL = @"
                        RESTORE VERIFYONLY 
                        FROM DISK = @RutaRespaldo";

					using (SqlCommand comando = new SqlCommand(comandoSQL, conexion))
					{
						comando.CommandTimeout = 300;
						comando.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);
						comando.ExecuteNonQuery();
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"Error al verificar respaldo: {ex.Message}");
				return false;
			}
		}

		/// <summary>
		/// Obtiene información sobre un archivo de respaldo
		/// </summary>
		/// <param name="rutaRespaldo">Ruta del archivo .bak</param>
		/// <returns>Información del respaldo como string</returns>
		public string ObtenerInfoRespaldo(string rutaRespaldo)
		{
			try
			{
				if (!File.Exists(rutaRespaldo))
				{
					throw new FileNotFoundException("El archivo de respaldo no existe", rutaRespaldo);
				}

				using (SqlConnection conexion = Conexion())
				{
					conexion.Open();

					string comandoSQL = @"
                        RESTORE HEADERONLY 
                        FROM DISK = @RutaRespaldo";

					using (SqlCommand comando = new SqlCommand(comandoSQL, conexion))
					{
						comando.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);

						using (SqlDataReader reader = comando.ExecuteReader())
						{
							if (reader.Read())
							{
								string info = $"Base de datos: {reader["DatabaseName"]}\n";
								info += $"Fecha de respaldo: {reader["BackupFinishDate"]}\n";
								info += $"Tipo: {reader["BackupType"]}\n";
								info += $"Tamaño: {Convert.ToInt64(reader["BackupSize"]) / 1024 / 1024} MB";
								return info;
							}
						}
					}
				}

				return "No se pudo obtener información del respaldo";
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"Error al obtener info del respaldo: {ex.Message}");
				throw new Exception($"Error al obtener información del respaldo: {ex.Message}", ex);
			}
		}

		public string GenerarNombreRespaldo(string rutaCarpeta, string prefijo = "Agraria_Backup")
		{
			throw new NotImplementedException();
		}
	}
}
