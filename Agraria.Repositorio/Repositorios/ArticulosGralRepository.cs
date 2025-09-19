using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class ArticulosGralRepository : BaseRepositorio, IArticulosGralRepository
    {
        public Result<ArticulosGral> Add(ArticulosGral articulo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("INSERT INTO ArticulosGral (Art_Cod, Art_Nombre, Art_Uni_Med, Art_Precio, Art_Descripcion, Art_Stock) VALUES (@Art_Cod, @Art_Nombre, @Art_Uni_Med, @Art_Precio, @Art_Descripcion, @Art_Stock)", conn);

                cmd.Parameters.AddWithValue("@Art_Cod", articulo.Art_Cod ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Nombre", articulo.Art_Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Uni_Med", articulo.Art_Uni_Med ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Precio", articulo.Art_Precio);
                cmd.Parameters.AddWithValue("@Art_Descripcion", articulo.Art_Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Stock", articulo.Art_Stock);
                
                conn.Open();
                int inserts = cmd.ExecuteNonQuery();

                if (inserts > 0)
                {
                    return Result<ArticulosGral>.Success(articulo);
                }
                else
                {
                    return Result<ArticulosGral>.Failure("No se pudo agregar el artículo general.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<ArticulosGral>.Failure($"Error al agregar el artículo general: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("DELETE FROM ArticulosGral WHERE Art_Id = @Art_Id", conn);
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
            catch (OleDbException ex)
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
                using var cmd = new OleDbCommand("SELECT Art_Id, Art_Cod, Art_Nombre, Art_Unidad_Media, Art_Precio, Art_Descripcion, Art_Stock FROM ArticulosGral", conn);
                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    ArticulosGral articulo = new ArticulosGral
                    {
                        Art_Id = reader.GetInt32(0),
                        Art_Cod = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Art_Nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Art_Uni_Med = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Art_Precio = reader.GetDecimal(4),
                        Art_Descripcion = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Art_Stock = reader.GetInt32(6)
                    };
                    articulos.Add(articulo);
                }
                return Result<List<ArticulosGral>>.Success(articulos);
            }
            catch (OleDbException ex)
            {
                return Result<List<ArticulosGral>>.Failure($"Error al obtener los artículos generales: {ex.Message}");
            }
        }

        public Result<ArticulosGral> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("SELECT Art_Id, Art_Cod, Art_Nombre, Art_Uni_Med, Art_Precio, Art_Descripcion, Art_Stock FROM ArticulosGral WHERE Art_Id = @Art_Id", conn);
                cmd.Parameters.AddWithValue("@Art_Id", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    ArticulosGral articulo = new ArticulosGral
                    {
                        Art_Id = reader.GetInt32(0),
                        Art_Cod = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Art_Nombre = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Art_Uni_Med = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Art_Precio = reader.GetDecimal(4),
                        Art_Descripcion = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Art_Stock = reader.GetInt32(6)
                    };
                    return Result<ArticulosGral>.Success(articulo);
                }
                return Result<ArticulosGral>.Failure("No se pudo obtener el artículo general");
            }
            catch (OleDbException ex)
            {
                return Result<ArticulosGral>.Failure($"Error al obtener artículo general: {ex.Message}");
            }
        }

        public async Task<Result<int>> GetMaxCodArt()
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("SELECT MAX(Art_Cod) FROM ArticulosGral", conn);
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
            catch (OleDbException ex)
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
                using var cmd = new OleDbCommand("UPDATE ArticulosGral SET Art_Cod=@Art_Cod, Art_Nombre=@Art_Nombre, Art_Uni_Med=@Art_Uni_Med, Art_Precio=@Art_Precio, Art_Descripcion=@Art_Descripcion, Art_Stock=@Art_Stock WHERE Art_Id = @Art_Id", conn);
                cmd.Parameters.AddWithValue("@Art_Cod", articulo.Art_Cod ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Nombre", articulo.Art_Nombre ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Uni_Med", articulo.Art_Uni_Med ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Precio", articulo.Art_Precio);
                cmd.Parameters.AddWithValue("@Art_Descripcion", articulo.Art_Descripcion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Art_Stock", articulo.Art_Stock);
                cmd.Parameters.AddWithValue("@Art_Id", articulo.Art_Id);
                await conn.OpenAsync();
                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    return Result<ArticulosGral>.Success(articulo);
                }
                return Result<ArticulosGral>.Failure("No se actualizó el artículo general");
            }
            catch (OleDbException ex)
            {
                return Result<ArticulosGral>.Failure($"Error al actualizar el artículo general: {ex.Message}");
            }
        }
    }
}