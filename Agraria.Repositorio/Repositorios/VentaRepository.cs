using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class VentaRepository : BaseRepositorio, IVentaRepository
    {
        public async Task<Result<bool>> Add(HVentas hVentas, List<ProductoResumen> productoResumen)
        {
            SqlTransaction? transaction = null;
            try
            {
                using SqlConnection conn = Conexion();
                await conn.OpenAsync();

                transaction = (SqlTransaction)await conn.BeginTransactionAsync();


                string sqlArticulos = "INSERT INTO H_Ventas (Cod_Usuario, subtotal, descu, total, descripcion) VALUES (@cod_usuario, @subtotal, @descu, @total, @descripcion)";
                using (SqlCommand cmdArticulos = new(sqlArticulos, conn, transaction))
                {

                    cmdArticulos.Parameters.AddWithValue("@cod_usuario", hVentas.Cod_Usuario);
                    cmdArticulos.Parameters.AddWithValue("@subtotal", hVentas.Subtotal);
                    cmdArticulos.Parameters.AddWithValue("@descu", hVentas.Descu);
                    cmdArticulos.Parameters.AddWithValue("@total", hVentas.Total);
                    cmdArticulos.Parameters.AddWithValue("@descripcion", hVentas.Descripcion ?? "");

                    await cmdArticulos.ExecuteNonQueryAsync();
                }
                string select = "SELECT MAX(id_remito) FROM H_Ventas";
                using SqlCommand oleDbCommand = new(select, conn, transaction);
                using DbDataReader reader = await oleDbCommand.ExecuteReaderAsync();
                int id_remito = 0;
                if (await reader.ReadAsync())
                {
                    id_remito = reader.GetInt32(0);
                }

                if (id_remito == 0)
                {
                    await transaction.RollbackAsync();
                    return Result<bool>.Failure("No se pudo obtener el número de remito");
                }
                await reader.CloseAsync();
                foreach (var item in productoResumen)
                {
                    string sqlStock = "INSERT INTO H_Ventas_Detalle (id_remito, cod_producto, descr, p_unit, cant, p_x_cant) VALUES (@id_remito, @cor_art, @descr, @p_unit, @cant, @pxcant)";
                    using SqlCommand cmdStock = new(sqlStock, conn, transaction);

                    cmdStock.Parameters.AddWithValue("@id_remito", id_remito);
                    cmdStock.Parameters.AddWithValue("@cor_art", item.Cod_Articulo);
                    cmdStock.Parameters.AddWithValue("@descr", item.Producto_Nombre);
                    cmdStock.Parameters.AddWithValue("@p_unit", item.Producto_Precio);
                    cmdStock.Parameters.AddWithValue("@cant", item.Producto_Cantidad);
                    cmdStock.Parameters.AddWithValue("@pxcant", item.Producto_PrecioxCantidad);

                    await cmdStock.ExecuteNonQueryAsync();

                    string cmdARt = "UPDATE Stock SET cantidad = cantidad - @cant WHERE cod_Producto = @cod_art";
                    using SqlCommand oleDbCommand1 = new(cmdARt, conn, transaction);
                    oleDbCommand1.Parameters.AddWithValue("@cant", item.Producto_Cantidad);
                    oleDbCommand1.Parameters.AddWithValue("@cod_art", item.Cod_Articulo);
                    await oleDbCommand1.ExecuteNonQueryAsync();
                }


                await transaction.CommitAsync();
                return Result<bool>.Success(true);
            }
            catch (SqlException ex)
            {
                transaction?.RollbackAsync();
                return Result<bool>.Failure($"Error sqlserver al insertar la venta y los detalles: {ex.Message}");
            }
            catch (Exception ex)
            {
                transaction?.RollbackAsync();
                return Result<bool>.Failure($"Error inesperado al insertar la venta y los detalles: {ex.Message}");
            }
        }

        public async Task<Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>> GetAll()
        {
            try
            {
                using SqlConnection conn = Conexion();
                await conn.OpenAsync();

                List<HVentas> ventas = [];
                List<HVentasDetalle> detalles = [];

                // Query para obtener todas las ventas (H_Ventas)
                string sqlVentas = "SELECT id_remito, Cod_Usuario, fecha_hora, subtotal, descu, total, descripcion FROM H_Ventas";
                using (SqlCommand cmdVentas = new(sqlVentas, conn))
                {
                    using DbDataReader reader = await cmdVentas.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        ventas.Add(new HVentas
                        {
                            Id_Remito = reader.GetInt32(0),
                            Cod_Usuario = reader.GetInt32(1),
                            Fecha_Hora = reader.GetDateTime(2),
                            Subtotal = reader.GetDecimal(3),
                            Descu = reader.GetDecimal(4),
                            Total = reader.GetDecimal(5),
                            Descripcion = reader.GetString(6)
                        });
                    }
                }

                // Query para obtener todos los detalles de las ventas (H_Ventas_Detalle)
                string sqlDetalles = "SELECT id_det_remito, id_remito, cod_art, descr, p_unit, cant, p_x_cant FROM H_Ventas_Detalle";
                using (SqlCommand cmdDetalles = new(sqlDetalles, conn))
                {
                    using DbDataReader reader = await cmdDetalles.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        detalles.Add(new HVentasDetalle
                        {
                            Id_Det_Remito = reader.GetInt32(0),
                            Id_Remito = reader.GetInt32(1),
                            Cod_Articulo = reader.GetString(2),
                            Descr = reader.GetString(3),
                            P_Unit = reader.GetDecimal(4),
                            Cant = reader.GetInt32(5),
                            P_X_Cant = reader.GetDecimal(6),

                        });
                    }
                }

                return Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>.Success((ventas, detalles));
            }
            catch (SqlException ex)
            {
                return Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>.Failure($"Error OleDb al obtener las ventas: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<(List<HVentas> ventas, List<HVentasDetalle> detalles)>.Failure($"Error inesperado al obtener las ventas: {ex.Message}");
            }
        }


      

        public async Task<Result<List<HVentas>>> GetVentasGrandes(int top = 10)
        {
            try
            {
                var ventas = new List<HVentas>();
                using var conn = Conexion();
                await conn.OpenAsync();

                // Query to get top sales by total amount
                string sql = @"
                    SELECT TOP (@top)
                        Id_Remito, Cod_Usuario, Fecha_Hora, Subtotal, Descu, Total, Descripcion
                    FROM H_Ventas
                    ORDER BY Total DESC";

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@top", top);

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    ventas.Add(new HVentas
                    {
                        Id_Remito = reader.GetInt32(0),
                        Cod_Usuario = reader.GetInt32(1),
                        Fecha_Hora = reader.GetDateTime(2),
                        Subtotal = reader.GetDecimal(3),
                        Descu = reader.GetDecimal(4),
                        Total = reader.GetDecimal(5),
                        Descripcion = reader.IsDBNull(6) ? null : reader.GetString(6)
                    });
                }

                return Result<List<HVentas>>.Success(ventas);
            }
            catch (SqlException ex)
            {
                return Result<List<HVentas>>.Failure($"Error al obtener ventas grandes: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<HVentas>>.Failure($"Error inesperado al obtener ventas grandes: {ex.Message}");
            }
        }
    }
}
