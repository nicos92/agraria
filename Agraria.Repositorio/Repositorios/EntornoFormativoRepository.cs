using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Records;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class EntornoFormativoRepository : BaseRepositorio, IEntornoFormativoRepository
    {
        public Result<EntornoFormativo> Add(EntornoFormativo entornoFormativo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("INSERT INTO EntornoFormativo (Id_Entorno, Id_Usuario, Curso_anio, Curso_Division, Curso_Grupo, Observaciones, Activo) VALUES (@Id_Entorno, @Id_Usuario, @Curso_anio, @Curso_Division, @Curso_Grupo, @Observaciones, @Activo)", conn);

                cmd.Parameters.AddWithValue("@Id_Entorno", entornoFormativo.Id_Entorno);
                cmd.Parameters.AddWithValue("@Id_Usuario", entornoFormativo.Id_Usuario);
                cmd.Parameters.AddWithValue("@Curso_anio", entornoFormativo.Curso_anio);
                cmd.Parameters.AddWithValue("@Curso_Division", entornoFormativo.Curso_Division);
                cmd.Parameters.AddWithValue("@Curso_Grupo", entornoFormativo.Curso_Grupo );
                cmd.Parameters.AddWithValue("@Observaciones", entornoFormativo.Observaciones );
                cmd.Parameters.AddWithValue("@Activo", entornoFormativo.Activo);
                
                conn.Open();
                int inserts = cmd.ExecuteNonQuery();

                if (inserts > 0)
                {
                    return Result<EntornoFormativo>.Success(entornoFormativo);
                }
                else
                {
                    return Result<EntornoFormativo>.Failure("No se pudo agregar el entorno formativo.");
                }
            }
            catch (SqlException ex)
            {
                return Result<EntornoFormativo>.Failure($"Error al agregar el entorno formativo: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("DELETE FROM EntornoFormativo WHERE Id_Entorno_Formativo = @Id_Entorno_Formativo", conn);
                cmd.Parameters.AddWithValue("@Id_Entorno_Formativo", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar el Entorno Formativo.");
            }
            catch (SqlException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar el Entorno Formativo: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar el Entorno Formativo: " + ex.Message);
            }
        }

        public async Task<Result<List<EntornoFormativo>>> GetAllByIdEntorno(int idEntorno)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("SELECT Id_EntornoFormativo, id_Entorno, id_usuario, Curso_anio, Curso_division, Curso_Grupo, Observaciones, Activo FROM EntornoFormativo WHERE id_entorno = @Id_Entorno AND Activo = 1", conn);
                cmd.Parameters.AddWithValue("@Id_Entorno", idEntorno);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<EntornoFormativo> entornosFormativos = [];
                while (await reader.ReadAsync())
                {
                    EntornoFormativo entornoFormativo = new ()
                    {
                        Id_Entorno_Formativo = reader.GetInt32(0),
                        Id_Entorno = reader.GetInt32(1),
                        Id_Usuario = reader.GetInt32(2),
                        Curso_anio = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Curso_Division = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Curso_Grupo = reader.IsDBNull(5) ? null : reader.GetString(5),
                        Observaciones = reader.IsDBNull(6) ? null : reader.GetString(6),
                        Activo = reader.GetBoolean(7)
                    };
                    entornosFormativos.Add(entornoFormativo);
                }
                return Result<List<EntornoFormativo>>.Success(entornosFormativos);
            }
            catch (SqlException ex)
            {
                return Result<List<EntornoFormativo>>.Failure("Error en la base de datos al obtener los Entornos Formativos: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<EntornoFormativo>>.Failure("Error al obtener los Entornos Formativos: " + ex.Message);
            }
        }

        public async Task<Result<List<EntornoFormativo>>> GetAll()
        {
            try
            {
                List<EntornoFormativo> entornosFormativos = [];
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT EntornoFormativo.Id_EntornoFormativo, EntornoFormativo.id_Entorno, EntornoFormativo.id_usuario, EntornoFormativo.Curso_anio, EntornoFormativo.Curso_division, EntornoFormativo.Curso_Grupo, EntornoFormativo.Observaciones, EntornoFormativo.Activo, Usuarios.Nombre, Usuarios.Apellido, Entorno.Nombre FROM Entorno INNER JOIN (Usuarios INNER JOIN EntornoFormativo ON Usuarios.id_usuario = EntornoFormativo.Id_Usuario) ON Entorno.Id_Entorno = EntornoFormativo.id_entorno;", conn);
                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    EntornoFormativo entorno = new ()
                    {
                        Id_Entorno_Formativo = reader.GetInt32(0),
                        Id_Entorno = reader.GetInt32(1),
                        Id_Usuario = reader.GetInt32(2),
                        Curso_anio = reader.GetString(3),
                        Curso_Division = reader.GetString(4),
                        Curso_Grupo =  reader.GetString(5),
                        Observaciones = reader.GetString(6),
                        Activo = reader.GetBoolean(7),
                        Usuario_Nombre = reader.GetString(8),
                        Usuario_Apellido = reader.GetString(9),
                        Entorno_Nombre= reader.GetString(10)
                    };
                    entornosFormativos.Add(entorno);
                }
                return Result<List<EntornoFormativo>>.Success(entornosFormativos);
            }
            catch (SqlException ex)
            {
                return Result<List<EntornoFormativo>>.Failure($"Error al obtener los entornos formativos: {ex.Message}");
            }
        }

        public Result<EntornoFormativo> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT Id_EntornoFormativo, Id_Entorno, Id_Usuario, Curso_anio, Curso_Division, Curso_Grupo, Observaciones, Activo FROM EntornoFormativo WHERE Id_EntornoFormativo = @Id_Entorno_Formativo", conn);
                cmd.Parameters.AddWithValue("@Id_Entorno_Formativo", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    EntornoFormativo entorno = new()
                    {
                        Id_Entorno_Formativo = reader.GetInt32(0),
                        Id_Entorno = reader.GetInt32(1),
                        Id_Usuario = reader.GetInt32(2),
                        Curso_anio =  reader.GetString(3),
                        Curso_Division =reader.GetString(4),
                        Curso_Grupo =  reader.GetString(5),
                        Observaciones = reader.GetString(6),
                        Activo = reader.GetBoolean(7)
                    };
                    return Result<EntornoFormativo>.Success(entorno);
                }
                return Result<EntornoFormativo>.Failure("No se pudo obtener el entorno formativo.");
            }
            catch (SqlException ex)
            {
                return Result<EntornoFormativo>.Failure($"Error al obtener el entorno formativo: {ex.Message}");
            }
        }

        public async Task<Result<EntornoFormativo>> Update(EntornoFormativo entornoFormativo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("UPDATE EntornoFormativo SET Id_Entorno = @Id_Entorno, Id_Usuario = @Id_Usuario, Curso_anio = @Curso_anio, Curso_Division = @Curso_Division, Curso_Grupo = @Curso_Grupo, Observaciones = @Observaciones, Activo = @Activo WHERE Id_EntornoFormativo = @Id_Entorno_Formativo", conn);
                
                cmd.Parameters.AddWithValue("@Id_Entorno", entornoFormativo.Id_Entorno);
                cmd.Parameters.AddWithValue("@Id_Usuario", entornoFormativo.Id_Usuario);
                cmd.Parameters.AddWithValue("@Curso_anio", entornoFormativo.Curso_anio);
                cmd.Parameters.AddWithValue("@Curso_Division", entornoFormativo.Curso_Division);
                cmd.Parameters.AddWithValue("@Curso_Grupo", entornoFormativo.Curso_Grupo);
                cmd.Parameters.AddWithValue("@Observaciones", entornoFormativo.Observaciones);
                cmd.Parameters.AddWithValue("@Activo", entornoFormativo.Activo);
                cmd.Parameters.AddWithValue("@Id_Entorno_Formativo", entornoFormativo.Id_Entorno_Formativo);

                await conn.OpenAsync();
                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    return Result<EntornoFormativo>.Success(entornoFormativo);
                }
                return Result<EntornoFormativo>.Failure("No se actualizó el entorno formativo.");
            }
            catch (SqlException ex)
            {
                return Result<EntornoFormativo>.Failure($"Error al actualizar el entorno formativo: \n {ex.Message}");
            }
        }

        public async Task<Result<List<EntornoFormativoConNombres>>> GetAllConNombres()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new (@"SELECT ef.Id_EntornoFormativo, e.Nombre AS Nombre_Entorno, 
                                              u.Nombre AS Nombre_Usuario, u.Apellido AS Apellido_Usuario,
                                              ef.Curso_anio, ef.Curso_Division, ef.Curso_Grupo, 
                                              ef.Observaciones, ef.Activo
                                              FROM EntornoFormativo ef
                                              LEFT JOIN Entorno e ON ef.Id_Entorno = e.Id_Entorno
                                              LEFT JOIN Usuarios u ON ef.Id_Usuario = u.Id_Usuario", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<EntornoFormativoConNombres> entornosFormativos = [];
                while (await reader.ReadAsync())
                {
                    EntornoFormativoConNombres entornoFormativo = new(
                        reader.GetInt32(0),
                        reader.IsDBNull(1) ? "N/A" : reader.GetString(1),
                        reader.IsDBNull(2) ? "N/A" : reader.GetString(2),
                        reader.IsDBNull(3) ? "N/A" : reader.GetString(3),
                        reader.IsDBNull(4) ? null : reader.GetString(4),
                        reader.IsDBNull(5) ? null : reader.GetString(5),
                        reader.IsDBNull(6) ? null : reader.GetString(6),
                        reader.IsDBNull(7) ? null : reader.GetString(7),
                        reader.GetBoolean(8)
                    );
                    entornosFormativos.Add(entornoFormativo);
                }
                return Result<List<EntornoFormativoConNombres>>.Success(entornosFormativos);
            }
            catch (SqlException ex)
            {
                return Result<List<EntornoFormativoConNombres>>.Failure("Error en la base de datos al obtener los Entornos Formativos con nombres: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<EntornoFormativoConNombres>>.Failure("Error al obtener los Entornos Formativos con nombres: " + ex.Message);
            }
        }
    }
}