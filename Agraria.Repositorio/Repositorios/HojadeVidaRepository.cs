using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HojadeVidaRepository : BaseRepositorio, IHojadeVidaRepository
    {
        public async Task<Result<List<HojadeVida>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Codigo, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Observaciones, Activo, nombre FROM Hoja_Vida", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<HojadeVida> hojasDeVida = [];
                while (await reader.ReadAsync())
                {
                    HojadeVida hojaDeVida = new()
                    {
                        Codigo = reader.GetInt32(0),
                        TipoAnimal = (TipoAnimal)reader.GetInt32(1),
                        Sexo =  (Sexo)reader.GetInt32(2),
                        FechaNacimiento = reader.GetDateTime(3),
                        Peso = reader.GetDecimal(4),
                        EstadoSalud = reader.GetString(5),
                        Observaciones = reader.GetString(6),
                        Activo = reader.GetBoolean(7),
                        Nombre = reader.GetString(8)
                    };
                    hojasDeVida.Add(hojaDeVida);
                }
                return Result<List<HojadeVida>>.Success(hojasDeVida);
            }
            catch (OleDbException ex)
            {
                return Result<List<HojadeVida>>.Failure("Error en la base de datos al obtener las hojas de vida: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<HojadeVida>>.Failure("Error inesperado al obtener las hojas de vida: " + ex.Message);
            }
        }

        public async Task<Result<HojadeVida>> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Codigo, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Observaciones, Activo, nombre FROM Hoja_Vida WHERE Codigo = @Codigo", conn);
                cmd.Parameters.AddWithValue("@Codigo", id);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    HojadeVida hojaDeVida = new()
                    {
                        Codigo = reader.GetInt32(0),
                        TipoAnimal = (TipoAnimal)reader.GetInt32(1),
                        Sexo = (Sexo)reader.GetInt32(2),
                        FechaNacimiento = reader.GetDateTime(3),
                        Peso = reader.GetDecimal(4),
                        EstadoSalud =  reader.GetString(5),
                        Observaciones =reader.GetString(6),
                        Activo =  reader.GetBoolean(7),
                        Nombre = reader.GetString(8)
                    };
                    return Result<HojadeVida>.Success(hojaDeVida);
                }
                return Result<HojadeVida>.Failure("Hoja de vida no encontrada");
            }
            catch (OleDbException ex)
            {
                return Result<HojadeVida>.Failure("Error en la base de datos al obtener la hoja de vida: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HojadeVida>.Failure("Error inesperado al obtener la hoja de vida: " + ex.Message);
            }
        }

        public async Task<Result<HojadeVida>> Add(HojadeVida hojaDeVida)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("INSERT INTO Hoja_Vida (Nombre, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Observaciones, Activo) VALUES (@Nombre, @TipoAnimal, @Sexo, @fechanacimiento, @Peso, @EstadoSalud, @Observaciones, @Activo)", conn);
                cmd.Parameters.AddWithValue("@Nombre", hojaDeVida.Nombre);
                cmd.Parameters.AddWithValue("@TipoAnimal", Convert.ToInt32(hojaDeVida.TipoAnimal));
                cmd.Parameters.AddWithValue("@Sexo", Convert.ToInt32(hojaDeVida.Sexo));
                cmd.Parameters.Add(new OleDbParameter("@fechanacimiento", OleDbType.Date) { Value = hojaDeVida.FechaNacimiento });
                cmd.Parameters.AddWithValue("@Peso", hojaDeVida.Peso);
                cmd.Parameters.AddWithValue("@EstadoSalud", hojaDeVida.EstadoSalud );
                cmd.Parameters.AddWithValue("@Observaciones", hojaDeVida.Observaciones);
                cmd.Parameters.AddWithValue("@Activo", hojaDeVida.Activo);
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected > 0)
                {
                    return Result<HojadeVida>.Success(hojaDeVida);
                }
                return Result<HojadeVida>.Failure("repositorio: No se pudo agregar la hoja de vida");
            }
            catch (OleDbException ex)
            {
                return Result<HojadeVida>.Failure("Error en la base de datos al agregar la hoja de vida: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HojadeVida>.Failure("Error inesperado al agregar la hoja de vida: " + ex.Message);
            }
        }

        public async Task<Result<HojadeVida>> Update(HojadeVida hojaDeVida)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("UPDATE Hoja_Vida SET Tipo_Animal = @TipoAnimal, Sexo = @Sexo, Fecha_Nacimiento = @FechaNacimiento, Peso = @Peso, Estado_Salud = @EstadoSalud, Observaciones = @Observaciones, Activo = @Activo, nombre = @nombre WHERE Codigo = @Codigo", conn);
                cmd.Parameters.AddWithValue("@TipoAnimal", Convert.ToInt32(hojaDeVida.TipoAnimal));
                cmd.Parameters.AddWithValue("@Sexo", Convert.ToInt32(hojaDeVida.Sexo));
                cmd.Parameters.Add(new OleDbParameter("@fechanacimiento", OleDbType.Date) { Value = hojaDeVida.FechaNacimiento });
                cmd.Parameters.AddWithValue("@Peso", hojaDeVida.Peso);
                cmd.Parameters.AddWithValue("@EstadoSalud", hojaDeVida.EstadoSalud );
                cmd.Parameters.AddWithValue("@Observaciones", hojaDeVida.Observaciones );
                cmd.Parameters.AddWithValue("@Activo", hojaDeVida.Activo);
                cmd.Parameters.AddWithValue("@nombre", hojaDeVida.Nombre);
                cmd.Parameters.AddWithValue("@Codigo", hojaDeVida.Codigo);
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected > 0)
                {
                    return Result<HojadeVida>.Success(hojaDeVida);
                }
                return Result<HojadeVida>.Failure("No se pudo actualizar la hoja de vida");
            }
            catch (OleDbException ex)
            {
                return Result<HojadeVida>.Failure("Error en la base de datos al actualizar la hoja de vida: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HojadeVida>.Failure("Error inesperado al actualizar la hoja de vida: " + ex.Message);
            }
        }

        public async Task<Result<bool>> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("DELETE FROM Hoja_Vida WHERE Codigo = @Codigo", conn);
                cmd.Parameters.AddWithValue("@Codigo", id);
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar la hoja de vida");
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar la hoja de vida: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar la hoja de vida: " + ex.Message);
            }
        }
    }
}