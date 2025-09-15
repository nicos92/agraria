using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class SubCategoriaRepository : BaseRepositorio, ISubcategoriaRepository
    {
        public async Task<Result<List<SubEntornos>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Subcategoria, Sub_categoria, Id_Categoria FROM Subcategoria", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<SubEntornos> subcategorias = new List<SubEntornos>();
                while (await reader.ReadAsync())
                {
                    SubEntornos subcategoria = new SubEntornos
                    {
                        Id_SubEntorno = reader.GetInt32(0),
                        Sub_Entorno = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Id_Entorno = reader.GetInt32(2)
                    };
                    subcategorias.Add(subcategoria);
                }
                return Result<List<SubEntornos>>.Success(subcategorias);
            }
            catch (OleDbException ex)
            {
                // Handle database exceptions and return an appropriate Result
                return Result<List<SubEntornos>>.Failure("Error en la base de datos al obtener las subcategorías: " + ex.Message   );
            }
            catch (Exception ex)
            {
                return Result<List<SubEntornos>>.Failure("Error al obtener las subcategorías: " + ex.Message);
            }
        }

        public Result<SubEntornos> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Subcategoria, Sub_categoria, Id_Categoria FROM Subcategoria WHERE Id_Subcategoria = @Id_Subcategoria", conn);
                cmd.Parameters.AddWithValue("@Id_Subcategoria", id);
                conn.Open();
                using OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    SubEntornos subcategoria = new SubEntornos
                    {
                        Id_SubEntorno = reader.GetInt32(0),
                        Sub_Entorno = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Id_Entorno = reader.GetInt32(2)
                    };
                    return Result<SubEntornos>.Success(subcategoria);
                }
                return Result<SubEntornos>.Failure("No se pudo encontrar la subcategoría con el ID especificado.");
            }catch(OleDbException ex)
            {
                return Result<SubEntornos>.Failure("Error en la base de datos al obtener la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<SubEntornos>.Failure("Error inesperado al obtener la subcategoría: " + ex.Message);
            }
        }

        public Result<SubEntornos> Add(SubEntornos subcategoria)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("INSERT INTO Subcategoria (Sub_categoria, Id_Categoria) VALUES (@Sub_categoria, @Id_Categoria)", conn);
                cmd.Parameters.AddWithValue("@Sub_categoria", subcategoria.Sub_Entorno);
                cmd.Parameters.AddWithValue("@Id_Categoria", subcategoria.Id_Entorno);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<SubEntornos>.Success(subcategoria);
                }
                return Result<SubEntornos>.Failure("No se pudo agregar la subcategoría.");
            }catch (OleDbException ex)
            {
                return Result<SubEntornos>.Failure("Error en la base de datos al agregar la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<SubEntornos>.Failure("Error inesperado al agregar la subcategoría: " + ex.Message);
            }
            
        }

        public Result<SubEntornos> Update(SubEntornos subcategoria)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("UPDATE Subcategoria SET Sub_categoria = @Sub_categoria, Id_Categoria = @Id_Categoria WHERE Id_Subcategoria = @Id_Subcategoria", conn);
                cmd.Parameters.AddWithValue("@Sub_categoria", subcategoria.Sub_Entorno);
                cmd.Parameters.AddWithValue("@Id_Categoria", subcategoria.Id_Entorno);
                cmd.Parameters.AddWithValue("@Id_Subcategoria", subcategoria.Id_SubEntorno);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<SubEntornos>.Success(subcategoria);
                }
                return Result<SubEntornos>.Failure("No se pudo actualizar la subcategoría.");
            }catch (OleDbException ex)
            {
                return Result<SubEntornos>.Failure("Error en la base de datos al actualizar la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<SubEntornos>.Failure("Error inesperado al actualizar la subcategoría: " + ex.Message);
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("DELETE FROM Subcategoria WHERE Id_Subcategoria = @Id_Subcategoria", conn);
                cmd.Parameters.AddWithValue("@Id_Subcategoria", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar la subcategoría.");
            }catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar la subcategoría: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar la subcategoría: " + ex.Message);
            }
        }

        public async Task<Result<List<SubEntornos>>> GetAllxCategoria(int idcategoria)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new OleDbCommand("SELECT Id_Subcategoria, Sub_categoria, Id_Categoria FROM Subcategoria WHERE Id_Categoria = @Id_Categoria", conn);
                cmd.Parameters.AddWithValue("@Id_Categoria", idcategoria);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<SubEntornos> subcategorias = new List<SubEntornos>();
                while (await reader.ReadAsync())
                {
                    SubEntornos subcategoria = new SubEntornos
                    {
                        Id_SubEntorno = reader.GetInt32(0),
                        Sub_Entorno = reader.IsDBNull(1) ? null : reader.GetString(1),
                        Id_Entorno = reader.GetInt32(2)
                    };
                    subcategorias.Add(subcategoria);
                }
                return Result<List<SubEntornos>>.Success(subcategorias);
            }
            catch (OleDbException ex)
            {
                // Handle database exceptions and return an appropriate Result
                return Result<List<SubEntornos>>.Failure("Error en la base de datos al obtener las subcategorías: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<SubEntornos>>.Failure("Error al obtener las subcategorías: " + ex.Message);
            }
        }
    }
    
}