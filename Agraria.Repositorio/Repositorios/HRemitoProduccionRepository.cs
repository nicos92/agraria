using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using System.Text;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System.Data;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HRemitoProduccionRepository : BaseRepositorio, IHRemitoProduccionRepository
    {
        public async Task<Result<List<HRemitoProduccion>>> GetAll()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Remito, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total FROM H_Remito_Produccion", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<HRemitoProduccion> remitos = [];
                while (await reader.ReadAsync())
                {
                    HRemitoProduccion remito = new()
                    {
                        Id_Remito = reader.GetInt32(0),
                        Cod_Usuario = reader.GetInt32(1),
                        Fecha_Hora = reader.GetDateTime(2),
                        Subtotal = reader.GetDecimal(3),
                        Descu = reader.GetDecimal(4),
                        Total = reader.GetDecimal(5)
                    };
                    remitos.Add(remito);
                }
                return Result<List<HRemitoProduccion>>.Success(remitos);
            }
            catch (SqlException ex)
            {
                return Result<List<HRemitoProduccion>>.Failure("Error en la base de datos al obtener los remitos de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<HRemitoProduccion>>.Failure("Error inesperado al obtener los remitos de producción: " + ex.Message);
            }
        }

        public async Task<Result<HRemitoProduccion>> GetById(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Remito, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total FROM H_Remito_Produccion WHERE Id_Remito = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    HRemitoProduccion remito = new()
                    {
                        Id_Remito = reader.GetInt32(0),
                        Cod_Usuario = reader.GetInt32(1),
                        Fecha_Hora = reader.GetDateTime(2),
                        Subtotal = reader.GetDecimal(3),
                        Descu = reader.GetDecimal(4),
                        Total = reader.GetDecimal(5)
                    };
                    return Result<HRemitoProduccion>.Success(remito);
                }
                return Result<HRemitoProduccion>.Failure("Remito de producción no encontrado");
            }
            catch (SqlException ex)
            {
                return Result<HRemitoProduccion>.Failure("Error en la base de datos al obtener el remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HRemitoProduccion>.Failure("Error inesperado al obtener el remito de producción: " + ex.Message);
            }
        }

        public Result<HRemitoProduccion> Add(HRemitoProduccion remito)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("INSERT INTO H_Remito_Produccion (Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total) VALUES (@Cod_Usuario, @Fecha_Hora, @Subtotal, @Descu, @Total)", conn);
                cmd.Parameters.AddWithValue("@Cod_Usuario", remito.Cod_Usuario);
                cmd.Parameters.AddWithValue("@Fecha_Hora", remito.Fecha_Hora);
                cmd.Parameters.AddWithValue("@Subtotal", remito.Subtotal);
                cmd.Parameters.AddWithValue("@Descu", remito.Descu);
                cmd.Parameters.AddWithValue("@Total", remito.Total);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Get the ID of the inserted record
                    using SqlCommand cmdGetId = new("SELECT @@IDENTITY", conn);
                    object? idObj = cmdGetId.ExecuteScalar();
                    if (idObj != null && int.TryParse(idObj.ToString(), out int id))
                    {
                        remito.Id_Remito = id;
                    }
                    return Result<HRemitoProduccion>.Success(remito);
                }
                return Result<HRemitoProduccion>.Failure("No se pudo agregar el remito de producción");
            }
            catch (SqlException ex)
            {
                return Result<HRemitoProduccion>.Failure("Error en la base de datos al agregar el remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HRemitoProduccion>.Failure("Error inesperado al agregar el remito de producción: " + ex.Message);
            }
        }

        public Result<HRemitoProduccion> Update(HRemitoProduccion remito)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("UPDATE H_Remito_Produccion SET Cod_Usuario = @Cod_Usuario, Fecha_Hora = @Fecha_Hora,  Subtotal = @Subtotal, Descu = @Descu, Total = @Total WHERE Id_Remito = @Id", conn);
                cmd.Parameters.AddWithValue("@Cod_Usuario", remito.Cod_Usuario);
                cmd.Parameters.AddWithValue("@Fecha_Hora", remito.Fecha_Hora);
                cmd.Parameters.AddWithValue("@Subtotal", remito.Subtotal);
                cmd.Parameters.AddWithValue("@Descu", remito.Descu);
                cmd.Parameters.AddWithValue("@Total", remito.Total);
                cmd.Parameters.AddWithValue("@Id", remito.Id_Remito);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<HRemitoProduccion>.Success(remito);
                }
                return Result<HRemitoProduccion>.Failure("No se pudo actualizar el remito de producción");
            }
            catch (SqlException ex)
            {
                return Result<HRemitoProduccion>.Failure("Error en la base de datos al actualizar el remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HRemitoProduccion>.Failure("Error inesperado al actualizar el remito de producción: " + ex.Message);
            }
        }
        
        public Result<bool> Delete(int id)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new SqlCommand("DELETE FROM H_Remito_Produccion WHERE Id_Remito = ?", conexion);
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = id });
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0
                    ? Result<bool>.Success(true)
                    : Result<bool>.Failure("No se encontró el remito de producción para eliminar.");
            }
            catch (SqlException ex)
            {
                return Result<bool>.Failure($"Error en la base de datos al eliminar el remito de producción: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error inesperado al eliminar el remito de producción: {ex.Message}");
            }
        }

        public Result<List<HRemitoProduccion>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string cliente, int? idRemito)
        {
            try
            {
                var remitos = new List<HRemitoProduccion>();
                var query = new StringBuilder("SELECT r.Id_Remito, r.Cod_Usuario, r.Fecha_Hora, r.Subtotal, r.Descu, r.Total FROM H_Remito_Produccion r");
                var whereClause = new List<string>();
                var parameters = new List<SqlParameter>();

                // Filtro por rango de fechas - formato correcto para Access
                whereClause.Add("r.Fecha_Hora BETWEEN ? AND ?");
                parameters.Add(new SqlParameter("@fechaDesde", SqlDbType.Date) { Value = fechaDesde });
                parameters.Add(new SqlParameter("@fechaHasta", SqlDbType.Date) { Value = fechaHasta });

                // Filtro por ID de remito si se proporciona
                if (idRemito.HasValue)
                {
                    whereClause.Add("r.Id_Remito = ?");
                    parameters.Add(new SqlParameter("@idRemito", SqlDbType.Int) { Value = idRemito.Value });
                }

                // Filtro por nombre de cliente si se proporciona
                // Nota: En este caso, asumimos que no hay tabla de clientes para remitos de producción
                // Si se agregara, se podría hacer un JOIN similar al de ventas

                // Agregar cláusula WHERE si hay filtros
                if (whereClause.Count > 0)
                {
                    query.Append(" WHERE ");
                    query.Append(string.Join(" AND ", whereClause));
                }

                // Ordenar por fecha descendente
                query.Append(" ORDER BY r.Fecha_Hora DESC");

                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new SqlCommand(query.ToString(), conexion);
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        remitos.Add(new HRemitoProduccion
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Fecha_Hora = reader.GetDateTime(2),
                            Subtotal = reader.GetDecimal(4),
                            Descu = reader.GetDecimal(5),
                            Total = reader.GetDecimal(6)
                        });
                    }
                }

                return Result<List<HRemitoProduccion>>.Success(remitos);
            }
            catch (SqlException ex)
            {
                return Result<List<HRemitoProduccion>>.Failure($"Error al filtrar remitos de producción: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<HRemitoProduccion>>.Failure($"Error inesperado al filtrar remitos de producción: {ex.Message}");
            }
        }
    }
}