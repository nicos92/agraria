using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Runtime.Versioning;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class CategoriasRepository : BaseRepositorio, ICategoriasRepository
    {
        public async Task<Result<List<Entornos>>> GetAll()
        {
            try
            {
                var categorias = new List<Entornos>();
                using (OleDbConnection conexion = Conexion())
                {
                    await conexion.OpenAsync();
                    using var cmd = new OleDbCommand("SELECT Id_Categoria, Categoria FROM Categorias", conexion);
                    using var reader = await cmd.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        categorias.Add(new Entornos
                        {
                            Id_entorno = reader.GetInt32(0),
                            Entorno = reader.GetString(1)
                        });
                    }
                }
                return Result<List<Entornos>>.Success(categorias);
            }catch(OleDbException ix)
            {
                return Result<List<Entornos>>.Failure($"Error de base de dtos al obtener categorías: {ix.Message}");
            }
            catch (Exception ex)
            {
                return Result<List<Entornos>>.Failure($"Error inesperado al obtener categorías: {ex.Message}");
            }
        }

        public Result<Entornos> GetById(int id)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand("SELECT  Id_Categoria, Categoria FROM Categorias WHERE Id_categoria = ?", conexion);
                    cmd.Parameters.AddWithValue("?", id);
                    using var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        var categoria = new Entornos
                        {
                            Id_entorno = reader.GetInt32(0),
                            Entorno = reader.GetString(1)
                        };
                        return Result<Entornos>.Success(categoria);
                    }
                }
                return Result<Entornos>.Failure("Categoría no encontrada");
            }
            catch (Exception ex)
            {
                return Result<Entornos>.Failure($"Error al obtener categoría: {ex.Message}");
            }
        }

        public Result<Entornos> Add(Entornos categoria)
        {
            try
            {
                using (var conexion = Conexion())
                {
                    conexion.Open();
                    using var cmd = new OleDbCommand(
                        "INSERT INTO Categorias (Categoria) VALUES (?)", conexion);
                    cmd.Parameters.AddWithValue("?", categoria.Entorno);
                    cmd.ExecuteNonQuery();

                    // Obtener el ID de la categoría insertada
                    using var cmdId = new OleDbCommand("SELECT @@IDENTITY", conexion);
                    var newId = Convert.ToInt32(cmdId.ExecuteScalar());
                    categoria.Id_entorno = newId;
                }
                return Result<Entornos>.Success(categoria);
            }
            catch (Exception ex)
            {
                return Result<Entornos>.Failure($"Error al agregar categoría: {ex.Message}");
            }
        }

        public Result<Entornos> Update(Entornos categoria)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new OleDbCommand(
                    "UPDATE Categorias SET Categoria = ? WHERE Id_categoria = ?", conexion);
                cmd.Parameters.AddWithValue("?", categoria.Entorno);
                cmd.Parameters.AddWithValue("?", categoria.Id_entorno);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Entornos>.Success(categoria);
                }
                else
                {
                    return Result<Entornos>.Failure("No se encontró la categoría a actualizar");
                }
            }
            catch (Exception ex)
            {
                return Result<Entornos>.Failure($"Error al actualizar categoría: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conexion = Conexion();
                conexion.Open();
                using var cmd = new OleDbCommand("DELETE FROM Categorias WHERE Id_categoria = ?", conexion);
                cmd.Parameters.AddWithValue("?", id);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se encontró la categoría a eliminar");
                }
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error al eliminar categoría: {ex.Message}");
            }
        }

       
    }
}
