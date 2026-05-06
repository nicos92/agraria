# Plan de Aprendizaje: Tests Unitarios con xUnit en Agraria

## 📚 Objetivo General

Aprender a crear tests unitarios efectivos para una arquitectura en capas con inyección de dependencias, enfocándose en:
- **Services** que implementan interfaces de negocio
- **Repositories** que acceden a base de datos
- **Mocks** para aislar dependencias
- **Tests de integración** opcionales con DB real

---

## 🗂️ Tu Arquitectura Actual

```
┌─────────────────────────────────────────────────────────────┐
│                    IActividadService                         │
│                         (interface)                          │
└─────────────────────────────────────────────────────────────┘
                            ▲
                            │ implementa
┌─────────────────────────────────────────────────────────────┐
│                   ActividadService                           │
│  (recibe IActividadRepository por constructor injection)     │
└─────────────────────────────────────────────────────────────┘
                            ▲
                            │ usa
┌─────────────────────────────────────────────────────────────┐
│                  IActividadRepository                        │
│                         (interface)                          │
└─────────────────────────────────────────────────────────────┘
                            ▲
                            │ implementa
┌─────────────────────────────────────────────────────────────┐
│                  ActividadRepository                         │
│         (hereda de BaseRepositorio → SQL Server)             │
└─────────────────────────────────────────────────────────────┘
```

---

## 📖 Niveles de Aprendizaje

### **Nivel 1: Fundamentos de xUnit** (1-2 días)

#### Conceptos Clave
- Atributos `[Fact]` y `[Theory]`
- Clase `Assert` para validaciones
- Patrón AAA: **Arrange** (preparar), **Act** (actuar), **Assert** (verificar)

#### Ejemplo Básico
```csharp
using Xunit;

namespace Agraria.Test.Servicios;

public class ActividadServiceTests
{
    [Fact]
    public async Task GetAll_CuandoHayDatos_ReturnaListaNoVacia()
    {
        // Arrange
        var mockRepo = new Mock<IActividadRepository>();
        var actividadesEsperadas = new List<Actividad>
        {
            new Actividad { Id_Actividad = 1, Descripcion_Actividad = "Test 1" },
            new Actividad { Id_Actividad = 2, Descripcion_Actividad = "Test 2" }
        };
        
        // Configurar el mock para que devuelva nuestra lista
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
}
```

#### Tareas Prácticas
- [x] Configurar proyecto de tests 
- [x] Crear primera carpeta `Services/` dentro de `Agraria.Test`
- [x] Escribir 3 tests básicos para `ActividadService` usando mocks
- [x] Ejecutar tests con `dotnet test`

---

### **Nivel 2: Mocking con Moq** (2-3 días)

#### Conceptos Clave
- `Mock<T>` para crear objetos falsos
- `Setup()` para configurar comportamiento
- `Returns()`, `ReturnsAsync()` para definir retornos
- `Verify()` para verificar que se llamaron los métodos
- `It.IsAny<T>()` para matchear cualquier parámetro

#### Ejemplo: Mock con Verificación
```csharp
using Moq;
using Xunit;

namespace Agraria.Test.Servicios;

public class ActividadServiceTests
{
    [Fact]
    public async Task Add_CuandoDatosValidos_LlamaAlRepositorio()
    {
        // Arrange
        var mockRepo = new Mock<IActividadRepository>();
        var nuevaActividad = new Actividad 
        { 
            Id_Actividad = 0, 
            Descripcion_Actividad = "Nueva actividad" 
        };
        
        mockRepo
            .Setup(r => r.Add(nuevaActividad))
            .ReturnsAsync(Result<Actividad>.Success(nuevaActividad with { Id_Actividad = 1 }));
        
        var service = new ActividadService(mockRepo.Object);

        // Act
        var resultado = await service.Add(nuevaActividad);

        // Assert
        Assert.True(resultado.IsSuccess);
        Assert.Equal(1, resultado.Value.Id_Actividad);
        
        // Verificar que el repositorio fue llamado exactamente una vez
        mockRepo.Verify(r => r.Add(nuevaActividad), Times.Once);
    }

    [Fact]
    public async Task GetById_CuandoNoExiste_ReturnaError()
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
}
```

