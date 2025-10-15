using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Agraria.Utilidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class HojadeVidaRepository : BaseRepositorio, IHojadeVidaRepository
    {
        public async Task<Result<List<HojadeVida>>> GetAll()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_HojaVida, Numero, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Observaciones, Activo FROM HojadeVida ORDER BY Id_HojaVida DESC", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<HojadeVida> hojasDeVida = [];
                while (await reader.ReadAsync())
                {
                    HojadeVida hojaDeVida = new()
                    {
                        Codigo = reader.GetInt32(0),
                        Numero = reader.GetInt32(1),
                        TipoAnimal = (TipoAnimal)reader.GetInt32(2),
                        Sexo =  (Sexo)reader.GetInt32(3),
                        FechaNacimiento = reader.GetDateTime(4),
                        Peso = reader.GetDecimal(5),
                        EstadoSalud = reader.GetString(6),
                        Observaciones = reader.GetString(7),
                        Activo = reader.GetBoolean(8),
                    };
                    hojasDeVida.Add(hojaDeVida);
                }
                return Result<List<HojadeVida>>.Success(hojasDeVida);
            }
            catch (SqlException ex)
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
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_HojaVida, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Observaciones, Activo, numero FROM HojadeVida WHERE Codigo = @Codigo", conn);
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
                        Numero = reader.GetInt32(8)
                    };
                    return Result<HojadeVida>.Success(hojaDeVida);
                }
                return Result<HojadeVida>.Failure("Hoja de vida no encontrada");
            }
            catch (SqlException ex)
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
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("INSERT INTO HojadeVida (Numero, Tipo_Animal, Sexo, Fecha_Nacimiento, Peso, Estado_Salud, Observaciones, Activo) VALUES (@Nuemro, @TipoAnimal, @Sexo, @fechanacimiento, @Peso, @EstadoSalud, @Observaciones, @Activo)", conn);
                cmd.Parameters.AddWithValue("@Numero", hojaDeVida.Numero);
                cmd.Parameters.AddWithValue("@TipoAnimal", Convert.ToInt32(hojaDeVida.TipoAnimal));
                cmd.Parameters.AddWithValue("@Sexo", Convert.ToInt32(hojaDeVida.Sexo));
                cmd.Parameters.Add(new SqlParameter("@fechanacimiento", SqlDbType.Date) { Value = hojaDeVida.FechaNacimiento });
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
            catch (SqlException ex)
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
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("UPDATE HojadeVida SET Tipo_Animal = @TipoAnimal, Sexo = @Sexo, Fecha_Nacimiento = @FechaNacimiento, Peso = @Peso, Estado_Salud = @EstadoSalud, Observaciones = @Observaciones, Activo = @Activo, Numero = @Numero WHERE Id_HojaVida = @Id_HojaVida", conn);
                cmd.Parameters.AddWithValue("@TipoAnimal", Convert.ToInt32(hojaDeVida.TipoAnimal));
                cmd.Parameters.AddWithValue("@Sexo", Convert.ToInt32(hojaDeVida.Sexo));
                cmd.Parameters.Add(new SqlParameter("@fechanacimiento", SqlDbType.Date) { Value = hojaDeVida.FechaNacimiento });
                cmd.Parameters.AddWithValue("@Peso", hojaDeVida.Peso);
                cmd.Parameters.AddWithValue("@EstadoSalud", hojaDeVida.EstadoSalud );
                cmd.Parameters.AddWithValue("@Observaciones", hojaDeVida.Observaciones );
                cmd.Parameters.AddWithValue("@Activo", hojaDeVida.Activo);
                cmd.Parameters.AddWithValue("@Numero", hojaDeVida.Numero);
                cmd.Parameters.AddWithValue("@Id_HojaVida", hojaDeVida.Codigo);
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected > 0)
                {
                    return Result<HojadeVida>.Success(hojaDeVida);
                }
                return Result<HojadeVida>.Failure("No se pudo actualizar la hoja de vida");
            }
            catch (SqlException ex)
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
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("DELETE FROM HojadeVida WHERE Id_HojaVida = @Id_HojaVida", conn);
                cmd.Parameters.AddWithValue("@Id_HojaVida", id);
                await conn.OpenAsync();
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar la hoja de vida");
            }
            catch (SqlException ex)
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