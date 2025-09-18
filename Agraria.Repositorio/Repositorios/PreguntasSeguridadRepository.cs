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
    public class PreguntasSeguridadRepository : BaseRepositorio, IPreguntasSeguridadRepository
    {
        public async Task<Result<List<PreguntasSeguridad>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Pregunta, Pregunta FROM Preguntas_Seguridad", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<PreguntasSeguridad> preguntas = [];
                while (await reader.ReadAsync())
                {
                    PreguntasSeguridad pregunta = new()
                    {
                        Id_Pregunta = reader.GetInt32(0),
                        Pregunta = reader.GetString(1)
                    };
                    preguntas.Add(pregunta);
                }
                return Result<List<PreguntasSeguridad>>.Success(preguntas);
            }
            catch (OleDbException ex)
            {
                return Result<List<PreguntasSeguridad>>.Failure("Error en la base de datos al obtener las preguntas de seguridad: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<PreguntasSeguridad>>.Failure("Error inesperado al obtener las preguntas de seguridad: " + ex.Message);
            }
        }

        public async Task<Result<PreguntasSeguridad>> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Pregunta, Pregunta FROM Preguntas_Seguridad WHERE Id_Pregunta = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    PreguntasSeguridad pregunta = new()
                    {
                        Id_Pregunta = reader.GetInt32(0),
                        Pregunta = reader.GetString(1)
                    };
                    return Result<PreguntasSeguridad>.Success(pregunta);
                }
                return Result<PreguntasSeguridad>.Failure("Pregunta de seguridad no encontrada");
            }
            catch (OleDbException ex)
            {
                return Result<PreguntasSeguridad>.Failure("Error en la base de datos al obtener la pregunta de seguridad: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<PreguntasSeguridad>.Failure("Error inesperado al obtener la pregunta de seguridad: " + ex.Message);
            }
        }

        public Result<PreguntasSeguridad> Add(PreguntasSeguridad pregunta)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("INSERT INTO Preguntas_Seguridad (Pregunta) VALUES (@Pregunta)", conn);
                cmd.Parameters.AddWithValue("@Pregunta", pregunta.Pregunta);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Get the ID of the inserted record
                    using OleDbCommand cmdGetId = new("SELECT @@IDENTITY", conn);
                    object idObj = cmdGetId.ExecuteScalar();
                    if (idObj != null && int.TryParse(idObj.ToString(), out int id))
                    {
                        pregunta.Id_Pregunta = id;
                    }
                    return Result<PreguntasSeguridad>.Success(pregunta);
                }
                return Result<PreguntasSeguridad>.Failure("No se pudo agregar la pregunta de seguridad");
            }
            catch (OleDbException ex)
            {
                return Result<PreguntasSeguridad>.Failure("Error en la base de datos al agregar la pregunta de seguridad: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<PreguntasSeguridad>.Failure("Error inesperado al agregar la pregunta de seguridad: " + ex.Message);
            }
        }

        public Result<PreguntasSeguridad> Update(PreguntasSeguridad pregunta)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("UPDATE Preguntas_Seguridad SET Pregunta = @Pregunta WHERE Id_Pregunta = @Id", conn);
                cmd.Parameters.AddWithValue("@Pregunta", pregunta.Pregunta);
                cmd.Parameters.AddWithValue("@Id", pregunta.Id_Pregunta);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<PreguntasSeguridad>.Success(pregunta);
                }
                return Result<PreguntasSeguridad>.Failure("No se pudo actualizar la pregunta de seguridad");
            }
            catch (OleDbException ex)
            {
                return Result<PreguntasSeguridad>.Failure("Error en la base de datos al actualizar la pregunta de seguridad: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<PreguntasSeguridad>.Failure("Error inesperado al actualizar la pregunta de seguridad: " + ex.Message);
            }
        }
        
        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("DELETE FROM Preguntas_Seguridad WHERE Id_Pregunta = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar la pregunta de seguridad");
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar la pregunta de seguridad: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar la pregunta de seguridad: " + ex.Message);
            }
        }
    }
}