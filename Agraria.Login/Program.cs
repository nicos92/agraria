using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Repositorio.Repositorios;
using Agraria.Servicio.Implementaciones;
using Agraria.UI;
using Agraria.UI.Actividad;
using Agraria.UI.Animal;
using Agraria.UI.Articulos;
using Agraria.UI.Industrial;
using Agraria.UI.Proveedores;
using Agraria.UI.Reporte;
using Agraria.UI.Usuarios;
using Agraria.UI.Vegetal;
using Agraria.UI.Venta;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.Map;

namespace Agraria.Login;

static class Program
{
    public static IServiceProvider? ServiceProvider { get; private set; }
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .Enrich.FromLogContext()
          .WriteTo.Map(logEvent =>
          {
              // Obtener el SourceContext que ILogger<T> agrega automáticamente
              if (logEvent.Properties.TryGetValue("SourceContext", out var sourceContext))
              {
                  var namespaceStr = sourceContext.ToString().Trim('"');
                  if (namespaceStr.StartsWith("PrimeSystem.UI.Articulos")) return "Articulos";
                  if (namespaceStr.StartsWith("PrimeSystem.UI.Clientes")) return "Clientes";
                  if (namespaceStr.StartsWith("PrimeSystem.UI.Compras")) return "Compras";
                  if (namespaceStr.StartsWith("PrimeSystem.UI.Proveedores")) return "Proveedores";
                  if (namespaceStr.StartsWith("PrimeSystem.UI.Usuarios")) return "Usuarios";
                  if (namespaceStr.StartsWith("PrimeSystem.UI.Ventas")) return "Ventas";
                  if (namespaceStr.StartsWith("PrimeSystem.UI.EstadoContable")) return "EstadoContable";
              }

              return "General";
          },
          (key, sinkConfiguration) =>
          {
              // Configurar un archivo de log para cada clave
              sinkConfiguration.File($"logs\\\\{key.ToLower()}.txt", rollingInterval: RollingInterval.Day);
          })
          .CreateLogger();
        try
        {
            Log.Information("Iniciando la aplicación PrimeSystem.");

            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();


            var mainForm = ServiceProvider.GetRequiredService<FormLogin>();
            Application.Run(mainForm);
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "La aplicación ha terminado de forma inesperada.");
        }
        finally
        {
            Log.CloseAndFlush();
        }


       
       
        

    }
    private static void ConfigureServices(ServiceCollection services)
    {

        // Registrar Serilog para inyección de dependencias
        services.AddLogging(builder => builder.AddSerilog(dispose: true));
        // Registrar formularios
        services.AddTransient<FormLogin>();      // Este Form estaría en Agraria.Login

        services.AddTransient<FormRecuperarContra>();     // Este Form estaría en Agraria.Login



        services.AddTransient<FormPrincipal>();   // Este Form estaría en Agraria.UI.Principal

        services.AddTransient<FormActividad>();   // Este Form estaría en Agraria.UI.Actividad

        services.AddTransient<FormAnimal>();     // Este Form estaría en Agraria.UI.Animal

        services.AddTransient<FormArticulos>();  // Este Form estaría en Agraria.UI.Articulos
        services.AddTransient<UCGestionEntornos>(); // Este UserControl estaría en Agraria.UI.Articulos
        services.AddTransient<UCConsultaArticulos>();
        services.AddTransient<UCIngresoArticulos>();
        services.AddTransient<FormVegetal>();     // Este Form estaría en Agraria.UI.Vegetal

        services.AddTransient<FormIndustrial>(); // Este Form estaría en Agraria.UI.Industrial

        services.AddTransient<FormVenta>();       // Este Form estaría en Agraria.UI.Venta

        services.AddTransient<FormReporte>();    // Este Form estaría en Agraria.UI.Reporte

        services.AddTransient<FormUsuarios>();  // Este Form estaría en Agraria.UI.Usuarios

        services.AddTransient<FormProveedores>(); // Este Form estaría en Agraria.UI.Proveedores

        // Registrar UserControls
        services.AddTransient<ucIngresoActividad>();
        services.AddTransient<ucConsultaActividad>();
        services.AddTransient<ucIngresoAnimal>();
        services.AddTransient<ucConsultaAnimal>();
        services.AddTransient<ucIngresoIndustrial>();
        services.AddTransient<ucConsultaIndustrial>();

        services.AddTransient<UCIngresoProveedores>();
        services.AddTransient<UCConsultaProveedor>();

        services.AddTransient<UCIngresoUsuarios>();
        services.AddTransient<USConsultaUsuario>();
        services.AddTransient<ucIngresoVegetal>();
        services.AddTransient<ucConsultaVegetal>();
        services.AddTransient<ucIngresoVenta>();
        services.AddTransient<ucConsultaVenta>();

        // Registrar servicios (ejemplo)

        services.AddScoped<IProveedoresService, ProveedoresService>();
        services.AddScoped<IProveedoresRepository, ProveedoresRepository>();

        services.AddScoped<IUsuariosService, UsuariosService>();
        services.AddScoped<IUsuariosRepository, UsuariosRepository>();

        services.AddScoped<IUsuariosTipoService, UsuariosTipoService>();
        services.AddScoped<IUsuariosTipoRepository, UsuariosTipoRepository>();

        services.AddScoped<IArticulosService, ArticulosService>();
        services.AddScoped<IArticulosRepository, ArticulosRepository>();

        services.AddScoped<IArticuloStockService, ArticuloStockService>();
        services.AddScoped<IArticuloStockRepository, ArticuloStockRepository>();

        services.AddScoped<IEntornosService, CategoriasService>();
        services.AddScoped<ICategoriasRepository, CategoriasRepository>();

        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IStockRepository, StockRepository>();

        services.AddScoped<ISubEntornoService, SubcategoriaService>();
        services.AddScoped<ISubcategoriaRepository, SubCategoriaRepository>();

    }
}