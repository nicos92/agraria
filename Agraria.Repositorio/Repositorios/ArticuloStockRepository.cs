using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Data;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class ArticuloStockRepository : BaseRepositorio, IArticuloStockRepository
    {
        public async Task<Result<bool>> Add(Productos articulo, Stock stock)
        {

            SqlTransaction? transaction = null;
            try
            {
                SqlConnection conn = Conexion();
                await conn.OpenAsync();
              
                 transaction = (SqlTransaction)await conn.BeginTransactionAsync();


                // 1. Obtener el último Cod_Producto de la tabla Productos
                string sqlSelectMaxCod = "SELECT TOP 1 Cod_Producto FROM Productos WITH (UPDLOCK) ORDER BY Id_Producto DESC";
                string? ultimoCodProducto = null;
                using (SqlCommand cmdSelect = new (sqlSelectMaxCod, conn, transaction))
                {
                    object? result = await cmdSelect.ExecuteScalarAsync();
                    if (result != DBNull.Value && result != null)
                    {
                        ultimoCodProducto = result.ToString();
                    }
                }

                // 2. Generar el nuevo Cod_Producto
                string nuevoCodProducto;
                if (string.IsNullOrEmpty(ultimoCodProducto))
                {
                    // Si la tabla está vacía, el primer código será 'P001'
                    nuevoCodProducto = "P0000001";
                }
                else
                {
                    // Extraer el número del código, incrementarlo y formatearlo
                    string numeroStr = ultimoCodProducto.Substring(1); // "001"
                    int ultimoNumero = int.Parse(numeroStr);
                    int nuevoNumero = ultimoNumero + 1;
                    nuevoCodProducto = $"P{nuevoNumero:D7}"; // Formato "P001", "P002", etc.
                }
                string sqlArticulos = "INSERT INTO Productos (Cod_Producto, Producto_Desc, Id_Tipoentorno, Id_Entorno, Id_Proveedor) VALUES (@cod, @Desc, @Tipo, @Entorno, @proveedor)";
                using (SqlCommand cmdArticulos = new(sqlArticulos, conn, transaction))
                {
                  
                    cmdArticulos.Parameters.AddWithValue("@cod", nuevoCodProducto);
                    cmdArticulos.Parameters.AddWithValue("@Desc", articulo.Producto_Desc);
                    cmdArticulos.Parameters.AddWithValue("@Tipo", articulo.Id_Area);
                    cmdArticulos.Parameters.AddWithValue("@Entorno", articulo.Id_Entorno);
                    cmdArticulos.Parameters.AddWithValue("@proveedor", articulo.Id_Proveedor);
                    await cmdArticulos.ExecuteNonQueryAsync();
                }

             
                string sqlStock = "INSERT INTO Stock (Cod_Producto, Cantidad, Costo, Ganancia) VALUES (@Cod_Producto, @Cantidad, @costo, @Ganancia)";
                using (SqlCommand cmdStock = new(sqlStock, conn, transaction))
                {
                   
                    cmdStock.Parameters.AddWithValue("@Cod_Producto", nuevoCodProducto);
                    cmdStock.Parameters.Add("@Cantidad", SqlDbType.Decimal).Value = stock.Cantidad;
                    cmdStock.Parameters.Add("@costo", SqlDbType.Decimal).Value = stock.Costo;
                    cmdStock.Parameters.Add("@Ganancia", SqlDbType.Decimal).Value = stock.Ganancia;
                    await cmdStock.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
                return Result<bool>.Success(true); 
            }catch(SqlException ex)
            {
                if (transaction != null)
                {

                await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error SqlServer al insertar los Productos y los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error inesperado al insertar los Productos y los stocks: {ex.Message}"); 
            }
        }

        public async Task<Result<bool>> Delete(Productos articulo, Stock stock)
        {
            SqlTransaction? transaction = null;
            try
            {
                SqlConnection conn = Conexion();
                await conn.OpenAsync();

                transaction = (SqlTransaction)await conn.BeginTransactionAsync();


                // Eliminar Stock
                string sqlStock = "DELETE FROM Stock WHERE Cod_Producto = @Cod_producto";
                using (SqlCommand cmdStock = new(sqlStock, conn, transaction))
                {
                    cmdStock.Parameters.AddWithValue("@Cod_producto", stock.Cod_Articulo);
                    await cmdStock.ExecuteNonQueryAsync();
                }

                // Eliminar Productos
                string sqlArticulos = "DELETE FROM Productos WHERE Cod_Producto = @Cod_producto";
                using (SqlCommand cmdArticulos = new(sqlArticulos, conn, transaction))
                {
                    cmdArticulos.Parameters.AddWithValue("@Cod_producto", articulo.Cod_Producto);
                    await cmdArticulos.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
                return Result<bool>.Success(true);
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error SqlServer al eliminar los Productos y los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error inesperado al eliminar los Productos y los stocks: {ex.Message}");
            }

        }

        public async Task<Result<(List<Productos> articulos, List<Stock> stock)>> GetAll()
        {
            var listaArticulos = new List<Productos>();
            var listaStock = new List<Stock>();

            using (SqlConnection conn = Conexion())
            {
                try
                {
                    await conn.OpenAsync();

                    // 1. Obtener datos de la tabla Productos
                    string sqlArticulos = "SELECT Id_Producto, Cod_Producto, Producto_Desc, Id_Tipoentorno, Id_Entorno, Id_Proveedor FROM Productos ORDER BY Id_Producto DESC";
                    using (SqlCommand cmdArticulos = new(sqlArticulos, conn))
                    {
                        using DbDataReader reader = await cmdArticulos.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            var articulo = new Productos
                            {
                                Id_Producto = reader.GetInt32(0),
                                Cod_Producto = reader.GetString(1),
                                Producto_Desc = reader.GetString(2),
                                Id_Area = reader.GetInt32(3),
                                Id_Entorno = reader.GetInt32(4),
                                Id_Proveedor = reader.GetInt32(5)
                            };
                            listaArticulos.Add(articulo);
                        }
                    }

                    // 2. Obtener datos de la tabla Stock
                    string sqlStock = "SELECT Cod_Producto, Cantidad, Costo, Ganancia FROM Stock";
                    using SqlCommand cmdStock = new(sqlStock, conn);
                    using (DbDataReader reader = await cmdStock.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var stock = new Stock
                            {
                                Cod_Articulo = reader.GetString(0),
                                Cantidad = reader.GetDecimal(1),
                                Costo = reader.GetDecimal(2),
                                Ganancia = reader.GetDecimal(3)
                            };
                            listaStock.Add(stock);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al obtener datos: {ex.Message}");
                   
                    return Result<(List<Productos> articulos, List<Stock> stock)>.Failure("No se pudieron obtener las listas");
                }
            }

           
            return Result<(List<Productos> articulos, List<Stock> stock)>.Success((listaArticulos, listaStock));
        }

        public async Task<Result<List<ProductoStock>>> GetAllArticuloStock()
        {
            var listaArticulos = new List<ProductoStock>();

            using (SqlConnection conn = Conexion())
            {
                try
                {
                    await conn.OpenAsync();

                    // 1. Obtener datos de la tabla Productos
                    string sqlArticulos = "SELECT a.Id_Producto, a.Cod_Producto, a.Producto_Desc, a.Id_Tipoentorno, a.Id_Entorno, a.Id_Proveedor, s.cantidad, s.costo, s.ganancia FROM Productos a inner join stock s on a.Cod_Producto = s.Cod_Producto ";
                    using SqlCommand cmdArticulos = new(sqlArticulos, conn);
                    using DbDataReader reader = await cmdArticulos.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var articulo = new ProductoStock
                        (
                           reader.GetInt32(0),
                             reader.GetString(1),
                           reader.GetString(2),
                            reader.GetInt32(3),
                            reader.GetInt32(4),
                            reader.GetInt32(5),
                            reader.GetDecimal(6),
                            reader.GetDecimal(7),
                            reader.GetDecimal(8)



                        );
                        listaArticulos.Add(articulo);
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado al obtener datos: {ex.Message}");

                    return Result<List<ProductoStock>>.Failure("No se pudieron obtener las listas");
                }
            }


            return Result<List<ProductoStock>>.Success(listaArticulos);
        }

        public async Task<Result<bool>> Update(Productos articulos, Stock stock)
        {
            SqlTransaction? transaction = null;
            try
            {
                SqlConnection conn = Conexion();
                await conn.OpenAsync();

                transaction = (SqlTransaction)await conn.BeginTransactionAsync();


                // Actualizar Productos
                string sqlArticulos = "UPDATE Productos SET Producto_Desc = @Desc, Id_Tipoentorno = @tipo, Id_Entorno = @Entorno, Id_Proveedor = @id_proveedor WHERE Cod_Producto = @cod_producto";
                using (SqlCommand cmdArticulos = new(sqlArticulos, conn, transaction))
                {
                    cmdArticulos.Parameters.AddWithValue("@Desc", articulos.Producto_Desc);
                    cmdArticulos.Parameters.AddWithValue("@tipo", articulos.Id_Area);
                    cmdArticulos.Parameters.AddWithValue("@Entorno", articulos.Id_Entorno);
                    cmdArticulos.Parameters.AddWithValue("@id_proveedor", articulos.Id_Proveedor);
                    cmdArticulos.Parameters.AddWithValue("@cod_producto", articulos.Cod_Producto);
                    await cmdArticulos.ExecuteNonQueryAsync();
                }

                // Actualizar Stock
                string sqlStock = "UPDATE Stock SET Cantidad = @cant, Costo = @costo, Ganancia = @ganancia WHERE Cod_Producto = @cod_producto";
                using (SqlCommand cmdStock = new(sqlStock, conn, transaction))
                {
                    cmdStock.Parameters.AddWithValue("@cant", stock.Cantidad);
                    cmdStock.Parameters.AddWithValue("@costo", stock.Costo);
                    cmdStock.Parameters.AddWithValue("@ganancia", stock.Ganancia);
                    cmdStock.Parameters.AddWithValue("@cod_producto", stock.Cod_Articulo);
                    await cmdStock.ExecuteNonQueryAsync();
                }

                await transaction.CommitAsync();
                return Result<bool>.Success(true);
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error SqlServer al actualizar los Productos y los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error inesperado al actualizar los Productos y los stocks: {ex.Message}");
            }

        }
    }
}
