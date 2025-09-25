using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class ActividadRepository : BaseRepositorio, IActividadRepository
    {
        public async Task<Result<List<Actividad>>> GetAll()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT TOP 1000 Id_Actividad, Id_TipoEntorno, Id_Entorno, id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad FROM Actividad ORDER BY Fecha_Actividad DESC", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Actividad> actividades = [];
                while (await reader.ReadAsync())
                {
                    Actividad actividad = new()
                    {
                        Id_Actividad = reader.GetInt32(0),
                        Id_TipoEntorno = reader.GetInt32(1),
                        Id_Entorno = reader.GetInt32(2),
                        Id_EntornoFormativo = reader.GetInt32(3),
                        Fecha_Actividad = reader.GetDateTime(4),
                        Descripcion_Actividad = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                    actividades.Add(actividad);
                }
                return Result<List<Actividad>>.Success(actividades);
            }
            catch (SqlException ex)
            {
                return Result<List<Actividad>>.Failure("Error en la base de datos al obtener las Actividades: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<Actividad>>.Failure("Error al obtener las Actividades: " + ex.Message);
            }
        }

        public async Task<Result<List<ActividadesCurso>>> GetTopDiez()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT TOP 10 a.Id_Actividad, e.Curso_Anio, e.Curso_Division, e.Curso_Grupo, a.Fecha_Actividad, a.Descripcion_Actividad FROM Actividad a INNER JOIN EntornoFormativo e ON a.Id_EntornoFormativo = e.Id_EntornoFormativo ORDER BY a.Fecha_Actividad DESC; ", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<ActividadesCurso> actividades = [];
                while (await reader.ReadAsync())
                {
                    ActividadesCurso actividadesCurso = new 
                    (
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetDateTime(4),
                        reader.GetString(5)
                    );
                    actividades.Add(actividadesCurso);
                }
                return Result<List<ActividadesCurso>>.Success(actividades);
            }
            catch (SqlException ex)
            {
                return Result<List<ActividadesCurso>>.Failure("Error en la base de datos al obtener las Actividades: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<ActividadesCurso>>.Failure("Error al obtener las Actividades: " + ex.Message);
            }
        }

        public Result<Actividad> GetById(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Actividad, Id_TipoEntorno, Id_Entorno, id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad FROM Actividad WHERE Id_Actividad = @Id_Actividad", conn);
                cmd.Parameters.AddWithValue("@Id_Actividad", id);
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Actividad actividad = new()
                    {
                        Id_Actividad = reader.GetInt32(0),
                        Id_TipoEntorno = reader.GetInt32(1),
                        Id_Entorno = reader.GetInt32(2),
                        Id_EntornoFormativo = reader.GetInt32(3),
                        Fecha_Actividad = reader.GetDateTime(4),
                        Descripcion_Actividad = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                    return Result<Actividad>.Success(actividad);
                }
                return Result<Actividad>.Failure("No se pudo encontrar la Actividad con el ID especificado.");
            }
            catch (SqlException ex)
            {
                return Result<Actividad>.Failure("Error en la base de datos al obtener la Actividad: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Actividad>.Failure("Error inesperado al obtener la Actividad: " + ex.Message);
            }
        }

        public async Task<Result<Actividad>> Add(Actividad actividad)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad) VALUES (@Id_TipoEntorno, @Id_Entorno, @id_EntornoFormativo, @Fecha_Actividad, @Descripcion_Actividad)", conn);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", actividad.Id_TipoEntorno);
                cmd.Parameters.AddWithValue("@Id_Entorno", actividad.Id_Entorno);
                cmd.Parameters.AddWithValue("@id_EntornoFormativo", actividad.Id_EntornoFormativo);
                cmd.Parameters.AddWithValue("@Fecha_Actividad", actividad.Fecha_Actividad);
                cmd.Parameters.AddWithValue("@Descripcion_Actividad", actividad.Descripcion_Actividad ?? (object)DBNull.Value);
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected > 0)
                {
                    return Result<Actividad>.Success(actividad);
                }
                return Result<Actividad>.Failure("No se pudo agregar la Actividad.");
            }
            catch (SqlException ex)
            {
                return Result<Actividad>.Failure("Error en la base de datos al agregar la Actividad: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Actividad>.Failure("Error inesperado al agregar la Actividad: " + ex.Message);
            }
        }

        public async Task<Result<Actividad>> Update(Actividad actividad)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("UPDATE Actividad SET Id_TipoEntorno = @Id_TipoEntorno, Id_Entorno = @Id_Entorno, id_EntornoFormativo = @id_EntornoFormativo, Fecha_Actividad = @Fecha_Actividad, Descripcion_Actividad = @Descripcion_Actividad WHERE Id_Actividad = @Id_Actividad", conn);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", actividad.Id_TipoEntorno);
                cmd.Parameters.AddWithValue("@Id_Entorno", actividad.Id_Entorno);
                cmd.Parameters.AddWithValue("@id_EntornoFormativo", actividad.Id_EntornoFormativo);
                cmd.Parameters.AddWithValue("@Fecha_Actividad", actividad.Fecha_Actividad);
                cmd.Parameters.AddWithValue("@Descripcion_Actividad", actividad.Descripcion_Actividad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Id_Actividad", actividad.Id_Actividad);
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected > 0)
                {
                    return Result<Actividad>.Success(actividad);
                }
                return Result<Actividad>.Failure("No se pudo actualizar la Actividad.");
            }
            catch (SqlException ex)
            {
                return Result<Actividad>.Failure("Error en la base de datos al actualizar la Actividad: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Actividad>.Failure("Error inesperado al actualizar la Actividad: " + ex.Message);
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("DELETE FROM Actividad WHERE Id_Actividad = @Id_Actividad", conn);
                cmd.Parameters.AddWithValue("@Id_Actividad", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar la Actividad.");
            }
            catch (SqlException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar la Actividad: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar la Actividad: " + ex.Message);
            }
        }

        public async Task<Result<List<Actividad>>> GetAllByEntorno(int idEntorno)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("SELECT Id_Actividad, Id_TipoEntorno, Id_Entorno, id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad FROM Actividad WHERE Id_Entorno = @Id_Entorno", conn);
                cmd.Parameters.AddWithValue("@Id_Entorno", idEntorno);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Actividad> actividades = [];
                while (await reader.ReadAsync())
                {
                    Actividad actividad = new ()
                    {
                        Id_Actividad = reader.GetInt32(0),
                        Id_TipoEntorno = reader.GetInt32(1),
                        Id_Entorno = reader.GetInt32(2),
                        Id_EntornoFormativo = reader.GetInt32(3),
                        Fecha_Actividad = reader.GetDateTime(4),
                        Descripcion_Actividad = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                    actividades.Add(actividad);
                }
                return Result<List<Actividad>>.Success(actividades);
            }
            catch (SqlException ex)
            {
                return Result<List<Actividad>>.Failure("Error en la base de datos al obtener las Actividades por Entorno: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<Actividad>>.Failure("Error al obtener las Actividades por Entorno: " + ex.Message);
            }
        }

        public async Task<Result<List<Actividad>>> GetAllByTipoEntorno(int idTipoEntorno)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("SELECT Id_Actividad, Id_TipoEntorno, Id_Entorno, id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad FROM Actividad WHERE Id_TipoEntorno = @Id_TipoEntorno", conn);
                cmd.Parameters.AddWithValue("@Id_TipoEntorno", idTipoEntorno);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Actividad> actividades = [];
                while (await reader.ReadAsync())
                {
                    Actividad actividad = new ()
                    {
                        Id_Actividad = reader.GetInt32(0),
                        Id_TipoEntorno = reader.GetInt32(1),
                        Id_Entorno = reader.GetInt32(2),
                        Id_EntornoFormativo = reader.GetInt32(3),
                        Fecha_Actividad = reader.GetDateTime(4),
                        Descripcion_Actividad = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                    actividades.Add(actividad);
                }
                return Result<List<Actividad>>.Success(actividades);
            }
            catch (SqlException ex)
            {
                return Result<List<Actividad>>.Failure("Error en la base de datos al obtener las Actividades por Tipo de Entorno: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<Actividad>>.Failure("Error al obtener las Actividades por Tipo de Entorno: " + ex.Message);
            }
        }

        public async Task<Result<List<Actividad>>> GetByFechaRango(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new ("SELECT Id_Actividad, Id_TipoEntorno, Id_Entorno, id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad FROM Actividad WHERE Fecha_Actividad BETWEEN @FechaInicio AND @FechaFin", conn);
                cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                cmd.Parameters.AddWithValue("@FechaFin", fechaFin);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Actividad> actividades = [];
                while (await reader.ReadAsync())
                {
                    Actividad actividad = new ()
                    {
                        Id_Actividad = reader.GetInt32(0),
                        Id_TipoEntorno = reader.GetInt32(1),
                        Id_Entorno = reader.GetInt32(2),
                        Id_EntornoFormativo = reader.GetInt32(3),
                        Fecha_Actividad = reader.GetDateTime(4),
                        Descripcion_Actividad = reader.IsDBNull(5) ? null : reader.GetString(5)
                    };
                    actividades.Add(actividad);
                }
                return Result<List<Actividad>>.Success(actividades);
            }
            catch (SqlException ex)
            {
                return Result<List<Actividad>>.Failure("Error en la base de datos al obtener las Actividades por rango de fechas: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<Actividad>>.Failure("Error al obtener las Actividades por rango de fechas: " + ex.Message);
            }
        }
    }
}