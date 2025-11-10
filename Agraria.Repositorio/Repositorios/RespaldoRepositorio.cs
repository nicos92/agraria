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

		public bool CrearRespaldo(string rutaDestino)
		{
			SqlConnection conexion = null;
			try
			{
				

				// Validar que la ruta de destino sea válida
				string directorio = Path.GetDirectoryName(rutaDestino);

				if (string.IsNullOrEmpty(directorio))
				{
					throw new Exception("La ruta del directorio no es válida");
				}

				if (!Directory.Exists(directorio))
				{
					Directory.CreateDirectory(directorio);
				}

				// Asegurar extensión .bak
				if (!rutaDestino.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
				{
					rutaDestino += ".bak";
				}

				

				conexion = Conexion();

				conexion.Open();

				
				string nombreBD = conexion.Database;
				

				

				string comandoSQL = $@"
                    BACKUP DATABASE [{nombreBD}] 
                    TO DISK = @RutaDestino 
                    WITH FORMAT, 
                         MEDIANAME = 'SQLServerBackup',
                         NAME = 'Respaldo completo de {nombreBD}',
                         COMPRESSION,
                         STATS = 10";


				using (SqlCommand comando = new(comandoSQL, conexion))
				{
					comando.CommandTimeout = 600; 
					comando.Parameters.AddWithValue("@RutaDestino", rutaDestino);


					
					conexion.FireInfoMessageEventOnUserErrors = true;

					comando.ExecuteNonQuery();

				
				}

				if (File.Exists(rutaDestino))
				{
					FileInfo fileInfo = new(rutaDestino);
					
					return true;
				}
				else
				{
					
					return false;
				}
			}
			catch (SqlException sqlEx)
			{
				

				throw new Exception($"Error SQL al crear el respaldo:\n" +
					$"Número de error: {sqlEx.Number}\n" +
					$"Mensaje: {sqlEx.Message}\n" +
					$"Línea: {sqlEx.LineNumber}", sqlEx);
			}
			catch (Exception ex)
			{
				
				throw new Exception($"Error al crear el respaldo de la base de datos:\n{ex.Message}", ex);
			}
			finally
			{
				if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
				{
					conexion.Close();
				}
			}
		}

		
		public async Task<bool> CrearRespaldoAsync(string rutaDestino, IProgress<int> progress = null)
		{
			return await Task.Run(() =>
			{
				SqlConnection conexion = null;
				try
				{
					

					string directorio = Path.GetDirectoryName(rutaDestino);
					System.Diagnostics.Debug.WriteLine($"ASYNC: Directorio: {directorio}");

					if (string.IsNullOrEmpty(directorio))
					{
						throw new Exception("La ruta del directorio no es válida");
					}

					if (!Directory.Exists(directorio))
					{
						
						Directory.CreateDirectory(directorio);
					}

					// Asegurar extensión .bak
					if (!rutaDestino.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
					{
						rutaDestino += ".bak";
					}

				

					conexion = Conexion();

					conexion.Open();

					string nombreBD = conexion.Database;
					

					string comandoSQL = $@"
                        BACKUP DATABASE [{nombreBD}] 
                        TO DISK = @RutaDestino 
                        WITH FORMAT, 
                             MEDIANAME = 'SQLServerBackup',
                             NAME = 'Respaldo completo de {nombreBD}',
                             COMPRESSION,
                             STATS = 10";

				

					using (SqlCommand comando = new(comandoSQL, conexion))
					{
						comando.CommandTimeout = 600;
						comando.Parameters.AddWithValue("@RutaDestino", rutaDestino);

						
						if (progress != null)
						{
							conexion.InfoMessage += (sender, e) =>
							{
							
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
						comando.ExecuteNonQuery();
					}

					if (File.Exists(rutaDestino))
					{
						FileInfo fileInfo = new(rutaDestino);
						

						progress?.Report(100);
						return true;
					}
					else
					{

						string nombreArchivo = Path.GetFileName(rutaDestino);
					

						string[] posiblesRutas =
						[
							@"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\" + nombreArchivo,
							Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), nombreArchivo),
							Path.Combine(Path.GetTempPath(), nombreArchivo)
						];

						foreach (string ruta in posiblesRutas)
						{
							if (File.Exists(ruta))
							{
								
								return true;
							}
						}

						progress?.Report(100);
						return false;
					}
				}
				catch (SqlException sqlEx)
				{
					
					throw new Exception($"Error SQL al crear el respaldo:\n" +
						$"Número de error: {sqlEx.Number}\n" +
						$"Mensaje: {sqlEx.Message}", sqlEx);
				}
				catch (Exception ex)
				{
					

					throw new Exception($"Error al crear el respaldo de la base de datos:\n{ex.Message}", ex);
				}
				finally
				{
					if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
					{
						conexion.Close();
						
					}
				}
			});
		}

		public string ObtenerRutaPredeterminadaRespaldos()
		{
			try
			{
				using SqlConnection conexion = Conexion();
				conexion.Open();

				string comandoSQL = @"
                        DECLARE @BackupDirectory NVARCHAR(500);
                        EXEC master.dbo.xp_instance_regread 
                            N'HKEY_LOCAL_MACHINE',
                            N'Software\Microsoft\MSSQLServer\MSSQLServer',
                            N'BackupDirectory',
                            @BackupDirectory OUTPUT;
                        SELECT @BackupDirectory AS RutaRespaldo;";

				using SqlCommand comando = new(comandoSQL, conexion);
				object resultado = comando.ExecuteScalar();
				if (resultado != null && resultado != DBNull.Value)
				{
					return resultado.ToString();
				}

				return @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup";
			}
			catch (Exception)
			{
				return @"C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup";
			}
		}


		public async Task<string> CrearRespaldoSeguroAsync(string rutaDestino = null, IProgress<int> progress = null)
		{
			try
			{
				string rutaPredeterminada = ObtenerRutaPredeterminadaRespaldos();
				string nombreArchivo = $"Agraria_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
				string? rutaTemporal = Path.Combine(rutaPredeterminada, nombreArchivo);
				bool exitoso = await CrearRespaldoAsync(rutaTemporal, progress);

				if (!exitoso || !File.Exists(rutaTemporal))
				{
					throw new Exception("No se pudo crear el archivo de respaldo");
				}

				if (!string.IsNullOrEmpty(rutaDestino) && rutaDestino != rutaTemporal)
				{
				

					// Asegurar que el directorio destino existe
					string directorioDestino = Path.GetDirectoryName(rutaDestino);
					if (!Directory.Exists(directorioDestino))
					{
						Directory.CreateDirectory(directorioDestino);
					}

					File.Copy(rutaTemporal, rutaDestino, true);

					

					return rutaDestino;
				}

				return rutaTemporal;
			}
			catch (Exception)
			{
				
				throw;
			}
		}

		
		public bool RestaurarRespaldo(string rutaRespaldo, bool forzarReemplazo = false)
		{
			try
			{
				if (!File.Exists(rutaRespaldo))
				{
					throw new FileNotFoundException("El archivo de respaldo no existe", rutaRespaldo);
				}

				using SqlConnection conexion = Conexion();
				conexion.Open();
				string nombreBD = conexion.Database;


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
					using (SqlCommand cmd = new(comandoPreparacion, conexion))
					{
						cmd.ExecuteNonQuery();
					}

					using (SqlCommand cmd = new(comandoRestaurar, conexion))
					{
						cmd.CommandTimeout = 600;
						cmd.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);
						cmd.ExecuteNonQuery();
					}

					using (SqlCommand cmd = new(comandoFinal, conexion))
					{
						cmd.ExecuteNonQuery();
					}
				}
				catch
				{
					// Intentar volver a modo multi-usuario en caso de error
					try
					{
						using SqlCommand cmd = new(comandoFinal, conexion);
						cmd.ExecuteNonQuery();
					}
					catch { }
					throw;
				}

				return true;
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al restaurar el respaldo: {ex.Message}", ex);
			}
		}

		public async Task<bool> RestaurarRespaldoAsync(string rutaRespaldo, bool forzarReemplazo = false, IProgress<string> progress = null)
		{
			return await Task.Run(() =>
			{
				SqlConnection conexion = null;
				try
				{
					
					progress?.Report("Verificando archivo de respaldo...");

					if (!File.Exists(rutaRespaldo))
					{
						throw new FileNotFoundException("El archivo de respaldo no existe", rutaRespaldo);
					}

					

					conexion = Conexion();
					conexion.Open();

					string nombreBD = conexion.Database;
				

					progress?.Report("Cerrando conexiones activas...");
				

					string comandoCerrarConexiones = $@"
                        ALTER DATABASE [{nombreBD}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

					using (SqlCommand cmd = new(comandoCerrarConexiones, conexion))
					{
						cmd.ExecuteNonQuery();
					}

					progress?.Report("Restaurando base de datos...");

					string comandoRestaurar = $@"
                        RESTORE DATABASE [{nombreBD}] 
                        FROM DISK = @RutaRespaldo 
                        WITH {(forzarReemplazo ? "REPLACE," : "")} 
                             STATS = 10;";

					try
					{
						using (SqlCommand cmd = new(comandoRestaurar, conexion))
						{
							cmd.CommandTimeout = 600;
							cmd.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);

							conexion.InfoMessage += (sender, e) =>
							{
							
								progress?.Report($"Restaurando... {e.Message}");
							};
							conexion.FireInfoMessageEventOnUserErrors = true;

							cmd.ExecuteNonQuery();
						}
					

						progress?.Report("Finalizando restauración...");
						

						string comandoFinal = $@"
                            ALTER DATABASE [{nombreBD}] SET MULTI_USER WITH ROLLBACK IMMEDIATE;";

						using (SqlCommand cmd = new(comandoFinal, conexion))
						{
							cmd.ExecuteNonQuery();
						}

					
						progress?.Report("Restauración completada exitosamente");
						return true;
					}
					catch (Exception)
					{
					
						progress?.Report("Error: Intentando recuperar...");

						try
						{
							string comandoRecuperar = $@"
                                ALTER DATABASE [{nombreBD}] SET MULTI_USER WITH ROLLBACK IMMEDIATE;";

							using SqlCommand cmd = new(comandoRecuperar, conexion);
							cmd.ExecuteNonQuery();

						}
						catch (Exception )
						{
							throw;
						}

						throw;
					}
				}
				catch (Exception ex)
				{
					
					throw new Exception($"Error al restaurar el respaldo: {ex.Message}", ex);
				}
				finally
				{
					if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
					{
						conexion.Close();
					}
				}
			});
		}


		public bool VerificarRespaldo(string rutaRespaldo)
		{
			try
			{
				if (!File.Exists(rutaRespaldo))
				{
					return false;
				}

				using SqlConnection conexion = Conexion();
				conexion.Open();

				string comandoSQL = @"
                        RESTORE VERIFYONLY 
                        FROM DISK = @RutaRespaldo";

				using SqlCommand comando = new(comandoSQL, conexion);
				comando.CommandTimeout = 300;
				comando.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);
				comando.ExecuteNonQuery();

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public string ObtenerInfoRespaldo(string rutaRespaldo)
		{
			try
			{
				if (!File.Exists(rutaRespaldo))
				{
					throw new FileNotFoundException("El archivo de respaldo no existe", rutaRespaldo);
				}

				using SqlConnection conexion = Conexion();
				conexion.Open();

				string comandoSQL = @"
                        RESTORE HEADERONLY 
                        FROM DISK = @RutaRespaldo";

				using SqlCommand comando = new(comandoSQL, conexion);
				comando.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);

				using SqlDataReader reader = comando.ExecuteReader();
				if (reader.Read())
				{
					string info = $"Base de datos: {reader["DatabaseName"]}\n";
					info += $"Fecha de respaldo: {reader["BackupFinishDate"]}\n";
					info += $"Tipo: {reader["BackupType"]}\n";
					info += $"Tamaño: {Convert.ToInt64(reader["BackupSize"]) / 1024 / 1024} MB";
					return info;
				}

				return "No se pudo obtener información del respaldo";
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al obtener información del respaldo: {ex.Message}", ex);
			}
		}

		public string GenerarNombreRespaldo(string rutaCarpeta, string prefijo = "Agraria_Backup")
		{
			throw new NotImplementedException();
		}



		public async Task<bool> RestaurarOCrearBaseDatosAsync(string rutaRespaldo, string nombreBaseDatos = "Agraria", IProgress<string> progress = null)
		{
			return await Task.Run(() =>
			{
				SqlConnection conexion = null;
				try
				{
					
					progress?.Report("Verificando archivo de respaldo...");

					if (!File.Exists(rutaRespaldo))
					{
						throw new FileNotFoundException("El archivo de respaldo no existe", rutaRespaldo);
					}

					SqlConnectionStringBuilder builder = new(ConexionRestaurarDB().ConnectionString);
					string nombreBDDestino = nombreBaseDatos ?? builder.InitialCatalog;
					builder.InitialCatalog = "master";

				

					conexion = new SqlConnection(builder.ConnectionString);
					conexion.Open();

					bool existeBD = false;
					using (SqlCommand cmdVerificar = new(
						$"SELECT COUNT(*) FROM sys.databases WHERE name = '{nombreBDDestino}'",
						conexion))
					{
						existeBD = (int)cmdVerificar.ExecuteScalar() > 0;
					}


					if (existeBD)
					{
						// Si existe, cerrar conexiones
						progress?.Report("Base de datos existente. Cerrando conexiones...");
						

						string comandoCerrar = $@"
                            USE master;
                            ALTER DATABASE [{nombreBDDestino}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

						using SqlCommand cmd = new(comandoCerrar, conexion);
						cmd.ExecuteNonQuery();
					}
					else
					{
						progress?.Report("Base de datos no existe. Se creará desde el respaldo...");
						
					}

					// Obtener los nombres lógicos de los archivos del respaldo
					progress?.Report("Analizando estructura del respaldo...");
					

					string archivoLogico = "";
					string archivoLogicoLog = "";

					string comandoFileList = "RESTORE FILELISTONLY FROM DISK = @RutaRespaldo";
					using (SqlCommand cmd = new(comandoFileList, conexion))
					{
						cmd.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);
						using SqlDataReader reader = cmd.ExecuteReader();
						while (reader.Read())
						{
							string logicalName = reader["LogicalName"].ToString();
							string type = reader["Type"].ToString();

							if (type == "D") // Data file
							{
								archivoLogico = logicalName;

							}
							else if (type == "L") // Log file
							{
								archivoLogicoLog = logicalName;
								System.Diagnostics.Debug.WriteLine($"Archivo de log: {logicalName}");
							}
						}
					}

					// Obtener rutas predeterminadas de SQL Server
					string rutaDatos = "";
					string rutaLog = "";

					using (SqlCommand cmd = new(
						"SELECT SERVERPROPERTY('InstanceDefaultDataPath') AS DataPath, " +
						"SERVERPROPERTY('InstanceDefaultLogPath') AS LogPath",
						conexion))
					{
						using SqlDataReader reader = cmd.ExecuteReader();
						if (reader.Read())
						{
							rutaDatos = reader["DataPath"].ToString();
							rutaLog = reader["LogPath"].ToString();
						}
					}

					
					progress?.Report("Restaurando base de datos...");

					string comandoRestaurar = $@"
                        USE master;
                        RESTORE DATABASE [{nombreBDDestino}] 
                        FROM DISK = @RutaRespaldo 
                        WITH REPLACE,
                             MOVE '{archivoLogico}' TO '{Path.Combine(rutaDatos, nombreBDDestino + ".mdf")}',
                             MOVE '{archivoLogicoLog}' TO '{Path.Combine(rutaLog, nombreBDDestino + "_log.ldf")}',
                             STATS = 10;";

					using (SqlCommand cmd = new(comandoRestaurar, conexion))
					{
						cmd.CommandTimeout = 600;
						cmd.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);

						conexion.InfoMessage += (sender, e) =>
						{
							System.Diagnostics.Debug.WriteLine($"SQL Info: {e.Message}");
							if (e.Message.Contains("percent processed") ||
								e.Message.Contains("Processed") ||
								e.Message.Contains("successfully"))
							{
								progress?.Report($"Restaurando... {e.Message}");
							}
						};
						conexion.FireInfoMessageEventOnUserErrors = true;

						cmd.ExecuteNonQuery();
					}

					// Establecer modo MULTI_USER
					progress?.Report("Finalizando...");
				
					string comandoFinal = $@"
                        USE master;
                        ALTER DATABASE [{nombreBDDestino}] SET MULTI_USER WITH ROLLBACK IMMEDIATE;";

					using (SqlCommand cmd = new(comandoFinal, conexion))
					{
						cmd.ExecuteNonQuery();
					}

					
					progress?.Report("Restauración completada exitosamente");
					return true;
				}
				catch (Exception ex)
				{
			
					throw new Exception($"Error al restaurar/crear base de datos: {ex.Message}", ex);
				}
				finally
				{
					if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
					{
						conexion.Close();
					}
				}
			});
		}



		public List<(string NombreLogico, string TipoArchivo, string NombreFisico)> ObtenerArchivosRespaldo(string rutaRespaldo)
		{
			List<(string, string, string)> archivos = [];

			try
			{
				SqlConnectionStringBuilder builder = new(Conexion().ConnectionString)
				{
					InitialCatalog = "master"
				};

				using SqlConnection conexion = new(builder.ConnectionString);
				conexion.Open();

				string comando = "RESTORE FILELISTONLY FROM DISK = @RutaRespaldo";
				using SqlCommand cmd = new(comando, conexion);
				cmd.Parameters.AddWithValue("@RutaRespaldo", rutaRespaldo);

				using SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					string logicalName = reader["LogicalName"].ToString();
					string type = reader["Type"].ToString();
					string physicalName = reader["PhysicalName"].ToString();

					string tipoTexto = type == "D" ? "Datos" :
									  type == "L" ? "Log" :
									  "Otro";

					archivos.Add((logicalName, tipoTexto, physicalName));
				}
			}
			catch (Exception)
			{
				throw;
			}

			return archivos;
		}
       



	}
}
