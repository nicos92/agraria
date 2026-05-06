using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Servicio.Implementaciones;
using Agraria.Utilidades;
using Moq;
using Xunit;

namespace Agraria.Test.Servicios;

public class ActividadServiceTests
{
	#region GetAll Tests

	[Fact]
	public async Task GetAll_CuandoHayDatos_ReturnaListaNoVacia()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var actividadesEsperadas = new List<Actividad>
		{
			new Actividad { Id_Actividad = 1, Descripcion_Actividad = "Actividad 1" },
			new Actividad { Id_Actividad = 2, Descripcion_Actividad = "Actividad 2" }
		};

		mockRepo
			.Setup(r => r.GetAll())
			.ReturnsAsync(Result<List<Actividad>>.Success(actividadesEsperadas));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAll();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.NotNull(resultado.Value);
		Assert.Equal(2, resultado.Value.Count);
	}

	[Fact]
	public async Task GetAll_CuandoNoHayDatos_ReturnaListaVacia()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var actividadesVacias = new List<Actividad>();

		mockRepo
			.Setup(r => r.GetAll())
			.ReturnsAsync(Result<List<Actividad>>.Success(actividadesVacias));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAll();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.NotNull(resultado.Value);
		Assert.Empty(resultado.Value);
	}

	[Fact]
	public async Task GetAll_CuandoHayError_ReturnaError()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();

		mockRepo
			.Setup(r => r.GetAll())
			.ReturnsAsync(Result<List<Actividad>>.Failure("Error al obtener actividades"));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAll();

		// Assert
		Assert.False(resultado.IsSuccess);
		Assert.Equal("Error al obtener actividades", resultado.Error);
	}

	#endregion

	#region GetById Tests

	[Fact]
	public void GetById_CuandoExiste_ReturnaActividad()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var actividadEsperada = new Actividad
		{
			Id_Actividad = 1,
			Descripcion_Actividad = "Actividad Test",
			Id_Entorno = 5
		};

		mockRepo
			.Setup(r => r.GetById(1))
			.Returns(Result<Actividad>.Success(actividadEsperada));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = service.GetById(1);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.NotNull(resultado.Value);
		Assert.Equal(1, resultado.Value.Id_Actividad);
		Assert.Equal("Actividad Test", resultado.Value.Descripcion_Actividad);
	}

	[Fact]
	public void GetById_CuandoNoExiste_ReturnaError()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();

		mockRepo
			.Setup(r => r.GetById(It.IsAny<int>()))
			.Returns(Result<Actividad>.Failure("Actividad no encontrada"));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = service.GetById(999);

		// Assert
		Assert.False(resultado.IsSuccess);
		Assert.Equal("Actividad no encontrada", resultado.Error);
	}

	#endregion

	#region Add Tests

	[Fact]
	public async Task Add_CuandoDatosValidos_GuardaYRetornaActividad()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var nuevaActividad = new Actividad
		{
			Id_Actividad = 0,
			Descripcion_Actividad = "Nueva actividad",
			Id_Entorno = 3
		};
		var actividadGuardada = new Actividad
		{
			Id_Actividad = 10,
			Descripcion_Actividad = "Nueva actividad",
			Id_Entorno = 3
		};

		mockRepo
			.Setup(r => r.Add(nuevaActividad))
			.ReturnsAsync(Result<Actividad>.Success(actividadGuardada));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.Add(nuevaActividad);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.NotNull(resultado.Value);
		Assert.Equal(10, resultado.Value.Id_Actividad);
		mockRepo.Verify(r => r.Add(nuevaActividad), Times.Once);
	}

	[Fact]
	public async Task Add_CuandoHayError_ReturnaError()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var nuevaActividad = new Actividad
		{
			Descripcion_Actividad = "Actividad con error"
		};

		mockRepo
			.Setup(r => r.Add(nuevaActividad))
			.ReturnsAsync(Result<Actividad>.Failure("Error al guardar la actividad"));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.Add(nuevaActividad);

		// Assert
		Assert.False(resultado.IsSuccess);
		Assert.Equal("Error al guardar la actividad", resultado.Error);
		mockRepo.Verify(r => r.Add(nuevaActividad), Times.Once);
	}

	#endregion

	#region Update Tests

	[Fact]
	public async Task Update_CuandoDatosValidos_ActualizaActividad()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var actividadActualizada = new Actividad
		{
			Id_Actividad = 5,
			Descripcion_Actividad = "Actividad actualizada",
			Id_Entorno = 7
		};

		mockRepo
			.Setup(r => r.Update(actividadActualizada))
			.ReturnsAsync(Result<Actividad>.Success(actividadActualizada));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.Update(actividadActualizada);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(5, resultado.Value.Id_Actividad);
		Assert.Equal("Actividad actualizada", resultado.Value.Descripcion_Actividad);
		mockRepo.Verify(r => r.Update(actividadActualizada), Times.Once);
	}

	[Fact]
	public async Task Update_CuandoNoExiste_ReturnaError()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var actividad = new Actividad
		{
			Id_Actividad = 999,
			Descripcion_Actividad = "No existe"
		};

		mockRepo
			.Setup(r => r.Update(actividad))
			.ReturnsAsync(Result<Actividad>.Failure("Actividad no encontrada para actualizar"));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.Update(actividad);

		// Assert
		Assert.False(resultado.IsSuccess);
		Assert.Equal("Actividad no encontrada para actualizar", resultado.Error);
	}

	#endregion

	#region Delete Tests

	[Fact]
	public void Delete_CuandoExiste_EliminaCorrectamente()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();

		mockRepo
			.Setup(r => r.Delete(5))
			.Returns(Result<bool>.Success(true));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = service.Delete(5);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.True(resultado.Value);
		mockRepo.Verify(r => r.Delete(5), Times.Once);
	}

	[Fact]
	public void Delete_CuandoNoExiste_ReturnaError()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();

		mockRepo
			.Setup(r => r.Delete(It.IsAny<int>()))
			.Returns(Result<bool>.Failure("No se pudo eliminar la actividad"));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = service.Delete(999);

		// Assert
		Assert.False(resultado.IsSuccess);
		Assert.Equal("No se pudo eliminar la actividad", resultado.Error);
	}

	#endregion

	#region GetAllByEntorno Tests

	[Fact]
	public async Task GetAllByEntorno_CuandoHayDatos_ReturnaListaFiltrada()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var idEntorno = 10;
		var actividades = new List<Actividad>
		{
			new Actividad { Id_Actividad = 1, Id_Entorno = idEntorno },
			new Actividad { Id_Actividad = 2, Id_Entorno = idEntorno }
		};

		mockRepo
			.Setup(r => r.GetAllByEntorno(idEntorno))
			.ReturnsAsync(Result<List<Actividad>>.Success(actividades));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAllByEntorno(idEntorno);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(2, resultado.Value.Count);
		Assert.All(resultado.Value, a => Assert.Equal(idEntorno, a.Id_Entorno));
	}

	#endregion

	#region GetAllByTipoEntorno Tests

	[Fact]
	public async Task GetAllByTipoEntorno_CuandoHayDatos_ReturnaListaFiltrada()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var idTipoEntorno = 3;
		var actividades = new List<Actividad>
		{
			new Actividad { Id_Actividad = 1, Id_TipoEntorno = idTipoEntorno },
			new Actividad { Id_Actividad = 2, Id_TipoEntorno = idTipoEntorno },
			new Actividad { Id_Actividad = 3, Id_TipoEntorno = idTipoEntorno }
		};

		mockRepo
			.Setup(r => r.GetAllByTipoEntorno(idTipoEntorno))
			.ReturnsAsync(Result<List<Actividad>>.Success(actividades));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAllByTipoEntorno(idTipoEntorno);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(3, resultado.Value.Count);
		Assert.All(resultado.Value, a => Assert.Equal(idTipoEntorno, a.Id_TipoEntorno));
	}

	#endregion

	#region GetByFechaRango Tests

	[Theory]
	[InlineData("2025-01-01", "2025-01-31")]
	[InlineData("2025-02-01", "2025-02-28")]
	[InlineData("2025-03-01", "2025-03-31")]
	public async Task GetByFechaRango_RetornaActividadesEnRango(
		string inicioStr, string finStr)
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var fechaInicio = DateTime.Parse(inicioStr);
		var fechaFin = DateTime.Parse(finStr);

		var actividades = new List<Actividad>
		{
			new Actividad { Id_Actividad = 1, Fecha_Actividad = fechaInicio.AddDays(1) }
		};

		mockRepo
			.Setup(r => r.GetByFechaRango(fechaInicio, fechaFin))
			.ReturnsAsync(Result<List<Actividad>>.Success(actividades));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetByFechaRango(fechaInicio, fechaFin);

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.NotNull(resultado.Value);
	}

	#endregion

	#region GetTopDiez Tests

	[Fact]
	public async Task GetTopDiez_ReturnaActividadesCurso()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var topActividades = new List<Modelo.Entidades.ActividadesCurso>
		{
			new Modelo.Entidades.ActividadesCurso(1, "1ro", "A", "Grupo 1", DateTime.Now, "Actividad 1"),
			new Modelo.Entidades.ActividadesCurso(2, "2do", "B", "Grupo 2", DateTime.Now, "Actividad 2"),
			new Modelo.Entidades.ActividadesCurso(3, "3ro", "C", "Grupo 3", DateTime.Now, "Actividad 3")
		};

		mockRepo
			.Setup(r => r.GetTopDiez())
			.ReturnsAsync(Result<List<Modelo.Entidades.ActividadesCurso>>.Success(topActividades));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetTopDiez();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(3, resultado.Value.Count);
	}

	#endregion

	#region GetAllConNombres Tests

	[Fact]
	public async Task GetAllConNombres_ReturnaActividadesConNombres()
	{
		// Arrange
		var mockRepo = new Mock<IActividadRepository>();
		var actividadesConNombres = new List<Modelo.Records.ActividadConNombres>
		{
			new Modelo.Records.ActividadConNombres(1, "Tipo Entorno A", "Entorno X", 10, "Entorno Formativo 1", DateTime.Now, "Descripcion 1"),
			new Modelo.Records.ActividadConNombres(2, "Tipo Entorno B", "Entorno Y", 20, "Entorno Formativo 2", DateTime.Now, "Descripcion 2")
		};

		mockRepo
			.Setup(r => r.GetAllConNombres())
			.ReturnsAsync(Result<List<Modelo.Records.ActividadConNombres>>.Success(actividadesConNombres));

		var service = new ActividadService(mockRepo.Object);

		// Act
		var resultado = await service.GetAllConNombres();

		// Assert
		Assert.True(resultado.IsSuccess);
		Assert.Equal(2, resultado.Value.Count);
	}

	#endregion
}
