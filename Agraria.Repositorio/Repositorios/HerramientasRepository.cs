using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HerramientasRepository : BaseRepositorio, IHerramientasRepository
    {
        public Result<Herramientas> Add(Herramientas herramienta)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("INSERT INTO Herramientas (Nombre, Descripcion, Cantidad) VALUES (@Nombre, @Descripcion, @Cantidad)", conn);

                cmd.Parameters.AddWithValue("@Nombre", herramienta.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", herramienta.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", herramienta.Cantidad);
                conn.Open();
                int inserts = cmd.ExecuteNonQuery();

                if (inserts > 0)
                {
                    return Result<Herramientas>.Success(herramienta);
                }
                else
                {
                    return Result<Herramientas>.Failure("No se pudo agregar la herramienta.");
                }
            }
            catch (SqlException ex)
            {
                return Result<Herramientas>.Failure($"Error al agregar la herramienta: {ex.Message}");
            }
        }

        public Result<bool> Delete(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("DELETE FROM Herramientas WHERE Id_Herramienta = @Id_Herramienta", conn);
                cmd.Parameters.AddWithValue("@Id_Herramienta", id);
                conn.Open();
                int deletes = cmd.ExecuteNonQuery();
                if (deletes > 0)
                {
                    return Result<bool>.Success(true);
                }
                else
                {
                    return Result<bool>.Failure("No se pudo eliminar la herramienta.");
                }
            }
            catch (SqlException ex)
            {
                return Result<bool>.Failure($"Error al eliminar la herramienta: {ex.Message}");
            }
        }

        public async Task<Result<List<Herramientas>>> GetAll()
        {
            try
            {
                List<Herramientas> herramientas = [];
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT Id_Herramienta, Nombre, Descripcion, Cantidad FROM Herramientas", conn);
                await conn.OpenAsync();
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Herramientas herramienta = new()
                    {
                        Id_Herramienta = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Cantidad = reader.GetInt32(3)
                    };
                    herramientas.Add(herramienta);
                }
                return Result<List<Herramientas>>.Success(herramientas);
            }
            catch (SqlException ex)
            {
                return Result<List<Herramientas>>.Failure($"Error al obtener las herramientas: {ex.Message}");
            }
        }

        public Result<Herramientas> GetById(int id)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("SELECT Id_Herramienta, Nombre, Descripcion, Cantidad FROM Herramientas WHERE Id_Herramienta = @Id_Herramienta", conn);
                cmd.Parameters.AddWithValue("@Id_Herramienta", id);
                conn.Open();
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Herramientas herramienta = new()
                    {
                        Id_Herramienta = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.GetString(2),
                        Cantidad = reader.GetInt32(3)
                    };
                    return Result<Herramientas>.Success(herramienta);
                }
                return Result<Herramientas>.Failure("No se pudo obtener la herramienta");
            }
            catch (SqlException ex)
            {
                return Result<Herramientas>.Failure($"Error al obtener la herramienta: {ex.Message}");
            }
        }

        public async Task<Result<Herramientas>> Update(Herramientas herramienta)
        {
            try
            {
                using var conn = Conexion();
                using var cmd = new SqlCommand("UPDATE Herramientas SET Nombre=@Nombre, Descripcion=@Descripcion, Cantidad=@Cantidad WHERE Id_Herramienta = @Id_Herramienta", conn);
                cmd.Parameters.AddWithValue("@Nombre", herramienta.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", herramienta.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", herramienta.Cantidad);
                cmd.Parameters.AddWithValue("@Id_Herramienta", herramienta.Id_Herramienta);
                await conn.OpenAsync();
                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    return Result<Herramientas>.Success(herramienta);
                }
                return Result<Herramientas>.Failure("No se actualizó la herramienta");
            }
            catch (SqlException ex)
            {
                return Result<Herramientas>.Failure($"Error al actualizar la herramienta: {ex.Message}");
            }
        }
    }
}