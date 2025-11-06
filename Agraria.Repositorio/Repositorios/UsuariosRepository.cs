using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Records;
using Agraria.Utilidades;

namespace Agraria.Repositorio.Repositorios
{
    [SupportedOSPlatform("windows")]
    public class UsuariosRepository : BaseRepositorio, IUsuariosRepository
    {
        public async Task<Result<List<Usuarios>>> GetAll()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta, Activo FROM Usuarios", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Usuarios> usuarios = [];
                while (await reader.ReadAsync())
                {
                    Usuarios usuario = new()
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Apellido = reader.GetString(3),
                        Tel = reader.GetString(4),
                        Mail = reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6),
                        Contra = reader.GetString(7),
                        Respues = reader.GetString(8),
                        Id_Pregunta = reader.GetInt32(9),
                        Activo = reader.GetBoolean(10)
                    };
                    usuarios.Add(usuario);
                }
                return Result<List<Usuarios>>.Success(usuarios);
            }
            catch (SqlException ex)
            {
                return Result<List<Usuarios>>.Failure("Error en la base de datos al obtener los usuarios: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<List<Usuarios>>.Failure("Error inesperado al obtener los usuarios: " + ex.Message);
            }
        }
        public async Task<Result<List<Usuarios>>> GetAllActive()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta, Activo FROM Usuarios WHERE Activo = 1", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Usuarios> usuarios = [];
                while (await reader.ReadAsync())
                {
                    Usuarios usuario = new()
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Apellido = reader.GetString(3),
                        Tel = reader.GetString(4),
                        Mail = reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6),
                        Contra = reader.GetString(7),
                        Respues = reader.GetString(8),
                        Id_Pregunta = reader.GetInt32(9),
                        Activo = reader.GetBoolean(10)
                    };
                    usuarios.Add(usuario);
                }
                return Result<List<Usuarios>>.Success(usuarios);
            }
            catch (SqlException ex)
            {
                return Result<List<Usuarios>>.Failure("Error en la base de datos al obtener los usuarios: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<List<Usuarios>>.Failure("Error inesperado al obtener los usuarios: " + ex.Message);
            }
        }

        public async Task<Result<Usuarios>> GetById(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta, Activo FROM Usuarios WHERE Id_Usuario = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    Usuarios usuario = new()
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Apellido = reader.GetString(3),
                        Tel = reader.GetString(4),
                        Mail = reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6),
                        Contra = reader.GetString(7),
                        Respues = reader.GetString(8),
                        Id_Pregunta = reader.GetInt32(9),
                        Activo = reader.GetBoolean(10)
                    };
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("Usuario no encontrado");
            }
            catch (SqlException ex)
            {
                return Result<Usuarios>.Failure("Error en la base de datos al obtener el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al obtener el usuario: " + ex.Message);
            }
        }

        public Result<Usuarios> Add(Usuarios usuario)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta, Activo) VALUES (@DNI, @Nombre, @Apellido, @Tel, @Mail, @Id_Tipo, @Contra, @Respues, @id_pregunta, @Activo)", conn);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI );
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Tel", usuario.Tel);
                cmd.Parameters.AddWithValue("@Mail", usuario.Mail);
                cmd.Parameters.AddWithValue("@Id_Tipo", usuario.Id_Tipo);
                cmd.Parameters.AddWithValue("@Contra", usuario.Contra);
                cmd.Parameters.AddWithValue("@Respues", usuario.Respues);
                cmd.Parameters.AddWithValue("@id_pregunta", usuario.Id_Pregunta);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("repositorio: No se pudo agregar el usuario");
            }
            catch (SqlException ex)
            {

				if (ex.Message.Contains("UNIQUE KEY"))
				{
					return Result<Usuarios>.Failure("El DNI ya está ingresado, no se pueden repetir");
				}
                return Result<Usuarios>.Failure("Error en la base de datos al agregar el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al agregar el usuario: " + ex.Message);
            }
        }

        public Result<Usuarios> Update(Usuarios usuario)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("UPDATE Usuarios SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, Tel = @Tel, Mail = @Mail, Id_Tipo = @Id_Tipo, contra = @Contra, respues = @Respues, id_pregunta = @id_pregunta, Activo = @Activo WHERE Id_Usuario = @Id", conn);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI );
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre );
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido );
                cmd.Parameters.AddWithValue("@Tel", usuario.Tel);
                cmd.Parameters.AddWithValue("@Mail", usuario.Mail);
                cmd.Parameters.AddWithValue("@Id_Tipo", usuario.Id_Tipo);
                cmd.Parameters.AddWithValue("@Contra", usuario.Contra);
                cmd.Parameters.AddWithValue("@Respues", usuario.Respues);
                cmd.Parameters.AddWithValue("@id_pregunta", usuario.Id_Pregunta);
                cmd.Parameters.AddWithValue("@Id", usuario.Id_Usuario);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("No se pudo actualizar el usuario");
            }
            catch (SqlException ex)
            {
				if (ex.Message.Contains("UNIQUE KEY"))
				{
					return Result<Usuarios>.Failure("El DNI ya está ingresado, no se pueden repetir");
				}
				return Result<Usuarios>.Failure("Error en la base de datos al actualizar el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al actualizar el usuario: " + ex.Message);
            }
        }
        
        public async Task<Result<Usuarios>> GetByDniAndPassword(string dni, string password)
        {
            try
            
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT u.Id_Usuario, u.DNI, u.Nombre, u.Apellido, u.Tel, u.Mail, u.Id_Tipo, u.contra, u.respues, u.id_pregunta, t.descripcion, u.Activo FROM Usuarios u INNER JOIN usuarios_tipo t on u.id_tipo = t.id_usuario_tipo WHERE u.DNI = @Dni AND u.contra = @Password AND Activo = 1", conn);
                cmd.Parameters.AddWithValue("@Dni", dni);
                cmd.Parameters.AddWithValue("@Password", password);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    Usuarios usuario = new()
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Apellido = reader.GetString(3),
                        Tel = reader.GetString(4),
                        Mail = reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6),
                        Contra = reader.GetString(7),
                        Respues = reader.GetString(8),
                        Id_Pregunta = reader.GetInt32(9),
                        Descripcion = reader.GetString(10),
                        Activo = reader.GetBoolean(11)
                    };
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("Usuario no encontrado o credenciales incorrectas");
            }
            catch (SqlException ex)
            {
                return Result<Usuarios>.Failure("Error en la base de datos al obtener el usuario: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al obtener el usuario: " + ex.Message);
            }
        }
        
        public async Task<Result<Usuarios>> GetByDniAndQuestionAndAnswer(string dni, int preguntaId, string respuesta)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta, Activo FROM Usuarios WHERE DNI = @Dni AND id_pregunta = @PreguntaId AND respues = @Respuesta", conn);
                cmd.Parameters.AddWithValue("@Dni", dni);
                cmd.Parameters.AddWithValue("@PreguntaId", preguntaId);
                cmd.Parameters.AddWithValue("@Respuesta", respuesta);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                {
                    Usuarios usuario = new()
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI = reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Apellido = reader.GetString(3),
                        Tel = reader.GetString(4),
                        Mail = reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6),
                        Contra = reader.GetString(7),
                        Respues = reader.GetString(8),
                        Id_Pregunta = reader.GetInt32(9),
                        Activo = reader.GetBoolean(10)
                    };
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("Usuario no encontrado o datos de seguridad incorrectos");
            }
            catch (SqlException ex)
            {
                return Result<Usuarios>.Failure("Error en la base de datos al obtener el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al obtener el usuario: " + ex.Message);
            }
        }
        
        public Result<bool> Delete(int id)
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new("DELETE FROM Usuarios WHERE Id_Usuario = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar el usuario");
            }
            catch (SqlException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar el usuario: " + ex.Message);
            }
        }

        public async Task<Result<List<UsuarioConTipo>>> GetAllConTipo()
        {
            try
            {
                using SqlConnection conn = Conexion();
                using SqlCommand cmd = new(@"SELECT u.DNI, u.Nombre, u.Apellido, u.Tel, u.Mail, ut.descripcion AS Nombre_Tipo
                                              FROM Usuarios u
                                              LEFT JOIN usuarios_tipo ut ON u.Id_Tipo = ut.Id_Usuario_Tipo", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<UsuarioConTipo> usuarios = [];
                while (await reader.ReadAsync())
                {
                    UsuarioConTipo usuario = new(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.IsDBNull(5) ? "N/A" : reader.GetString(5)
                    );
                    usuarios.Add(usuario);
                }
                return Result<List<UsuarioConTipo>>.Success(usuarios);
            }
            catch (SqlException ex)
            {
                return Result<List<UsuarioConTipo>>.Failure("Error en la base de datos al obtener los usuarios con tipo: " + ex.Message);
            }
            catch (Exception ex)
            {
                return Result<List<UsuarioConTipo>>.Failure("Error inesperado al obtener los usuarios con tipo: " + ex.Message);
            }
        }
    }
}
