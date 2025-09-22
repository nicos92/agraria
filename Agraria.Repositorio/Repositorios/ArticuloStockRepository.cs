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

         
                string sqlArticulos = "INSERT INTO Articulos (Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor) VALUES (?, ?, ?, ?, ?)";
                using (SqlCommand cmdArticulos = new(sqlArticulos, conn, transaction))
                {
                  
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Cod_Producto);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Producto_Desc);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Id_TipoEntorno);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Id_Entorno);
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Id_Proveedor);
                    await cmdArticulos.ExecuteNonQueryAsync();
                }

             
                string sqlStock = "INSERT INTO Stock (Cod_Articulo, Cantidad, Costo, Ganancia) VALUES (?, ?, ?, ?)";
                using (SqlCommand cmdStock = new(sqlStock, conn, transaction))
                {
                   
                    cmdStock.Parameters.AddWithValue("?", stock.Cod_Articulo);
                    cmdStock.Parameters.Add("?", SqlDbType.Decimal).Value = stock.Cantidad;
                    cmdStock.Parameters.Add("?", SqlDbType.Decimal).Value = stock.Costo;
                    cmdStock.Parameters.Add("?", SqlDbType.Decimal).Value = stock.Ganancia;
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
                return Result<bool>.Failure($"Error OleDb al insertar los articulos y los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error inesperado al insertar los articulos y los stocks: {ex.Message}"); 
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
                string sqlStock = "DELETE FROM Stock WHERE Cod_Articulo = ?";
                using (SqlCommand cmdStock = new(sqlStock, conn, transaction))
                {
                    cmdStock.Parameters.AddWithValue("?", stock.Cod_Articulo);
                    await cmdStock.ExecuteNonQueryAsync();
                }

                // Eliminar Articulos
                string sqlArticulos = "DELETE FROM Articulos WHERE Cod_Articulo = ?";
                using (SqlCommand cmdArticulos = new(sqlArticulos, conn, transaction))
                {
                    cmdArticulos.Parameters.AddWithValue("?", articulo.Cod_Producto);
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
                return Result<bool>.Failure($"Error OleDb al eliminar los articulos y los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error inesperado al eliminar los articulos y los stocks: {ex.Message}");
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

                    // 1. Obtener datos de la tabla Articulos
                    string sqlArticulos = "SELECT Id_Articulo, Cod_Articulo, Art_Desc, Cod_Categoria, Cod_Subcat, Id_Proveedor FROM Articulos";
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
                                Id_TipoEntorno = reader.GetInt32(3),
                                Id_Entorno = reader.GetInt32(4),
                                Id_Proveedor = reader.GetInt32(5)
                            };
                            listaArticulos.Add(articulo);
                        }
                    }

                    // 2. Obtener datos de la tabla Stock
                    string sqlStock = "SELECT Cod_Articulo, Cantidad, Costo, Ganancia FROM Stock";
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

        public async Task<Result<List<ArticuloStock>>> GetAllArticuloStock()
        {
            var listaArticulos = new List<ArticuloStock>();

            using (SqlConnection conn = Conexion())
            {
                try
                {
                    await conn.OpenAsync();

                    // 1. Obtener datos de la tabla Articulos
                    string sqlArticulos = "SELECT a.Id_Articulo, a.Cod_Articulo, a.Art_Desc, a.Cod_Categoria, a.Cod_Subcat, a.Id_Proveedor, s.cantidad, s.costo, s.ganancia FROM Articulos a inner join stock s on a.cod_articulo = s.Cod_Articulo ";
                    using SqlCommand cmdArticulos = new(sqlArticulos, conn);
                    using DbDataReader reader = await cmdArticulos.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        var articulo = new ArticuloStock
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

                    return Result<List<ArticuloStock>>.Failure("No se pudieron obtener las listas");
                }
            }


            return Result<List<ArticuloStock>>.Success(listaArticulos);
        }

        public async Task<Result<bool>> Update(Productos articulos, Stock stock)
        {
            SqlTransaction? transaction = null;
            try
            {
                SqlConnection conn = Conexion();
                await conn.OpenAsync();

                transaction = (SqlTransaction)await conn.BeginTransactionAsync();


                // Actualizar Articulos
                string sqlArticulos = "UPDATE Articulos SET Art_Desc = ?, Cod_Categoria = ?, Cod_Subcat = ?, Id_Proveedor = ? WHERE Cod_Articulo = ?";
                using (SqlCommand cmdArticulos = new(sqlArticulos, conn, transaction))
                {
                    cmdArticulos.Parameters.AddWithValue("?", articulos.Producto_Desc);
                    cmdArticulos.Parameters.AddWithValue("?", articulos.Id_TipoEntorno);
                    cmdArticulos.Parameters.AddWithValue("?", articulos.Id_Entorno);
                    cmdArticulos.Parameters.AddWithValue("?", articulos.Id_Proveedor);
                    cmdArticulos.Parameters.AddWithValue("?", articulos.Cod_Producto);
                    await cmdArticulos.ExecuteNonQueryAsync();
                }

                // Actualizar Stock
                string sqlStock = "UPDATE Stock SET Cantidad = ?, Costo = ?, Ganancia = ? WHERE Cod_Articulo = ?";
                using (SqlCommand cmdStock = new(sqlStock, conn, transaction))
                {
                    cmdStock.Parameters.AddWithValue("?", stock.Cantidad);
                    cmdStock.Parameters.AddWithValue("?", stock.Costo);
                    cmdStock.Parameters.AddWithValue("?", stock.Ganancia);
                    cmdStock.Parameters.AddWithValue("?", stock.Cod_Articulo);
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
                return Result<bool>.Failure($"Error OleDb al actualizar los articulos y los stocks: {ex.Message}");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {

                    await transaction.RollbackAsync();
                }
                return Result<bool>.Failure($"Error inesperado al actualizar los articulos y los stocks: {ex.Message}");
            }

        }
    }
}
