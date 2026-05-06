using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using Moq;

namespace Agraria.Test.Fixtures;

/// <summary>
/// Factory para crear mocks de IActividadRepository preconfigurados con datos de prueba.
/// Evita repetir configuración de mocks en múltiples tests.
/// </summary>
public static class MockActividadRepositoryFactory
{
	/// <summary>
	/// Crea un mock con una lista vacía de actividades.
	/// </summary>
	public static Mock<IActividadRepository> CrearConListaVacia()
	{
		var mock = new Mock<IActividadRepository>();
		var listaVacia = new List<Actividad>();

		mock.Setup(r => r.GetAll())
			.ReturnsAsync(Result<List<Actividad>>.Success(listaVacia));

		return mock;
	}

	/// <summary>
	/// Crea un mock con datos de prueba genéricos (2 actividades).
	/// </summary>
	public static Mock<IActividadRepository> CrearConDatosDePrueba()
	{
		var mock = new Mock<IActividadRepository>();
		var datos = new List<Actividad>
		{
			new Actividad { Id_Actividad = 1, Descripcion_Actividad = "Actividad 1", Id_Entorno = 10 },
			new Actividad { Id_Actividad = 2, Descripcion_Actividad = "Actividad 2", Id_Entorno = 20 }
		};

		mock.Setup(r => r.GetAll())
			.ReturnsAsync(Result<List<Actividad>>.Success(datos));

		mock.Setup(r => r.GetById(1))
			.Returns(Result<Actividad>.Success(datos[0]));

		mock.Setup(r => r.GetById(2))
			.Returns(Result<Actividad>.Success(datos[1]));

		return mock;
	}

	/// <summary>
	/// Crea un mock que simula un error en GetAll.
	/// </summary>
	public static Mock<IActividadRepository> CrearConError(string mensajeError = "Error de prueba")
	{
		var mock = new Mock<IActividadRepository>();

		mock.Setup(r => r.GetAll())
			.ReturnsAsync(Result<List<Actividad>>.Failure(mensajeError));

		return mock;
	}

	/// <summary>
	/// Crea un mock que simula una excepción.
	/// </summary>
	public static Mock<IActividadRepository> CrearConExcepcion(Exception? excepcion = null)
	{
		var mock = new Mock<IActividadRepository>();

		mock.Setup(r => r.GetAll())
			.ThrowsAsync(excepcion ?? new Exception("Excepción de prueba"));

		return mock;
	}

	/// <summary>
	/// Crea un mock configurado para Add exitoso.
	/// </summary>
	public static Mock<IActividadRepository> CrearParaAddExitoso(int idRetornado = 100)
	{
		var mock = new Mock<IActividadRepository>();

		mock.Setup(r => r.Add(It.IsAny<Actividad>()))
			.ReturnsAsync((Actividad a) =>
			{
				a.Id_Actividad = idRetornado;
				return Result<Actividad>.Success(a);
			});

		return mock;
	}

	/// <summary>
	/// Crea un mock configurado para Add con error.
	/// </summary>
	public static Mock<IActividadRepository> CrearParaAddConError(string mensajeError = "Error al guardar")
	{
		var mock = new Mock<IActividadRepository>();

		mock.Setup(r => r.Add(It.IsAny<Actividad>()))
			.ReturnsAsync(Result<Actividad>.Failure(mensajeError));

		return mock;
	}

	/// <summary>
	/// Crea un mock configurado para Delete exitoso.
	/// </summary>
	public static Mock<IActividadRepository> CrearParaDeleteExitoso()
	{
		var mock = new Mock<IActividadRepository>();

		mock.Setup(r => r.Delete(It.IsAny<int>()))
			.Returns(Result<bool>.Success(true));

		return mock;
	}

	/// <summary>
	/// Crea un mock configurado para Delete con error.
	/// </summary>
	public static Mock<IActividadRepository> CrearParaDeleteConError(string mensajeError = "Error al eliminar")
	{
		var mock = new Mock<IActividadRepository>();

		mock.Setup(r => r.Delete(It.IsAny<int>()))
			.Returns(Result<bool>.Failure(mensajeError));

		return mock;
	}
}
