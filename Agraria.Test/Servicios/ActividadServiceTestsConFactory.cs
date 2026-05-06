using Agraria.Servicio.Implementaciones;
using Agraria.Test.Fixtures;
using Xunit;

namespace Agraria.Test.Servicios;

/// <summary>
/// Ejemplo de tests usando la factory de mocks para simplificar la configuración.
/// </summary>
public class ActividadServiceTestsConFactory
{
	[Fact]
	public async Task GetAll_ConFactoryDeDatosDePrueba_ReturnaDosActividades()
	{
		// Arrange - usando factory
		var mockRepo = MockActividadRepositoryFactory.CrearConDatosDePrueba();
		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAll();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(2, resultado.Value.Count);
	}

	[Fact]
	public async Task GetAll_ConFactoryDeListaVacia_ReturnaListaVacia()
	{
		// Arrange - usando factory
		var mockRepo = MockActividadRepositoryFactory.CrearConListaVacia();
		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAll();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Empty(resultado.Value);
	}

	[Fact]
	public async Task GetAll_ConFactoryDeError_ReturnaError()
	{
		// Arrange - usando factory
		var mockRepo = MockActividadRepositoryFactory.CrearConError("Error específico de prueba");
		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAll();

		// Assert
		Assert.False(resultado.IsSuccess);
		Assert.Equal("Error específico de prueba", resultado.Error);
	}

	[Fact]
	public async Task Add_ConFactoryParaAddExitoso_RetornaIdGenerado()
	{
		// Arrange - usando factory
		var mockRepo = MockActividadRepositoryFactory.CrearParaAddExitoso(idRetornado: 500);
		var service = new ActividadService(mockRepo.Object);
		var nuevaActividad = new Modelo.Entidades.Actividad
		{
			Descripcion_Actividad = "Nueva actividad",
			Id_Entorno = 99
		};

		// Act
		var resultado = await service.Add(nuevaActividad);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(500, resultado.Value.Id_Actividad);
	}

	[Fact]
	public async Task Delete_ConFactoryParaDeleteExitoso_ReturnaTrue()
	{
		// Arrange - usando factory
		var mockRepo = MockActividadRepositoryFactory.CrearParaDeleteExitoso();
		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = service.Delete(1);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.True(resultado.Value);
	}
}
