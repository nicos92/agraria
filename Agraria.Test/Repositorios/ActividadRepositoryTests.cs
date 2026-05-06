using Agraria.Modelo.Entidades;
using Agraria.Repositorio.Repositorios;
using Agraria.Utilidades;
using Xunit;

namespace Agraria.Test.Repositorios;

/// <summary>
/// Ejemplo de tests de integración para ActividadRepository.
/// Estos tests se conectan a la base de datos real AgrariaTest.
///
/// Nota: Los tests de integración son más lentos y deben usarse solo cuando
/// es necesario verificar la conexión real con la DB.
/// </summary>
[Collection("Integracion Collection")]
public class ActividadRepositoryTests : IntegracionTestBase
{
	private readonly ActividadRepository _repository;

	public ActividadRepositoryTests()
	{
		// Usar la cadena de conexión de test
		_repository = new ActividadRepository(
			"Server=NicoS92T440;Database=AgrariaTest;Trusted_Connection=True;TrustServerCertificate=True;");
	}

	[Fact]
	public void GetById_CuandoExisteEnDB_ReturnaActividad()
	{
		// Arrange - insertamos un dato de prueba directamente en la DB
		var idPrueba = InsertarActividadDePrueba();

		// Act
		var resultado = _repository.GetById(idPrueba);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.NotNull(resultado.Value);
		Assert.Equal(idPrueba, resultado.Value.Id_Actividad);
	}

	[Fact]
	public void GetById_CuandoNoExisteEnDB_ReturnaError()
	{
		// Act
		var resultado = _repository.GetById(99999);

		// Assert
		Assert.False(resultado.IsSuccess);
	}

	[Fact]
	public async Task Add_CuandoDatosValidos_InsertaEnDB()
	{
		// Arrange
		var actividad = new Actividad
		{
			Descripcion_Actividad = "Test Add",
			Fecha_Actividad = DateTime.Now,
			Id_Entorno = 1,
			Id_TipoEntorno = 1,
			Id_EntornoFormativo = 1
		};

		// Act
		var resultado = await _repository.Add(actividad);

		// Assert
		if (!resultado.IsSuccess)
		{
			Assert.Fail($"Error al insertar: {resultado.Error}");
		}
		Assert.True(resultado.Value.Id_Actividad > 0);

		// Verificar que realmente está en la DB
		var guardado = _repository.GetById(resultado.Value.Id_Actividad);
		Assert.True(guardado.IsSuccess);
		Assert.Equal("Test Add", guardado.Value.Descripcion_Actividad);
	}

	[Fact]
	public void Delete_CuandoExisteEnDB_EliminaCorrectamente()
	{
		// Arrange
		var idPrueba = InsertarActividadDePrueba();

		// Act
		var resultado = _repository.Delete(idPrueba);

		// Assert
		Assert.True(resultado.IsSuccess);

		// Verificar que ya no está en la DB
		var eliminado = _repository.GetById(idPrueba);
		Assert.False(eliminado.IsSuccess);
	}

	[Fact]
	public async Task GetAll_ConDBVacia_ReturnaListaVacia()
	{
		// Asegurar que está vacía
		LimpiarTablas();

		// Act
		var resultado = await _repository.GetAll();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.NotNull(resultado.Value);
		Assert.Empty(resultado.Value);
	}

	[Fact]
	public async Task GetAll_ConDatosEnDB_ReturnaTodasLasActividades()
	{
		// Arrange - insertamos 3 actividades
		LimpiarTablas();
		InsertarActividadDePrueba();
		InsertarActividadDePrueba();
		InsertarActividadDePrueba();

		// Act
		var resultado = await _repository.GetAll();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(3, resultado.Value.Count);
	}

	#region Métodos Helper

	/// <summary>
	/// Inserta una actividad de prueba directamente en la DB.
	/// Retorna el ID generado.
	/// </summary>
	private int InsertarActividadDePrueba()
	{
		using var conexion = CrearConexion();
		conexion.Open();

		var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"
            INSERT INTO Actividad (Id_TipoEntorno, Id_Entorno, Id_EntornoFormativo, Fecha_Actividad, Descripcion_Actividad)
            VALUES (@Id_TipoEntorno, @Id_Entorno, @Id_EntornoFormativo, @Fecha_Actividad, @Descripcion_Actividad);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ", conexion);

		cmd.Parameters.AddWithValue("@Id_TipoEntorno", 1);
		cmd.Parameters.AddWithValue("@Id_Entorno", 1);
		cmd.Parameters.AddWithValue("@Id_EntornoFormativo", 1);
		cmd.Parameters.AddWithValue("@Fecha_Actividad", DateTime.Now);
		cmd.Parameters.AddWithValue("@Descripcion_Actividad", "Actividad de prueba");

		return (int)cmd.ExecuteScalar();
	}

	#endregion
}
