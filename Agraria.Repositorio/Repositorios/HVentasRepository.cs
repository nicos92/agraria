using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.Versioning;
using System.Text;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HVentasRepository : BaseRepositorio, IHVentasRepository
    {
        public Result<HVentas> Add(HVentas venta)
        {
            try
            {
                using var conexion = Conexion();
                using var cmd = new OleDbCommand("INSERT INTO H_Ventas (Cod_Usuario,  Subtotal, Descu, Total, Fecha_Hora) VALUES (@Cod_Usuario, @Subtotal, @Descu, @Total, @Fecha_Hora)", conexion);
                cmd.Parameters.AddWithValue("@Cod_Usuario", venta.Cod_Usuario);
                cmd.Parameters.Add("@Subtotal", OleDbType.Decimal).Value = venta.Subtotal;
                cmd.Parameters.Add("@Descu", OleDbType.Decimal).Value = venta.Descu;
                cmd.Parameters.Add("@Total", OleDbType.Decimal).Value = venta.Total;
                cmd.Parameters.AddWithValue("@Fecha_Hora", venta.Fecha_Hora);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    // Get the ID of the inserted record
                    using var cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion);
                    int id = Convert.ToInt32(cmdId.ExecuteScalar());
                    venta.Id_Remito = id;
                    return Result<HVentas>.Success(venta);
                }
                else
                {
                    return Result<HVentas>.Failure("No se pudo agregar la venta.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<HVentas>.Failure($"Error al agregar venta: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<HVentas>.Failure($"Error inesperado al agregar venta: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Result<List<HVentas>> GetAll()
        {
            try
            {
                var ventas = new List<HVentas>();
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Subtotal,Descu,Total, fecha_hora FROM H_Ventas", conexion);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ventas.Add(new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Subtotal = reader.GetDecimal(2),
                            Descu = reader.GetDecimal(3),
                            Total = reader.GetDecimal(4),
                            Fecha_Hora = reader.GetDateTime(5)
                        });
                    }
                }
                return Result<List<HVentas>>.Success(ventas);
            }
            catch (OleDbException ex)
            {
                return Result<List<HVentas>>.Failure($"Error al obtener ventas: {ex.Message}");
            }
        }

        public Result<HVentas> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT Id_Remito,Cod_Usuario,Fecha_Hora,Subtotal,Descu,Total FROM H_Ventas WHERE Id_Remito = @id", conexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var venta = new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Fecha_Hora = reader.GetDateTime(2),
                            Subtotal = reader.GetDecimal(3),
                            Descu = reader.GetDecimal(4),
                            Total = reader.GetDecimal(5)
                        };
                        return Result<HVentas>.Success(venta);
                    }
                }
                return Result<HVentas>.Failure("Venta no encontrada");
            }
            catch (OleDbException ex)
            {
                return Result<HVentas>.Failure($"Error al obtener venta {ex.Message}");
			}
        }

        public Result<HVentas> Update(HVentas venta)
        {
            try
            {
                using var conexion = Conexion();
                using var cmd = new OleDbCommand("UPDATE H_Ventas SET Cod_Usuario = @Cod_Usuario, Subtotal = @Subtotal, Descu = @Descu, Total = @Total, Fecha_Hora = @Fecha_Hora WHERE Id_Remito = @Id_Remito", conexion);
                cmd.Parameters.AddWithValue("@Id_Remito", venta.Id_Remito);
                cmd.Parameters.AddWithValue("@Cod_Usuario", venta.Cod_Usuario);
                cmd.Parameters.Add("@Subtotal", OleDbType.Decimal).Value = venta.Subtotal;
                cmd.Parameters.Add("@Descu", OleDbType.Decimal).Value = venta.Descu;
                cmd.Parameters.Add("@Total", OleDbType.Decimal).Value = venta.Total;
                cmd.Parameters.AddWithValue("@Fecha_Hora", venta.Fecha_Hora);
                conexion.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return Result<HVentas>.Success(venta);
                }
                else
                {
                    return Result<HVentas>.Failure("No se pudo actualizar la venta.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<HVentas>.Failure($"Error al actualizar venta: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<HVentas>.Failure($"Error inesperado al actualizar venta: {ex.Message}");
            }
        }

        public Result<List<HVentas>> GetFiltered(DateTime fechaDesde, DateTime fechaHasta, string cliente, int? idRemito)
        {
            try
            {
                var ventas = new List<HVentas>();
                var query = new StringBuilder("SELECT v.Id_Remito, v.Cod_Usuario, v.Fecha_Hora, v.Subtotal, v.Descu, v.Total FROM H_Ventas v");
                var whereClause = new List<string>();
                var parameters = new List<OleDbParameter>();

                // Filtro por rango de fechas - formato correcto para Access
                whereClause.Add("v.Fecha_Hora BETWEEN ? AND ?");
                parameters.Add(new OleDbParameter("@fechaDesde", OleDbType.Date) { Value = fechaDesde });
                parameters.Add(new OleDbParameter("@fechaHasta", OleDbType.Date) { Value = fechaHasta });

                // Filtro por ID de remito si se proporciona
                if (idRemito.HasValue)
                {
                    whereClause.Add("v.Id_Remito = ?");
                    parameters.Add(new OleDbParameter("@idRemito", OleDbType.Integer) { Value = idRemito.Value });
                }

              // Agregar cláusula WHERE si hay filtros
                if (whereClause.Count > 0)
                {
                    query.Append(" WHERE ");
                    query.Append(string.Join(" AND ", whereClause));
                }

                // Ordenar por fecha descendente
                query.Append(" ORDER BY v.Fecha_Hora DESC");

                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand(query.ToString(), conexion);
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ventas.Add(new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Fecha_Hora = reader.GetDateTime(2),
                            Subtotal = reader.GetDecimal(3),
                            Descu = reader.GetDecimal(4),
                            Total = reader.GetDecimal(5)
                        });
                    }
                }

                return Result<List<HVentas>>.Success(ventas);
            }
            catch (OleDbException ex)
            {
                return Result<List<HVentas>>.Failure($"Error al filtrar ventas: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<HVentas>>.Failure($"Error inesperado al filtrar ventas: {ex.Message}");
            }
        }
    }
}
