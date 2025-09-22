using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Runtime.Versioning;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class TipoEntornoRepository : BaseRepositorio, ITipoEntornoRepository
    {
        public async Task<Result<List<TipoEntorno>>> GetAll()
        {
            try
            {
                var categorias = new List<TipoEntorno>();
                using (SqlConnection conexion = Conexion())
                {
                    await conexion.OpenAsync();
                    using var cmd = new SqlCommand("SELECT Id_Categoria, Categoria FROM Tipo_Entorno", conexion);
                    using var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        categorias.Add(new TipoEntorno
                        {
                            Id_Tipo_Entorno = reader.GetInt32(0),
                            Tipo_Entorno = reader.GetString(1)
                        });
                    }
                }
                return Result<List<TipoEntorno>>.Success(categorias);
            }catch(SqlException ix)
            {
                return Result<List<TipoEntorno>>.Failure($"Error de base de dtos al obtener Tipo_Entorno: {ix.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<TipoEntorno>>.Failure($"Error inesperado al obtener Tipo_Entorno: {ex.Message}");
            }
        }

        public Result<TipoEntorno> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new SqlCommand("SELECT  Id_Categoria, Categoria FROM Tipo_Entorno WHERE Id_categoria = ?", conexion);
                    cmd.Parameters.AddWithValue("?", id);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var categoria = new TipoEntorno
                        {
                            Id_Tipo_Entorno = reader.GetInt32(0),
                            Tipo_Entorno = reader.GetString(1)
                        };
                        return Result<TipoEntorno>.Success(categoria);
                    }
                }
                return Result<TipoEntorno>.Failure("Tipo_Entorno no encontrado");
            }
            catch (Exception ex)
            {
                return Result<TipoEntorno>.Failure($"Error al obtener Tipo_Entorno: {ex.Message}");
            }
        }

        public Result<TipoEntorno> Add(TipoEntorno categoria)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new SqlCommand(
                        "INSERT INTO Tipo_Entorno (Categoria) VALUES (?)", conexion);
                    cmd.Parameters.AddWithValue("?", categoria.Tipo_Entorno);
                    cmd.ExecuteNonQuery();

                    // Obtener el ID de la categoría insertada
                    using var cmdId = new SqlCommand("SELECT @@IDENTITY", conexion);
                    var newId = Convert.ToInt32(cmdId.ExecuteScalar());
                    categoria.Id_Tipo_Entorno = newId;
                }
                return Result<TipoEntorno>.Success(categoria);
            }
            catch (Exception ex)
            {
                return Result<TipoEntorno>.Failure($"Error al agregar Tipo_Entorno: {ex.Message}");
            }
        }

        public Result<TipoEntorno> Update(TipoEntorno categoria)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new SqlCommand(
                    "UPDATE Tipo_Entorno SET Categoria = ? WHERE Id_categoria = ?", conexion);
                cmd.Parameters.AddWithValue("?", categoria.Tipo_Entorno);
                cmd.Parameters.AddWithValue("?", categoria.Id_Tipo_Entorno);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<TipoEntorno>.Success(categoria);
                }
                else
                {
                    return Result<TipoEntorno>.Failure("No se encontró el Tipo_Entorno a actualizar");
                }
            }
            catch (Exception ex)
            {
                return Result<TipoEntorno>.Failure($"Error al actualizar Tipo_Entorno: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new SqlCommand("DELETE FROM Tipo_Entorno WHERE Id_categoria = ?", conexion);
                cmd.Parameters.AddWithValue("?", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se encontró el Tipo_Entorno a eliminar");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error al eliminar Tipo_Entorno: {ex.Message}");
            }
        }

       
    }
}
