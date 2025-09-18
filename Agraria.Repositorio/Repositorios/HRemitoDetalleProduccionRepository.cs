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
    public class HRemitoDetalleProduccionRepository : BaseRepositorio, IHRemitoDetalleProduccionRepository
    {
        public async Task<Result<List<HRemitoDetalleProduccion>>> GetAll()
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Det_Remito, Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant FROM H_Remito_Detalle_Produccion", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<HRemitoDetalleProduccion> detalles = [];
                while (await reader.ReadAsync())
                {
                    HRemitoDetalleProduccion detalle = new()
                    {
                        Id_Det_Remito = reader.GetInt32(0),
                        Id_Remito = reader.GetInt32(1),
                        Cod_Art = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Descr = reader.IsDBNull(3) ? null : reader.GetString(3),
                        P_Unit = reader.GetDecimal(4),
                        Cant = reader.GetInt32(5),
                        P_X_Cant = reader.GetDecimal(6)
                    };
                    detalles.Add(detalle);
                }
                return Result<List<HRemitoDetalleProduccion>>.Success(detalles);
            }
            catch (OleDbException ex)
            {
                return Result<List<HRemitoDetalleProduccion>>.Failure("Error en la base de datos al obtener los detalles de remitos de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<HRemitoDetalleProduccion>>.Failure("Error inesperado al obtener los detalles de remitos de producción: " + ex.Message);
            }
        }

        public async Task<Result<HRemitoDetalleProduccion>> GetById(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Det_Remito, Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant FROM H_Remito_Detalle_Produccion WHERE Id_Det_Remito = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    HRemitoDetalleProduccion detalle = new()
                    {
                        Id_Det_Remito = reader.GetInt32(0),
                        Id_Remito = reader.GetInt32(1),
                        Cod_Art = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Descr = reader.IsDBNull(3) ? null : reader.GetString(3),
                        P_Unit = reader.GetDecimal(4),
                        Cant = reader.GetInt32(5),
                        P_X_Cant = reader.GetDecimal(6)
                    };
                    return Result<HRemitoDetalleProduccion>.Success(detalle);
                }
                return Result<HRemitoDetalleProduccion>.Failure("Detalle de remito de producción no encontrado");
            }
            catch (OleDbException ex)
            {
                return Result<HRemitoDetalleProduccion>.Failure("Error en la base de datos al obtener el detalle de remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HRemitoDetalleProduccion>.Failure("Error inesperado al obtener el detalle de remito de producción: " + ex.Message);
            }
        }

        public async Task<Result<List<HRemitoDetalleProduccion>>> GetByRemitoId(int remitoId)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Det_Remito, Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant FROM H_Remito_Detalle_Produccion WHERE Id_Remito = @RemitoId", conn);
                cmd.Parameters.AddWithValue("@RemitoId", remitoId);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<HRemitoDetalleProduccion> detalles = [];
                while (await reader.ReadAsync())
                {
                    HRemitoDetalleProduccion detalle = new()
                    {
                        Id_Det_Remito = reader.GetInt32(0),
                        Id_Remito = reader.GetInt32(1),
                        Cod_Art = reader.IsDBNull(2) ? null : reader.GetString(2),
                        Descr = reader.IsDBNull(3) ? null : reader.GetString(3),
                        P_Unit = reader.GetDecimal(4),
                        Cant = reader.GetInt32(5),
                        P_X_Cant = reader.GetDecimal(6)
                    };
                    detalles.Add(detalle);
                }
                return Result<List<HRemitoDetalleProduccion>>.Success(detalles);
            }
            catch (OleDbException ex)
            {
                return Result<List<HRemitoDetalleProduccion>>.Failure("Error en la base de datos al obtener los detalles de remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<HRemitoDetalleProduccion>>.Failure("Error inesperado al obtener los detalles de remito de producción: " + ex.Message);
            }
        }

        public Result<HRemitoDetalleProduccion> Add(HRemitoDetalleProduccion detalle)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("INSERT INTO H_Remito_Detalle_Produccion (Id_Remito, Cod_Art, Descr, P_Unit, Cant, P_X_Cant) VALUES (@Id_Remito, @Cod_Art, @Descr, @P_Unit, @Cant, @P_X_Cant)", conn);
                cmd.Parameters.AddWithValue("@Id_Remito", detalle.Id_Remito);
                cmd.Parameters.AddWithValue("@Cod_Art", (object?)detalle.Cod_Art ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Descr", (object?)detalle.Descr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@P_Unit", detalle.P_Unit);
                cmd.Parameters.AddWithValue("@Cant", detalle.Cant);
                cmd.Parameters.AddWithValue("@P_X_Cant", detalle.P_X_Cant);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Get the ID of the inserted record
                    using OleDbCommand cmdGetId = new("SELECT @@IDENTITY", conn);
                    object idObj = cmdGetId.ExecuteScalar();
                    if (idObj != null && int.TryParse(idObj.ToString(), out int id))
                    {
                        detalle.Id_Det_Remito = id;
                    }
                    return Result<HRemitoDetalleProduccion>.Success(detalle);
                }
                return Result<HRemitoDetalleProduccion>.Failure("No se pudo agregar el detalle de remito de producción");
            }
            catch (OleDbException ex)
            {
                return Result<HRemitoDetalleProduccion>.Failure("Error en la base de datos al agregar el detalle de remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HRemitoDetalleProduccion>.Failure("Error inesperado al agregar el detalle de remito de producción: " + ex.Message);
            }
        }

        public Result<HRemitoDetalleProduccion> Update(HRemitoDetalleProduccion detalle)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("UPDATE H_Remito_Detalle_Produccion SET Id_Remito = @Id_Remito, Cod_Art = @Cod_Art, Descr = @Descr, P_Unit = @P_Unit, Cant = @Cant, P_X_Cant = @P_X_Cant WHERE Id_Det_Remito = @Id", conn);
                cmd.Parameters.AddWithValue("@Id_Remito", detalle.Id_Remito);
                cmd.Parameters.AddWithValue("@Cod_Art", (object?)detalle.Cod_Art ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Descr", (object?)detalle.Descr ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@P_Unit", detalle.P_Unit);
                cmd.Parameters.AddWithValue("@Cant", detalle.Cant);
                cmd.Parameters.AddWithValue("@P_X_Cant", detalle.P_X_Cant);
                cmd.Parameters.AddWithValue("@Id", detalle.Id_Det_Remito);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<HRemitoDetalleProduccion>.Success(detalle);
                }
                return Result<HRemitoDetalleProduccion>.Failure("No se pudo actualizar el detalle de remito de producción");
            }
            catch (OleDbException ex)
            {
                return Result<HRemitoDetalleProduccion>.Failure("Error en la base de datos al actualizar el detalle de remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<HRemitoDetalleProduccion>.Failure("Error inesperado al actualizar el detalle de remito de producción: " + ex.Message);
            }
        }
        
        public Result<bool> Delete(int id)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("DELETE FROM H_Remito_Detalle_Produccion WHERE Id_Det_Remito = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar el detalle de remito de producción");
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar el detalle de remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar el detalle de remito de producción: " + ex.Message);
            }
        }

        public Result<bool> DeleteByRemitoId(int remitoId)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("DELETE FROM H_Remito_Detalle_Produccion WHERE Id_Remito = @RemitoId", conn);
                cmd.Parameters.AddWithValue("@RemitoId", remitoId);
                conn.Open();
                cmd.ExecuteNonQuery();
                return Result<bool>.Success(true);
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar los detalles de remito de producción: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar los detalles de remito de producción: " + ex.Message);
            }
        }
    }
}