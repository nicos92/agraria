# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

Project overview
- This is a Windows-only .NET 9 solution composed of multiple C# projects following a layered architecture:
  - Agraria.Login: WinForms entry point (net9.0-windows). Hosts the DI container, configures Serilog logging, and starts the UI.
  - Agraria.UI: WinForms Forms/UserControls library consumed by Agraria.Login.
  - Agraria.Servicio: Service layer implementing business logic.
  - Agraria.Repositorio: Data access layer using OleDb against a local MS Access database.
  - Agraria.Contrato: Interfaces for Services and Repositories (dependency inversion).
  - Agraria.Modelo: Domain entities and shared state (e.g., SessionManager singleton).
  - Agraria.Util(idades): Cross-cutting utilities.
  - Agraria.Test: Small console harness used for ad-hoc tests (not an xUnit/NUnit/MSTest project).

Environment notes
- Windows is required (UI targets net9.0-windows, repositories are marked [SupportedOSPlatform("windows")] and use OleDb).
- The MS Access database file (basedatos.accdb) is embedded in Agraria.Login and copied to the output directory. The connection string is defined in Agraria.Login/App.config under the name "msaccess" and is consumed by Agraria.Repositorio/BaseRepositorio via ConfigurationManager.
- Logs are written by Serilog into the logs/ directory, with separate rolling files per UI area (see mapping in Agraria.Login/Program.cs).

Common commands (PowerShell)
- Restore dependencies for the whole solution:
  ```pwsh path=null start=null
  dotnet restore .\Agraria.sln
  ```
- Build (Debug by default) and then run the WinForms app (Agraria.Login):
  ```pwsh path=null start=null
  dotnet build .\Agraria.sln
  dotnet run --project .\Agraria.Login\Agraria.Login.csproj
  ```
- Build Release:
  ```pwsh path=null start=null
  dotnet build .\Agraria.sln -c Release
  ```
- Run the ad-hoc test harness (Agraria.Test):
  ```pwsh path=null start=null
  dotnet run --project .\Agraria.Test\Agraria.Test.csproj
  ```
  Notes: This project is a console app that invokes specific test methods (e.g., SessionManagerTest.TestSessionManager()). There is no test framework configured, so dotnet test and per-test filtering are not applicable.
- Format code (optional, if dotnet-format is installed):
  ```pwsh path=null start=null
  dotnet format .\Agraria.sln
  ```
  If you need to install it: dotnet tool update -g dotnet-format

High-level architecture and flow
- Composition root: Agraria.Login/Program.cs
  - Configures Serilog with a Map sink to route logs to different files based on UI namespaces (e.g., Articulos, Proveedores, Usuarios). Logs roll daily under logs/{area}.txt.
  - Builds an IServiceProvider using Microsoft.Extensions.DependencyInjection, registering:
    - Forms and UserControls from Agraria.UI (AddTransient per form/control).
    - Service/Repository pairs via their interfaces defined in Agraria.Contrato (AddScoped per pair).
  - Starts the application by resolving and running FormLogin.
- Contracts (Agraria.Contrato)
  - Defines interfaces for repositories and services so upper layers depend on abstractions.
- Domain (Agraria.Modelo)
  - Contains entity classes (e.g., Usuarios, Articulos) and shared state like SessionManager (thread-safe singleton with Usuario and InicioSesion flags).
- Data access (Agraria.Repositorio)
  - BaseRepositorio reads the "msaccess" connection string via ConfigurationManager and exposes a factory for OleDbConnection.
  - Repository implementations use parameterized OleDbCommand for CRUD and return a Result<T> type from Agraria.Utilidades for success/failure reporting.
- Services (Agraria.Servicio)
  - Implement business operations by orchestrating repository calls and domain entities. Bound to interfaces in Agraria.Contrato.
- UI (Agraria.UI)
  - A WinForms library with Forms and UserControls grouped by domain area (Actividad, Animal, Articulos, Inventario, Industrial, Proveedores, Usuarios, Venta, RemitoProduccion, Reporte, etc.). Consumed from the Login app via DI.
- Application startup (Agraria.Login)
  - Targets net9.0-windows with UseWindowsForms enabled. Embeds basedatos.accdb and copies it to the output folder so repositories can connect via |DataDirectory|.

Working efficiently in this repo
- Entry points:
  - Run the application from Agraria.Login to exercise the full stack (UI + Service + Repository against the Access DB).
  - Use Agraria.Test to quickly execute targeted, ad-hoc checks of domain-layer logic without launching the UI.
- Where to add new features:
  - Define interfaces in Agraria.Contrato, implement them in Agraria.Servicio and Agraria.Repositorio, register them in Program.ConfigureServices, and consume them from Agraria.UI via DI.

Referenced docs
- README.md currently contains only the project title (no additional commands or notes).
