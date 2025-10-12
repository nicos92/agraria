using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class ProductoRepository : BaseRepositorio, IProductosRepository
    {
        public Result<Productos> Add(Productos articulo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("INSERT INTO Productos (Cod_Producto, Producto_Desc, Id_TipoEntorno, Id_Entorno, Id_Proveedor) VALUES (@Cod_Producto, @Producto_Desc, @Id_TipoEntorno, @Id_Entorno, @Id_Proveedor)", conn);

                cmd.Parameters.AddWithValue("@Cod_Producto", articulo.Cod_Producto);
                cmd.Parameters.AddWithValue("@Producto_Desc", articulo.Producto_Desc);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", articulo.Id_Area);
                cmd.Parameters.AddWithValue("@Id_Entorno", articulo.Id_Entorno);
                cmd.Parameters.AddWithValue("@Id_Proveedor", articulo.Id_Proveedor);
                conn.Open();
                int inserts = cmd.ExecuteNonQuery();

                if (inserts > 0)
                {
                    return Result<Productos>.Success(articulo);
                }
                else
                {
                    return Result<Productos>.Failure("No se pudo agregar el artículo.");
                }
            }
            catch (SqlException ex)
            {

                return Result<Productos>.Failure($"Error al agregar el artículo: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("DELETE FROM Productos WHERE Id_Articulo = @Id_Articulo", conn);
                cmd.Parameters.AddWithValue("@Id_Articulo", id);
                conn.Open();
                int deletes = cmd.ExecuteNonQuery();
                if (deletes > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar el artículo.");
                }
            }
            catch (SqlException ex)
            {

                return Result<bool>.Failure($"Error al eliminar el araticulo: \n {ex.Message}");
            }
        }

        public async Task<Result<List<Productos>>> GetAll()
        {
            try
            {
                List<Productos> articulos = [];
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT Id_Producto, Cod_Producto, Producto_Desc, Id_TipoEntorno, Id_Entorno, Id_Proveedor FROM Productos ORDER BY Id_Producto DESC", conn);
                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Productos articulo = new()
                    {
                        Id_Producto = reader.GetInt32(0),
                        Cod_Producto = reader.GetString(1),
                        Producto_Desc = reader.GetString(2),
                        Id_Area = reader.GetInt32(3),
                        Id_Entorno = reader.GetInt32(4),
                        Id_Proveedor = reader.GetInt32(5)
                    };
                    articulos.Add(articulo);
                }
                return Result<List<Productos>>.Success(articulos);
            }
            catch (SqlException ex)
            {

                return Result<List<Productos>>.Failure($"Error al obtener los artículos: {ex.Message}");
            }
        }

        public async Task<Result<List<ProductosMasVendidos>>> GetProductosMasVendidos(int top)
        {
            try
            {
                var productos = new List<ProductosMasVendidos>();
                using var conn = Conexion();
                await conn.OpenAsync();

                // Query to get top selling products
                // Join Productos with H_Ventas_Detalle to get sales information
                string sql = @"
                    SELECT TOP (@top)
                        p.Cod_Producto,
                        p.Producto_Desc,
                        SUM(vd.Cant) as CantidadVendida,
                        SUM(vd.P_X_Cant) as TotalVendido
                    FROM Productos p
                    INNER JOIN H_Ventas_Detalle vd ON p.Cod_Producto = vd.Cod_Art
                    INNER JOIN H_Ventas v ON vd.Id_Remito = v.Id_Remito
                    GROUP BY p.Cod_Producto, p.Producto_Desc
                    ORDER BY SUM(vd.Cant) DESC";

                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@top", top);

                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    productos.Add(new ProductosMasVendidos
                    {
                        Cod_Producto = reader.IsDBNull(0) ? null : reader.GetString(0),
                        Producto_Desc = reader.IsDBNull(1) ? null : reader.GetString(1),
                        CantidadVendida = reader.GetDecimal(2),
                        TotalVendido = reader.GetDecimal(3)
                    });
                }

                return Result<List<ProductosMasVendidos>>.Success(productos);
            }
            catch (SqlException ex)
            {
                return Result<List<ProductosMasVendidos>>.Failure($"Error al obtener productos más vendidos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<ProductosMasVendidos>>.Failure($"Error inesperado al obtener productos más vendidos: {ex.Message}");
            }
        }

        public Result<Productos> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT Id_Articulo, Cod_Producto, Producto_Desc, Id_TipoEntorno, Id_Entorno, Id_Proveedor FROM Productos WHERE Id_Articulo = @Id_Articulo", conn);
                cmd.Parameters.AddWithValue("@Id_Articulo", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Productos articulo = new()
                    {
                        Id_Producto = reader.GetInt32(0),
                        Cod_Producto = reader.GetString(1),
                        Producto_Desc = reader.GetString(2),
                        Id_Area = reader.GetInt32(3),
                        Id_Entorno = reader.GetInt32(4),
                        Id_Proveedor = reader.GetInt32(5)

                    };
                    return Result<Productos>.Success(articulo);
                }
                return Result<Productos>.Failure($"No se pude obtener el articulo");
            }
            catch (SqlException ex)
            {

                return Result<Productos>.Failure($"Error al obtener articulo: {ex.Message}");
            }
        }

        public async Task<Result<int>> GetMaxCodArt()
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT MAX(Cod_Producto) FROM Productos", conn);
                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    int max = Convert.ToInt32(reader.GetString(0));
                    return Result<int>.Success(max);
                }
                return Result<int>.Failure($"No se pude obtener el ultimo codigo de los Productos");
            }
            catch (SqlException ex)
            {

                return Result<int>.Failure($"Error en la base de datos al obtener  el ultimo codigo de los Productos: {ex.Message}");
            }
            catch (Exception ex)
            {
                return Result<int>.Failure("Error inesperado al obtener el ultimo codigo de los Productos" + ex.Message);
            }
        }

        public async Task<Result<Productos>> Update(Productos articulo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("UPDATE Productos set Cod_Producto=@Cod_Producto, Producto_Desc=@Producto_Desc, Id_TipoEntorno=@Id_TipoEntorno, Id_Entorno=@Cod_Sucat, Id_Proveedor = @Id_Proveedor WHERE Id_Articulo = @Id_Articulo", conn);
                cmd.Parameters.AddWithValue("@Cod_Producto", articulo.Cod_Producto);
                cmd.Parameters.AddWithValue("@Producto_Desc", articulo.Producto_Desc);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", articulo.Id_Area);
                cmd.Parameters.AddWithValue("@Cod_Sucat", articulo.Id_Entorno);
                cmd.Parameters.AddWithValue("@Id_Proveedor", articulo.Id_Proveedor);
                cmd.Parameters.AddWithValue("@Id_Articulo", articulo.Id_Producto);
                await conn.OpenAsync();
                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    return Result<Productos>.Success(articulo);
                }
                return Result<Productos>.Failure($"No se actualizo el articulo");
            }
            catch (SqlException ex)
            {

                return Result<Productos>.Failure($"Error al actualizar el articulo: \n {ex.Message}");
            }
        }
    }
}
