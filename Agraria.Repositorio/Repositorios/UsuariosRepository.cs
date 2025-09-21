using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
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
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta FROM Usuarios", conn);
                await conn.OpenAsync();
                using DbDataReader reader = await cmd.ExecuteReaderAsync();
                List<Usuarios> usuarios = [];
                while (await reader.ReadAsync())
                {
                    Usuarios usuario = new()
                    {
                        Id_Usuario = reader.GetInt32(0),
                        DNI =  reader.GetString(1),
                        Nombre = reader.GetString(2),
                        Apellido = reader.GetString(3),
                        Tel = reader.GetString(4),
                        Mail =  reader.GetString(5),
                        Id_Tipo = reader.GetInt32(6),
                        Contra = reader.GetString(7),
                        Respues = reader.GetString(8),
                        Id_Pregunta = reader.GetInt32(9)
                    };
                    usuarios.Add(usuario);
                }
                return Result<List<Usuarios>>.Success(usuarios);
            }
            catch (OleDbException ex)
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
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta FROM Usuarios WHERE Id_Usuario = @Id", conn);
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
                        Id_Pregunta = reader.GetInt32(9)
                    };
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("Usuario no encontrado");
            }
            catch (OleDbException ex)
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
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("INSERT INTO Usuarios (DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta) VALUES (@DNI, @Nombre, @Apellido, @Tel, @Mail, @Id_Tipo, @Contra, @Respues, @id_pregunta)", conn);
                cmd.Parameters.AddWithValue("@DNI", usuario.DNI );
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Tel", usuario.Tel);
                cmd.Parameters.AddWithValue("@Mail", usuario.Mail);
                cmd.Parameters.AddWithValue("@Id_Tipo", usuario.Id_Tipo);
                cmd.Parameters.AddWithValue("@Contra", usuario.Contra);
                cmd.Parameters.AddWithValue("@Respues", usuario.Respues);
                cmd.Parameters.AddWithValue("@id_pregunta", usuario.Id_Pregunta);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("repositorio: No se pudo agregar el usuario");
            }
            catch (OleDbException ex)
            {
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
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("UPDATE Usuarios SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido, Tel = @Tel, Mail = @Mail, Id_Tipo = @Id_Tipo, contra = @Contra, respues = @Respues, id_pregunta = @id_pregunta WHERE Id_Usuario = @Id", conn);
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
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("No se pudo actualizar el usuario");
            }
            catch (OleDbException ex)
            {
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
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT u.Id_Usuario, u.DNI, u.Nombre, u.Apellido, u.Tel, u.Mail, u.Id_Tipo, u.contra, u.respues, u.id_pregunta, t.descripcion FROM Usuarios u INNER JOIN usuarios_tipo t on u.id_tipo = t.id_usuario_tipo WHERE u.DNI = @Dni AND u.contra = @Password", conn);
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
                        Descripcion = reader.GetString(10)
                    };
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("Usuario no encontrado o credenciales incorrectas");
            }
            catch (OleDbException ex)
            {
                return Result<Usuarios>.Failure("Error en la base de datos al obtener el usuario: " + ex.Message);
            }catch(ExecutionEngineException ex)
            {
                return Result<Usuarios>.Failure("Error en el motor base de datos al obtener el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<Usuarios>.Failure("Error inesperado al obtener el usuario: " + ex.Message);
            }
        }
        
        public async Task<Result<Usuarios>> GetByDniAndQuestionAndAnswer(string dni, int preguntaId, string respuesta)
        {
            try
            {
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("SELECT Id_Usuario, DNI, Nombre, Apellido, Tel, Mail, Id_Tipo, contra, respues, id_pregunta FROM Usuarios WHERE DNI = @Dni AND id_pregunta = @PreguntaId AND respues = @Respuesta", conn);
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
                        Id_Pregunta = reader.GetInt32(9)
                    };
                    return Result<Usuarios>.Success(usuario);
                }
                return Result<Usuarios>.Failure("Usuario no encontrado o datos de seguridad incorrectos");
            }
            catch (OleDbException ex)
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
                using OleDbConnection conn = Conexion();
                using OleDbCommand cmd = new("DELETE FROM Usuarios WHERE Id_Usuario = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return Result<bool>.Success(true);
                }
                return Result<bool>.Failure("No se pudo eliminar el usuario");
            }
            catch (OleDbException ex)
            {
                return Result<bool>.Failure("Error en la base de datos al eliminar el usuario: " + ex.Message);
            }
            catch (System.Exception ex)
            {
                return Result<bool>.Failure("Error inesperado al eliminar el usuario: " + ex.Message);
            }
        }
    }
}