#### Tareas Prácticas
- [x] Crear tests para métodos CRUD completos (Add, Update, Delete, GetById)
- [x] Practicar con `Verify()` para asegurar que se llaman los métodos correctos
- [x] Usar `It.IsAny<int>()` para tests que no dependen de IDs específicos
- [x] Crear tests para métodos con parámetros múltiples (ej: `GetByFechaRango`)

---

### **Nivel 3: Tests para Escenarios Complejos** (2-3 días)

#### Conceptos Clave
- Mockear excepciones con `Throws()`
- Tests con `[Theory]` y `[InlineData]` para múltiples casos
- Configurar mocks para retornar diferentes valores según parámetros

#### Ejemplo: Tests Parametrizados y Excepciones
```csharp
public class ActividadServiceTests
{
    // Test parametrizado para múltiples fechas
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

    // Test de excepción
    [Fact]
    public async Task GetAll_CuandoRepoLanzaExcepcion_ReturnaError()
    {
        // Arrange
        var mockRepo = new Mock<IActividadRepository>();
        
        mockRepo
            .Setup(r => r.GetAll())
            .ThrowsAsync(new Exception("Error de conexión"));
        
        var service = new ActividadService(mockRepo.Object);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => service.GetAll());
    }
}
```

#### Tareas Prácticas
- [x] Crear tests para `GetAllByEntorno`, `GetAllByTipoEntorno`
- [x] Implementar tests para `GetTopDiez()` y `GetAllConNombres()`
- [x] Agregar tests de validación de parámetros nulos/inválidos
- [x] Usar `[Theory]` para probar múltiples escenarios en un solo test

---

### **Nivel 4: Tests de Integración con Base de Datos** (3-5 días)

> ⚠️ **Importante**: Los tests de integración son más lentos y frágiles. Úsalos solo cuando necesites verificar la conexión real con la DB.

#### Opción A: Base de Datos de Test
```csharp
// Crear una clase base para tests de integración
public class IntegracionTestBase : IDisposable
{
    protected readonly SqlConnection _conexion;
    
    public IntegracionTestBase()
    {
        // Usar una DB de test dedicada
        _conexion = new SqlConnection(
            "Server=NicoS92T440;Database=AgrariaTest;Trusted_Connection=True;TrustServerCertificate=True;");
        
        // Limpiar datos antes de cada test
        LimpiarBaseDeDatos();
    }
    
    private void LimpiarBaseDeDatos()
    {
        using var cmd = new SqlCommand("DELETE FROM Actividades", _conexion);
        _conexion.Open();
        cmd.ExecuteNonQuery();
        _conexion.Close();
    }
    
    public void Dispose()
    {
        _conexion?.Close();
        _conexion?.Dispose();
    }
}

// Test de integración concreto
public class ActividadRepositoryTests : IntegracionTestBase
{
    [Fact]
    public async Task Add_InsertaEnBaseDeDatos()
    {
        // Arrange
        var repo = new ActividadRepository(); // Usa la conexión real
        var actividad = new Actividad 
        { 
            Descripcion_Actividad = "Test de integración" 
        };

        // Act
        var resultado = await repo.Add(actividad);

        // Assert
        Assert.True(resultado.IsSuccess);
        Assert.True(resultado.Value.Id_Actividad > 0);
        
        // Verificar que realmente está en la DB
        var guardado = repo.GetById(resultado.Value.Id_Actividad);
        Assert.Equal("Test de integración", guardado.Value.Descripcion_Actividad);
    }
}
```

