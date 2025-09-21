using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
                using var cmd = new OleDbCommand("INSERT INTO Entorno_Formativo (Id_Entorno, Id_Usuario, Curso_anio, Curso_Division, Curso_Grupo, Observaciones, Activo) VALUES (@Id_Entorno, @Id_Usuario, @Curso_anio, @Curso_Division, @Curso_Grupo, @Observaciones, @Activo)", conn);

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
            catch (OleDbException ex)
            {
                return Result<EntornoFormativo>.Failure($"Error al agregar el entorno formativo: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("DELETE FROM Entorno_Formativo WHERE Id_Entorno_Formativo = @Id_Entorno_Formativo", conn);
                cmd.Parameters.AddWithValue("@Id_Entorno_Formativo", id);
                conn.Open();
                int deletes = cmd.ExecuteNonQuery();
                if (deletes > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar el entorno formativo.");
                }
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure($"Error al eliminar el entorno formativo: \n {ex.Message}");
            }
        }

        public async Task<Result<List<EntornoFormativo>>> GetAll()
        {
            try
            {
                List<EntornoFormativo> entornosFormativos = [];
                using var conn = Conexion();
                using var cmd = new OleDbCommand("SELECT Entorno_Formativo.Id_Entorno_Formativo, Entorno_Formativo.id_Entorno, Entorno_Formativo.id_usuario, Entorno_Formativo.Curso_anio, Entorno_Formativo.Curso_division, Entorno_Formativo.Curso_Grupo, Entorno_Formativo.Observaciones, Entorno_Formativo.Activo, usuarios.nombre, usuarios.apellido, Entorno.sub_categoria FROM Entorno INNER JOIN (Usuarios INNER JOIN Entorno_Formativo ON Usuarios.id_usuario = Entorno_Formativo.id_usuario) ON Entorno.id_subcategoria = Entorno_Formativo.id_entorno;", conn);
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
            catch (OleDbException ex)
            {
                return Result<List<EntornoFormativo>>.Failure($"Error al obtener los entornos formativos: {ex.Message}");
            }
        }

        public Result<EntornoFormativo> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("SELECT Id_Entorno_Formativo, Id_Entorno, Id_Usuario, Curso_anio, Curso_Division, Curso_Grupo, Observaciones, Activo FROM Entorno_Formativo WHERE Id_Entorno_Formativo = @Id_Entorno_Formativo", conn);
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
            catch (OleDbException ex)
            {
                return Result<EntornoFormativo>.Failure($"Error al obtener el entorno formativo: {ex.Message}");
            }
        }

        public async Task<Result<EntornoFormativo>> Update(EntornoFormativo entornoFormativo)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new OleDbCommand("UPDATE Entorno_Formativo SET Id_Entorno = @Id_Entorno, Id_Usuario = @Id_Usuario, Curso_anio = @Curso_anio, Curso_Division = @Curso_Division, Curso_Grupo = @Curso_Grupo, Observaciones = @Observaciones, Activo = @Activo WHERE Id_Entorno_Formativo = @Id_Entorno_Formativo", conn);
                
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
            catch (OleDbException ex)
            {
                return Result<EntornoFormativo>.Failure($"Error al actualizar el entorno formativo: \n {ex.Message}");
            }
        }
    }
}