using System;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;

namespace Agraria.Test
{
    public static class SessionManagerTest
    {
        // This is a simple test to demonstrate how to use the SessionManager
        public static void TestSessionManager()
        {
            // Get the singleton instance
            var session = SessionManager.Instance;
            
            // Check if user is logged in (should be false initially)
            Console.WriteLine($"Is user logged in: {session.InicioSesion}");
            
            // Create a test user
            var user = new Usuarios
            {
                Id_Usuario = 1,
                DNI = "12345678",
                Nombre = "John",
                Apellido = "Doe",
                Mail = "john.doe@example.com",
                Id_Tipo = 1
            };
            
            // Set the user in session
            session.SetUsuario(user);
            
            // Check if user is logged in (should be true now)
            Console.WriteLine($"Is user logged in: {session.InicioSesion}");
            
            // Access user data
            Console.WriteLine($"User: {session.Usuario.Nombre} {session.Usuario.Apellido}");
            
            // Clear the session
            session.ClearSession();
            
            // Check if user is logged in (should be false again)
            Console.WriteLine($"Is user logged in: {session.InicioSesion}");
            
            // Try to access user data (should be empty)
            Console.WriteLine($"User DNI: {session.Usuario.DNI ?? "No DNI"}");
        }
    }
}