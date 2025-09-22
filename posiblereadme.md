# Agraria

Aplicación de escritorio para Windows (Windows Forms, .NET 9) organizada en capas. El proyecto implementa un flujo completo de UI + servicios + repositorios sobre una base de datos Microsoft Access, con inyección de dependencias y logging estructurado.

## Arquitectura

Capas y proyectos principales:

- Agraria.Login: punto de entrada (WinForms, net9.0-windows). Configura Serilog, arma el contenedor de DI (Microsoft.Extensions.DependencyInjection) y lanza el FormLogin.
- Agraria.UI: biblioteca de formularios y controles de usuario (WinForms) por dominios: Artículos, Proveedores, Usuarios, Venta, Inventario, Industrial, Remito de Producción, Reportes, etc.
- Agraria.Servicio: capa de negocio (services) que orquesta repositorios y entidades de dominio.
- Agraria.Repositorio: acceso a datos con OleDb sobre MS Access (BaseRepositorio + repositorios concretos). Usa una cadena de conexión llamada "msaccess".
- Agraria.Contrato: define interfaces (repositorios y servicios) para inversión de dependencias.
- Agraria.Modelo: entidades de dominio y utilidades compartidas (por ejemplo, SessionManager singleton).
- Agraria.Utilidades: utilidades transversales (por ejemplo, tipos de resultado).
- Agraria.Test: pequeño ejecutable de consola para pruebas ad-hoc (no usa framework de pruebas).

Flujo de inicio:

1) Agraria.Login/Program.cs configura Serilog (Map sink que enruta logs a archivos por área) y registra formularios, controles, servicios y repositorios en DI.
2) Resuelve y ejecuta FormLogin, desde donde se navega al resto de la UI.
3) Las llamadas de UI invocan servicios (Agraria.Servicio), que a su vez llaman repositorios (Agraria.Repositorio) para CRUD en Access.

## Requisitos

- Windows (el UI apunta a net9.0-windows y los repositorios están marcados como [SupportedOSPlatform("windows")]).
- .NET SDK 9.0 o superior.
- Visual Studio 2022 (recomendado) o CLI de dotnet.
- Controlador OLE DB de Microsoft Access (ACE) disponible: Provider=Microsoft.ACE.OLEDB.12.0.

## Base de datos

- El archivo de base de datos `basedatos.accdb` está incluido en Agraria.Login y se copia al directorio de salida.
- Cadena de conexión definida en `Agraria.Login/App.config` con el nombre `msaccess`, usando `|DataDirectory|\basedatos.accdb`.
- `BaseRepositorio` (Agraria.Repositorio) lee esta cadena vía `ConfigurationManager` y expone `OleDbConnection`.

## Logging

- Serilog escribe en `logs/`, creando archivos por área (Articulos, Proveedores, Usuarios, Ventas, etc.), con rotación diaria.
- La asignación a archivos se basa en los namespaces de UI, configurado en `Agraria.Login/Program.cs`.

## Uso rápido (CLI)

Restaurar dependencias:

```pwsh
dotnet restore .\Agraria.sln
```

Compilar y ejecutar la app (WinForms, Agraria.Login):

```pwsh
dotnet build .\Agraria.sln
dotnet run --project .\Agraria.Login\Agraria.Login.csproj
```

Compilar en Release:

```pwsh
dotnet build .\Agraria.sln -c Release
```

Pruebas ad-hoc (consola, Agraria.Test):

```pwsh
dotnet run --project .\Agraria.Test\Agraria.Test.csproj
```

Nota: No hay framework de pruebas configurado (xUnit/NUnit/MSTest); este proyecto ejecuta métodos de prueba de forma directa (e.g., `SessionManagerTest.TestSessionManager()`).

## Abrir en Visual Studio

- Abrir `Agraria.sln` y seleccionar Agraria.Login como proyecto de inicio si no lo estuviera.
- Ejecutar F5 o Ctrl+F5.

## Estructura de proyectos (alto nivel)

- `Agraria.Login/` – composición raíz (DI + logging) y arranque de la aplicación.
- `Agraria.UI/` – formularios y controles por áreas funcionales.
- `Agraria.Servicio/` – lógica de negocio.
- `Agraria.Repositorio/` – acceso a datos (OleDb/Access).
- `Agraria.Contrato/` – interfaces (repos y servicios).
- `Agraria.Modelo/` – entidades de dominio y estado compartido.
- `Agraria.Util/` – utilidades.
- `Agraria.Test/` – ejecutable de consola para pruebas dirigidas.

---