#### Opción B: Usar TestContainers (Recomendado para CI/CD)
```csharp
// Requiere: dotnet add package Testcontainers.SqlServer
public class ActividadRepositoryTestContainer : IAsyncLifetime
{
    private readonly SqlServerContainer _sqlContainer;
    private readonly ActividadRepository _repo;
    
    public ActividadRepositoryTestContainer()
    {
        _sqlContainer = new SqlServerBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .Build();
        
        _repo = new ActividadRepository(_sqlContainer.GetConnectionString());
    }
    
    public async Task InitializeAsync()
    {
        await _sqlContainer.StartAsync();
        // Ejecutar scripts de creación de tablas
    }
    
    public Task DisposeAsync()
    {
        return _sqlContainer.DisposeAsync().AsTask();
    }
    
    [Fact]
    public async Task GetAll_ConDBReal_Functiona()
    {
        // Test que usa SQL Server en Docker
    }
}
```

#### Tareas Prácticas
- [x] Crear clase base `IntegracionTestBase`
- [ ] Escribir 2-3 tests de integración para `ActividadRepository`
- [ ] Configurar DB de test separada (AgrariaTest)
- [ ] Agregar scripts de inicialización de DB para tests

---

### **Nivel 5: Patrones Avanzados** (2-3 días)

#### 5.1. Factory para Mocks
```csharp
// Evita repetir configuración de mocks
public class MockActividadRepositoryFactory
{
    public static Mock<IActividadRepository> CrearConDatosDePrueba()
    {
        var mock = new Mock<IActividadRepository>();
        var datos = new List<Actividad>
        {
            new Actividad { Id_Actividad = 1, Descripcion_Actividad = "Actividad 1" },
            new Actividad { Id_Actividad = 2, Descripcion_Actividad = "Actividad 2" }
        };
        
        mock.Setup(r => r.GetAll()).ReturnsAsync(Result<List<Actividad>>.Success(datos));
        return mock;
    }
}

// Uso en tests
[Fact]
public async Task TestUsandoFactory()
{
    var mockRepo = MockActividadRepositoryFactory.CrearConDatosDePrueba();
    var service = new ActividadService(mockRepo.Object);
    // ...
}
```

#### 5.2. Fixture para xUnit (IxUnit)
```csharp
// Requiere: dotnet add package xunit.extensibility.execution
public class ActividadServiceFixture : IDisposable
{
    public Mock<IActividadRepository> MockRepo { get; }
    public ActividadService Service { get; }
    
    public ActividadServiceFixture()
    {
        MockRepo = new Mock<IActividadRepository>();
        Service = new ActividadService(MockRepo.Object);
    }
    
    public void Dispose() { }
}

// Tests que comparten el fixture
public class ActividadServiceTests : IClassFixture<ActividadServiceFixture>
{
    private readonly ActividadServiceFixture _fixture;
    
    public ActividadServiceTests(ActividadServiceFixture fixture)
    {
        _fixture = fixture;
    }
    
    [Fact]
    public async Task Test1()
    {
        // Usa _fixture.Service y _fixture.MockRepo
    }
}
```

#### Tareas Prácticas
- [x] Crear factories para mocks comunes
- [ ] Implementar fixtures para tests que comparten estado
- [ ] Refactorizar tests duplicados usando estos patrones

---

## 📁 Estructura Recomendada para Agraria.Test

```
Agraria.Test/
├── Servicios/
│   ├── ActividadServiceTests.cs
│   ├── ActividadServiceTestsConFactory.cs  (ejemplo con factory)
│   └── OtroServiceTests.cs
├── Repositorios/
│   ├── ActividadRepositoryTests.cs         (tests de integración)
│   └── IntegracionTestBase.cs
├── Fixtures/
│   ├── MockActividadRepositoryFactory.cs
│   └── ...
└── Modelo/
    └── EntidadesTests.cs
```

---

## 🛠️ Comandos Útiles

