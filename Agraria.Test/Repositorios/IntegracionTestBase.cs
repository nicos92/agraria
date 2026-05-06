using Microsoft.Data.SqlClient;
using Xunit;

namespace Agraria.Test.Repositorios;

/// <summary>
/// Clase base para tests de integración que requieren conexión a la base de datos.
/// Proporciona métodos para limpiar y preparar la DB antes/después de cada test.
///
/// Uso:
/// 1. Heredar de esta clase
/// 2. Usar la DB de test "AgrariaTest" para no afectar datos reales
/// 3. Los tests se marcan con [Collection] para evitar ejecución paralela
/// </summary>
public class IntegracionTestBase : IDisposable
{
	protected readonly string _cadenaConexionTest;
	protected readonly string _cadenaConexionMaster;

	public IntegracionTestBase()
	{
		// Conexión a la DB de test
		_cadenaConexionTest = "Server=NicoS92T440;Database=AgrariaTest;Trusted_Connection=True;TrustServerCertificate=True;";

		// Conexión a master para crear/eliminar DB de test
		_cadenaConexionMaster = "Server=NicoS92T440;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";

		// Asegurar que la DB de test existe
		AsegurarDbTestExiste();

		// Limpiar datos antes de cada test
		LimpiarTablas();
	}

	/// <summary>
	/// Crea la base de datos de test si no existe y crea las tablas necesarias.
	/// </summary>
	private void AsegurarDbTestExiste()
	{
		try
		{
			using var conexion = new SqlConnection(_cadenaConexionMaster);
			conexion.Open();

			// Crear DB si no existe
			var cmdCreateDb = new SqlCommand(@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'AgrariaTest')
                BEGIN
                    CREATE DATABASE AgrariaTest
                END
            ", conexion);

			cmdCreateDb.ExecuteNonQuery();

			// Crear tablas en AgrariaTest (solo las necesarias para Actividad)
			using var conexionAgraria = new SqlConnection(_cadenaConexionTest);
			conexionAgraria.Open();

			// Crear TipoEntorno si no existe
			var cmdCreateTipoEntorno = new SqlCommand(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='TipoEntorno' and xtype='U')
                BEGIN
                    CREATE TABLE TipoEntorno (
                        Id_TipoEntorno INT IDENTITY(1,1) PRIMARY KEY,
                        Descripcion NVARCHAR(255) UNIQUE
                    )
                    INSERT INTO TipoEntorno (Descripcion) VALUES (N'Tipo Test')
                END
            ", conexionAgraria);
			cmdCreateTipoEntorno.ExecuteNonQuery();

			// Crear Entorno si no existe
			var cmdCreateEntorno = new SqlCommand(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Entorno' and xtype='U')
                BEGIN
                    CREATE TABLE Entorno (
                        Id_Entorno INT IDENTITY(1,1) PRIMARY KEY,
                        Nombre NVARCHAR(255) UNIQUE,
                        Id_TipoEntorno INT NOT NULL,
                        CONSTRAINT FK_Entorno_TipoEntorno FOREIGN KEY (Id_TipoEntorno) REFERENCES TipoEntorno(Id_TipoEntorno)
                    )
                    INSERT INTO Entorno (Nombre, Id_TipoEntorno) VALUES (N'Entorno Test', 1)
                END
            ", conexionAgraria);
			cmdCreateEntorno.ExecuteNonQuery();

			// Crear EntornoFormativo si no existe
			var cmdCreateEntornoFormativo = new SqlCommand(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='EntornoFormativo' and xtype='U')
                BEGIN
                    CREATE TABLE EntornoFormativo (
                        Id_EntornoFormativo INT IDENTITY(1,1) PRIMARY KEY,
                        Nombre NVARCHAR(255),
                        Id_TipoEntorno INT NOT NULL,
                        Id_Entorno INT NOT NULL,
                        CONSTRAINT FK_EntornoFormativo_TipoEntorno FOREIGN KEY (Id_TipoEntorno) REFERENCES TipoEntorno(Id_TipoEntorno),
                        CONSTRAINT FK_EntornoFormativo_Entorno FOREIGN KEY (Id_Entorno) REFERENCES Entorno(Id_Entorno)
                    )
                    INSERT INTO EntornoFormativo (Nombre, Id_TipoEntorno, Id_Entorno) VALUES (N'Entorno Formativo Test', 1, 1)
                END
            ", conexionAgraria);
			cmdCreateEntornoFormativo.ExecuteNonQuery();

			// Crear tabla Actividad en AgrariaTest
			var cmdCreateTable = new SqlCommand(@"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Actividad' and xtype='U')
                BEGIN
                    CREATE TABLE Actividad (
                        Id_Actividad INT IDENTITY(1,1) PRIMARY KEY,
                        Id_TipoEntorno INT NOT NULL,
                        Id_Entorno INT NOT NULL,
                        Id_EntornoFormativo INT NOT NULL,
                        Fecha_Actividad DATETIME,
                        Descripcion_Actividad NVARCHAR(500)
                    )
                END
            ", conexionAgraria);

			cmdCreateTable.ExecuteNonQuery();
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException(
				"No se pudo crear la base de datos de test 'AgrariaTest'. " +
				"Verifique que el servidor SQL Server esté disponible y tenga permisos.",
				ex);
		}
	}

	/// <summary>
	/// Limpia todas las tablas relevantes antes de cada test.
	/// Se ejecuta automáticamente en el constructor.
	/// </summary>
	protected void LimpiarTablas()
	{
		try
		{
			using var conexion = new SqlConnection(_cadenaConexionTest);
			conexion.Open();

			// Orden importante por foreign keys
			var tablas = new[]
			{
				"Actividad",
                // Agregar más tablas en orden inverso de dependencias
            };

			foreach (var tabla in tablas)
			{
				var cmd = new SqlCommand($"DELETE FROM {tabla}", conexion);
				cmd.ExecuteNonQuery();
			}
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException(
				"No se pudo limpiar la base de datos de test. " +
				"Verifique que las tablas existan.",
				ex);
		}
	}

	/// <summary>
	/// Ejecuta un script SQL desde un archivo.
	/// Útil para inicializar datos de prueba.
	/// </summary>
	protected void EjecutarScript(string rutaArchivoSql)
	{
		var script = File.ReadAllText(rutaArchivoSql);

		using var conexion = new SqlConnection(_cadenaConexionTest);
		conexion.Open();

		var cmd = new SqlCommand(script, conexion);
		cmd.ExecuteNonQuery();
	}

	/// <summary>
	/// Crea una conexión nueva a la DB de test.
	/// El test debe cerrarla y disposearla.
	/// </summary>
	protected SqlConnection CrearConexion()
	{
		return new SqlConnection(_cadenaConexionTest);
	}

	public void Dispose()
	{
		// Opcional: limpiar después de cada test
		// LimpiarTablas();
	}
}

/// <summary>
/// Colección para tests de integración (evita ejecución paralela).
/// </summary>
[CollectionDefinition("Integracion Collection")]
public class IntegracionCollection : ICollectionFixture<IntegracionTestBase>
{
	// Esta clase no tiene código, solo marca la colección
}
