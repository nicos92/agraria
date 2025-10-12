using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class EntornoRepository : BaseRepositorio, IEntornoRepository
    {
        public async Task<Result<List<Entorno>>> GetAll()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Entorno, Nombre, Id_TipoEntorno FROM Entorno", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Entorno> subcategorias = [];
                while (await reader.ReadAsync())
                {
                    Entorno subcategoria = new()
                    {
                        Id_Entorno = reader.GetInt32(0),
                        Entorno_nombre = reader.GetString(1),
                        Id_Area = reader.GetInt32(2)
                    };
                    subcategorias.Add(subcategoria);
                }
                return Result<List<Entorno>>.Success(subcategorias);
            }
            catch (SqlException ex)
            {
                // Handle database exceptions and return an appropriate Result
                return Result<List<Entorno>>.Failure("Error en la base de datos al obtener lo Entornos: " + ex.Message   );
            }
            catch (Exception ex)
            {
                return Result<List<Entorno>>.Failure("Error al obtener los Entornos: " + ex.Message);
            }
        }

        public Result<Entorno> GetById(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Entorno, Nombre, Id_TipoEntorno FROM Entorno WHERE Id_Entorno = @Id_Entorno", conn);
                cmd.Parameters.AddWithValue("@Id_Entorno", id);
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Entorno subcategoria = new()
                    {
                        Id_Entorno = reader.GetInt32(0),
                        Entorno_nombre = reader.GetString(1),
                        Id_Area = reader.GetInt32(2)
                    };
                    return Result<Entorno>.Success(subcategoria);
                }
                return Result<Entorno>.Failure("No se pudo encontrar el Entorno con el ID especificado.");
            }catch(SqlException ex)
            {
                return Result<Entorno>.Failure("Error en la base de datos al obtener el Entorno: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Entorno>.Failure("Error inesperado al obtener el Entorno: " + ex.Message);
            }
        }

        public Result<Entorno> Add(Entorno subcategoria)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("INSERT INTO Entorno (Nombre, Id_TipoEntorno) VALUES (@Nombre, @Id_TipoEntorno)", conn);
                cmd.Parameters.AddWithValue("@Nombre", subcategoria.Entorno_nombre);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", subcategoria.Id_Area);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Entorno>.Success(subcategoria);
                }
                return Result<Entorno>.Failure("No se pudo agregar el Entorno.");
            }catch (SqlException ex)
            {
                return Result<Entorno>.Failure("Error en la base de datos al agregar el Entorno: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Entorno>.Failure("Error inesperado al agregar el Entorno: " + ex.Message);
            }
            
        }

        public Result<Entorno> Update(Entorno subcategoria)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("UPDATE Entorno SET Nombre = @Nombre, Id_TipoEntorno = @Id_TipoEntorno WHERE Id_Entorno = @Id_Entorno", conn);
                cmd.Parameters.AddWithValue("@Nombre", subcategoria.Entorno_nombre);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", subcategoria.Id_Area);
                cmd.Parameters.AddWithValue("@Id_Entorno", subcategoria.Id_Entorno);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Entorno>.Success(subcategoria);
                }
                return Result<Entorno>.Failure("No se pudo actualizar el Entorno.");
            }catch (SqlException ex)
            {
                return Result<Entorno>.Failure("Error en la base de datos al actualizar el Entorno: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Entorno>.Failure("Error inesperado al actualizar el Entorno: " + ex.Message);
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("DELETE FROM Entorno WHERE Id_Entorno = @Id_Entorno", conn);
                cmd.Parameters.AddWithValue("@Id_Entorno", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar el Entorno.");
            }catch (SqlException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar el Entorno: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar el Entorno: " + ex.Message);
            }
        }

        public async Task<Result<List<Entorno>>> GetAllxCategoria(int idcategoria)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("SELECT Id_Entorno, Nombre, Id_TipoEntorno FROM Entorno WHERE Id_TipoEntorno = @Id_TipoEntorno", conn);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", idcategoria);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Entorno> subcategorias = [];
                while (await reader.ReadAsync())
                {
                    Entorno subcategoria = new ()
                    {
                        Id_Entorno = reader.GetInt32(0),
                        Entorno_nombre = reader.GetString(1),
                        Id_Area = reader.GetInt32(2)
                    };
                    subcategorias.Add(subcategoria);
                }
                return Result<List<Entorno>>.Success(subcategorias);
            }
            catch (SqlException ex)
            {
                // Handle database exceptions and return an appropriate Result
                return Result<List<Entorno>>.Failure("Error en la base de datos al obtener el Entorno: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<Entorno>>.Failure("Error al obtener el Entorno: " + ex.Message);
            }
        }
    }
    
}