```bash
# Ejecutar todos los tests
dotnet test

# Ejecutar tests con filtro (solo servicios)
dotnet test --filter "FullyQualifiedName~Servicios"

# Ejecutar tests excluyendo integración
dotnet test --filter "FullyQualifiedName!~Integracion"

# Ejecutar tests en modo verbose
dotnet test -v n

# Medir cobertura de código
dotnet test /p:CollectCoverage=true

# Generar reporte de cobertura HTML
reportgenerator "-reports:coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
```

---

## ✅ Checklist de Progreso

### Fase 1: Fundamentos (Días 1-3) ✅ COMPLETADO
- [x] Entender atributos `[Fact]` y `[Theory]`
- [x] Crear primeros tests para `ActividadService.GetAll()`
- [x] Aprender a usar `Assert.True`, `Assert.Equal`, `Assert.NotNull`
- [x] Ejecutar tests desde terminal

### Fase 2: Mocking (Días 4-6) ✅ COMPLETADO
- [x] Dominar `Mock<IActividadRepository>`
- [x] Configurar retornos con `Setup().Returns()`
- [x] Verificar llamadas con `Verify()`
- [x] Tests para CRUD completo

### Fase 3: Escenarios Complejos (Días 7-9) ✅ COMPLETADO
- [x] Tests parametrizados con `[Theory]`
- [x] Manejo de excepciones en tests
- [x] Tests para métodos con múltiples parámetros
- [x] Mockear diferentes comportamientos

### Fase 4: Integración (Días 10-14) 🔄 PENDIENTE
- [x] Crear clase base para tests de integración
- [ ] Configurar DB de test (requiere SQL Server accesible)
- [ ] Escribir tests que tocan la DB real
- [ ] Limpiar datos entre tests

### Fase 5: Patrones Avanzados (Días 15-17) ✅ COMPLETADO
- [x] Implementar factories de mocks
- [ ] Usar fixtures para compartir estado (opcional)
- [x] Refactorizar tests duplicados

---

## 📚 Recursos Adicionales

### Documentación Oficial
- [xUnit Documentation](https://xunit.net/)
- [Moq Quickstart](https://github.com/Moq/moq4/wiki/Quickstart)
- [Microsoft Testing Platform](https://learn.microsoft.com/en-us/dotnet/core/testing/)

### Libros Recomendados
- "The Art of Unit Testing" de Roy Osherove
- "Unit Testing Principles, Practices, and Patterns" de Vladimir Khorikov

---

## 💡 Consejos Finales

1. **Nunca testeés implementación, testeá comportamiento**: No importa CÓMO funciona, importa QUÉ hace.
2. **Mocks para unit tests, DB real para integración**: Mantené los tests unitarios rápidos y aislados.
3. **Nombres descriptivos**: `GetAll_CuandoNoHayDatos_ReturnaListaVacia` es mejor que `TestGetAll`.
4. **Tests independientes**: Cada test debe poder ejecutarse solo, sin depender de otros tests.
5. **Usá la factory de mocks**: Para evitar código repetido en el Arrange.

---

## 🎯 Resultados Obtenidos

### Tests Creados
- **23 tests unitarios** para `ActividadService` ✅
- **6 tests de integración** para `ActividadRepository` (requieren DB) 

### Archivos Creados
```
Agraria.Test/
├── Servicios/
│   ├── ActividadServiceTests.cs              (17 tests básicos)
│   └── ActividadServiceTestsConFactory.cs    (6 tests con factory)
├── Repositorios/
│   ├── ActividadRepositoryTests.cs           (6 tests de integración)
│   └── IntegracionTestBase.cs                (clase base para integración)
└── Fixtures/
    └── MockActividadRepositoryFactory.cs     (factory de mocks)
```

### Comandos para Ejecutar Tests

```bash
# Solo tests unitarios (sin DB)
dotnet test --filter "FullyQualifiedName!~Integracion"

# Todos los tests (fallarán los de integración sin DB)
dotnet test
```

---

**¡Éxito en tu aprendizaje de tests con xUnit!** 🚀
