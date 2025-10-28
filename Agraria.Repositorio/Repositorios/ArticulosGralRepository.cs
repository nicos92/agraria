using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using Agraria.Modelo.Enums;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class ArticulosGralRepository : BaseRepositorio, IArticulosGralRepository
    {
        public async  Task<Result<ArticulosGral>> Add(ArticulosGral articulo)
        {
            SqlTransaction? transaction = null;

            try
            {
                using var conn = Conexion();
                await conn.OpenAsync();

                transaction = (SqlTransaction)await conn.BeginTransactionAsync();

                // 1. Obtener el último Cod_Producto de la tabla Productos
                string sqlSelectMaxCod = "SELECT TOP 1 Art_Cod FROM ArticulosGral WITH (UPDLOCK) ORDER BY Art_Id DESC";
                string? ultimoCodArt = null;
                using (SqlCommand cmdSelect = new(sqlSelectMaxCod, conn, transaction))
                {
                    object? result = await cmdSelect.ExecuteScalarAsync();
                    if (result != DBNull.Value && result != null)
                    {
                        ultimoCodArt = result.ToString();
                    }
                }

                // 2. Generar el nuevo Cod_Producto
                string? nuevoCodArt;
                if (string.IsNullOrEmpty(ultimoCodArt))
                {
                    // Si la tabla está vacía, el primer código será 'P001'
                    nuevoCodArt = "A0000001";
                }
                else
                {
                    // Extraer el número del código, incrementarlo y formatearlo
                    string numeroStr = ultimoCodArt.Substring(1); // "001"
                    int ultimoNumero = int.Parse(numeroStr);
                    int nuevoNumero = ultimoNumero + 1;
                    nuevoCodArt = $"A{nuevoNumero:D7}"; 
                }
                using var cmd = new SqlCommand("INSERT INTO ArticulosGral (Art_Cod, Art_Nombre, Art_Unidad_Medida, Art_Precio, Art_Descripcion, Art_Stock, Id_Proveedor) VALUES (@Art_Cod, @Art_Nombre, @Art_Uni_Med, @Art_Precio, @Art_Descripcion, @Art_Stock, @Id_Proveedor)", conn, transaction);

                cmd.Parameters.AddWithValue("@Art_Cod", nuevoCodArt);
                cmd.Parameters.AddWithValue("@Art_Nombre", articulo.Art_Nombre );
                cmd.Parameters.AddWithValue("@Art_Uni_Med", Convert.ToInt32(articulo.Art_Uni_Med) );
                cmd.Parameters.AddWithValue("@Art_Precio", articulo.Art_Precio);
                cmd.Parameters.AddWithValue("@Art_Descripcion", articulo.Art_Descripcion);
                cmd.Parameters.AddWithValue("@Art_Stock", articulo.Art_Stock);
                cmd.Parameters.AddWithValue("@Id_Proveedor", articulo.Id_Proveedor);

                int inserts = await cmd.ExecuteNonQueryAsync();
                await transaction.CommitAsync();
                if (inserts > 0)
                {
                    return Result<ArticulosGral>.Success(articulo);
                }
                else
                {
                    if (transaction != null)
                    {

                        await transaction.RollbackAsync();
                    }
                    return Result<ArticulosGral>.Failure("No se pudo agregar el artículo general.");
                }
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<ArticulosGral>.Failure($"Error al agregar el artículo general: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("DELETE FROM ArticulosGral WHERE Art_Id = @Art_Id", conn);
                cmd.Parameters.AddWithValue("@Art_Id", id);
                conn.Open();
                int deletes = cmd.ExecuteNonQuery();
                if (deletes > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar el artículo general.");
                }
            }
            catch (SqlException ex)
            {
                return Result<bool>.Failure($"Error al eliminar el artículo general: {ex.Message}");
            }
        }

        public async Task<Result<List<ArticulosGral>>> GetAll()
        {
            try
            {
                List<ArticulosGral> articulos = [];
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT Art_Id, Art_Cod, Art_Nombre, Art_Unidad_Medida, Art_Precio, Art_Descripcion, Art_Stock, Id_Proveedor FROM ArticulosGral", conn);
                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    ArticulosGral articulo = new ()
                    {
                        Art_Id = reader.GetInt32(0),
                        Art_Cod = reader.GetString(1),
                        Art_Nombre = reader.GetString(2),
                        Art_Uni_Med = (UnidadMedida) reader.GetInt32(3),
                        Art_Precio = reader.GetDecimal(4),
                        Art_Descripcion = reader.GetString(5),
                        Art_Stock = reader.GetDecimal(6),
                        Id_Proveedor = reader.GetInt32(7)
                    };
                    articulos.Add(articulo);
                }
                return Result<List<ArticulosGral>>.Success(articulos);
            }
            catch (SqlException ex)
            {
                return Result<List<ArticulosGral>>.Failure($"Error al obtener los artículos generales: {ex.Message}");
            }
        }

        public Result<ArticulosGral> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT Art_Id, Art_Cod, Art_Nombre, Art_Unidad_Medida, Art_Precio, Art_Descripcion, Art_Stock, Id_Proveedor FROM ArticulosGral WHERE Art_Id = @Art_Id", conn);
                cmd.Parameters.AddWithValue("@Art_Id", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ArticulosGral articulo = new()
                    {
                        Art_Id = reader.GetInt32(0),
                        Art_Cod = reader.GetString(1),
                        Art_Nombre = reader.GetString(2),
                        Art_Uni_Med =  (UnidadMedida) reader.GetInt32(3),
                        Art_Precio = reader.GetDecimal(4),
                        Art_Descripcion = reader.GetString(5),
                        Art_Stock = reader.GetInt32(6),
                        Id_Proveedor = reader.GetInt32(7)
                    };
                    return Result<ArticulosGral>.Success(articulo);
                }
                return Result<ArticulosGral>.Failure("No se pudo obtener el artículo general");
            }
            catch (SqlException ex)
            {
                return Result<ArticulosGral>.Failure($"Error al obtener artículo general: {ex.Message}");
            }
        }

        public async Task<Result<int>> GetMaxCodArt()
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT MAX(Art_Cod) FROM ArticulosGral", conn);
                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    if (!reader.IsDBNull(0))
                    {
                        string? maxCod = reader.GetString(0);
                        if (int.TryParse(maxCod, out int max))
                        {
                            return Result<int>.Success(max);
                        }
                    }
                    return Result<int>.Success(0);
                }
                return Result<int>.Failure("No se pudo obtener el último código de los artículos generales");
            }
            catch (SqlException ex)
            {
                return Result<int>.Failure($"Error en la base de datos al obtener el último código de los artículos generales: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<int>.Failure("Error inesperado al obtener el último código de los artículos generales" + ex.Message);
            }
        }

        public async Task<Result<ArticulosGral>> Update(ArticulosGral articulo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("UPDATE ArticulosGral SET Art_Cod=@Art_Cod, Art_Nombre=@Art_Nombre, Art_Unidad_Medida=@Art_Uni_Med, Art_Precio=@Art_Precio, Art_Descripcion=@Art_Descripcion, Art_Stock=@Art_Stock, Id_Proveedor = @Id_Proveedor WHERE Art_Id = @Art_Id", conn);
                cmd.Parameters.AddWithValue("@Art_Cod", articulo.Art_Cod );
                cmd.Parameters.AddWithValue("@Art_Nombre", articulo.Art_Nombre );
                cmd.Parameters.AddWithValue("@Art_Uni_Med", Convert.ToInt32(articulo.Art_Uni_Med ));
                cmd.Parameters.AddWithValue("@Art_Precio", articulo.Art_Precio);
                cmd.Parameters.AddWithValue("@Art_Descripcion", articulo.Art_Descripcion);
                cmd.Parameters.AddWithValue("@Art_Stock", articulo.Art_Stock);
                cmd.Parameters.AddWithValue("@Art_Id", articulo.Art_Id);
                cmd.Parameters.AddWithValue("@Id_Proveedor", articulo.Id_Proveedor);
                await conn.OpenAsync();
                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    return Result<ArticulosGral>.Success(articulo);
                }
                return Result<ArticulosGral>.Failure("No se actualizó el artículo general");
            }
            catch (SqlException ex)
            {
                return Result<ArticulosGral>.Failure($"Error al actualizar el artículo general: {ex.Message}");
            }
        }

		public async Task<Result<bool>> UpdateStock(string id, decimal nuevoStock)
		{
			try
			{
				using var conn = Conexion();
				using var cmd = new SqlCommand("UPDATE ArticulosGral SET Art_Stock = Art_Stock - @Art_Stock WHERE Art_Cod = @Art_Id", conn);
				cmd.Parameters.AddWithValue("@Art_Stock", nuevoStock);
				cmd.Parameters.AddWithValue("@Art_Id", id);
				await conn.OpenAsync();
				if (await cmd.ExecuteNonQueryAsync() > 0)
				{
					return Result<bool>.Success(true);
				}
				return Result<bool>.Failure("No se actualizó el stock del artículo general");
			}
			catch (SqlException ex)
			{
				return Result<bool>.Failure($"Error al actualizar el stock del artículo general: {ex.Message}");
			}
		}

	}
}
