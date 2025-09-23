using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Repositorio.Repositorios;
using Agraria.Servicio.Implementaciones;
using Agraria.UI;
using Agraria.UI.Actividad;
using Agraria.UI.Animal;
using Agraria.UI.Articulos;
using Agraria.UI.EntornoFormativo;
using Agraria.UI.HojadeVida;
using Agraria.UI.Industrial;
using Agraria.UI.Inventario;
using Agraria.UI.Paniol;
using Agraria.UI.Proveedores;
using Agraria.UI.RemitoProduccion;
using Agraria.UI.Reporte;
using Agraria.UI.Usuarios;
using Agraria.UI.Vegetal;
using Agraria.UI.Venta;
using Agraria.UI.Ventas;
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
                  if (namespaceStr.StartsWith("Agraria.UI.Articulos")) return "Articulos";
                  if (namespaceStr.StartsWith("Agraria.UI.Clientes")) return "Clientes";
                  if (namespaceStr.StartsWith("Agraria.UI.Compras")) return "Compras";
                  if (namespaceStr.StartsWith("Agraria.UI.Proveedores")) return "Proveedores";
                  if (namespaceStr.StartsWith("Agraria.UI.Usuarios")) return "Usuarios";
                  if (namespaceStr.StartsWith("Agraria.UI.Ventas")) return "Ventas";
                  if (namespaceStr.StartsWith("Agraria.UI.EstadoContable")) return "EstadoContable";
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
            Log.Information("Iniciando la aplicación Agraria.");

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

        services.AddTransient<FormRecuperarContra>(provider =>
        {
            var preguntasSeguridadService = provider.GetRequiredService<IPreguntasSeguridadService>();
            var usuariosService = provider.GetRequiredService<IUsuariosService>();
            return new FormRecuperarContra(preguntasSeguridadService, usuariosService);
        });     // Este Form estaría en Agraria.Login



        services.AddTransient<FormPrincipal>();   // Este Form estaría en Agraria.UI.Principal

        services.AddTransient<FormActividad>();   // Este Form estaría en Agraria.UI.Actividad

        services.AddTransient<FormAnimal>();     // Este Form estaría en Agraria.UI.Animal

        services.AddTransient<FormArticulos>();  // Este Form estaría en Agraria.UI.Articulos
        services.AddTransient<UCGestionEntornos>(); // Este UserControl estaría en Agraria.UI.Articulos
        services.AddTransient<UCConsultaProducto>();
        services.AddTransient<UCIngresoProducto>();

        services.AddTransient<FormHojadeVida>(); // Este Form estaría en Agraria.UI.HojadeVida
        services.AddTransient<UCIngresoHojadeVida>();
        services.AddTransient<UCConsultaHojadeVida>();
        services.AddTransient<FormVegetal>();     // Este Form estaría en Agraria.UI.Vegetal

        services.AddTransient<FormInventario>(); // Este Form estaría en Agraria.UI.Inventario
        services.AddTransient<UCIngresoInventario>();
        services.AddTransient<UCConsultaInventario>();

        services.AddTransient<FormIndustrial>(); // Este Form estaría en Agraria.UI.Industrial

        services.AddTransient<FormVentaPrincipal>();       // Este Form estaría en Agraria.UI.Venta
        services.AddTransient<UCIngresoVenta>();       // Este Form estaría en Agraria.UI.Venta
        services.AddTransient<UCConsultaVentas>();       // Este Form estaría en Agraria.UI.Venta

        services.AddTransient<FormRemitoProduccion>();       // Este Form estaría en Agraria.UI.RemitoProduccion
        services.AddTransient<UCIngresoRemito>();       // Este UserControl estaría en Agraria.UI.RemitoProduccion
        services.AddTransient<UCConsultaRemitos>();       // Este UserControl estaría en Agraria.UI.RemitoProduccion

        services.AddTransient<FormReporte>();    // Este Form estaría en Agraria.UI.Reporte

        services.AddTransient<FormUsuarios>();  // Este Form estaría en Agraria.UI.Usuarios

        services.AddTransient<FormProveedores>(); // Este Form estaría en Agraria.UI.Proveedores

        services.AddTransient<FormEntornoFormativo>();
        services.AddTransient<UCIngresoEntornoFormativo>();
        services.AddTransient<UCConsultaEntornoFormativo>();

        // Registrar UserControls
        services.AddTransient<ucIngresoActividad>();
        services.AddTransient<ucConsultaActividad>();
        services.AddTransient<ucIngresoAnimal>();
        services.AddTransient<ucConsultaAnimal>();
        services.AddTransient<ucIngresoIndustrial>();
        services.AddTransient<ucConsultaIndustrial>();

        services.AddTransient<UCIngresoProveedores>();
        services.AddTransient<UCConsultaProveedor>();

        services.AddTransient<UCIngresoUsuarios>(provider =>
        {
            var usuariosService = provider.GetRequiredService<IUsuariosService>();
            var usuariosTipoService = provider.GetRequiredService<IUsuariosTipoService>();
            var preguntasSeguridadService = provider.GetRequiredService<IPreguntasSeguridadService>();
            return new UCIngresoUsuarios(usuariosService, usuariosTipoService, preguntasSeguridadService);
        });
        services.AddTransient<USConsultaUsuario>(provider =>
        {
            var usuariosService = provider.GetRequiredService<IUsuariosService>();
            var usuariosTipoService = provider.GetRequiredService<IUsuariosTipoService>();
            var preguntasSeguridadService = provider.GetRequiredService<IPreguntasSeguridadService>();
            return new USConsultaUsuario(usuariosService, usuariosTipoService, preguntasSeguridadService);
        });
        services.AddTransient<ucIngresoVegetal>();
        services.AddTransient<ucConsultaVegetal>();

        services.AddTransient<FormPaniol>();
        services.AddTransient<UCIngresoHerramienta>(provider =>
        {
            var herramientasService = provider.GetRequiredService<IHerramientasService>();
            return new UCIngresoHerramienta(herramientasService);
        });
        services.AddTransient<UCConsultaHerramienta>(provider =>
        {
            var herramientasService = provider.GetRequiredService<IHerramientasService>();
            return new UCConsultaHerramienta(herramientasService);
        });

        services.AddTransient<FormEntornoFormativo>();
        services.AddTransient<UCIngresoEntornoFormativo>();
        services.AddTransient<UCConsultaEntornoFormativo>();

        // Registrar servicios (ejemplo)

        services.AddScoped<IProveedoresService, ProveedoresService>();
        services.AddScoped<IProveedoresRepository, ProveedoresRepository>();

        services.AddScoped<IUsuariosService, UsuariosService>();
        services.AddScoped<IUsuariosRepository, UsuariosRepository>();

        services.AddScoped<IUsuariosTipoService, UsuariosTipoService>();
        services.AddScoped<IUsuariosTipoRepository, UsuariosTipoRepository>();

        services.AddScoped<IProductoService, ArticulosService>();
        services.AddScoped<IArticulosRepository, ArticulosRepository>();

        services.AddScoped<IArticulosGralService, ArticulosGralService>();
        services.AddScoped<IArticulosGralRepository, ArticulosGralRepository>();

        services.AddScoped<IProductoStockService, ArticuloStockService>();
        services.AddScoped<IArticuloStockRepository, ArticuloStockRepository>();

        services.AddScoped<ITipoEntornosService, TipoEntornoService>();
        services.AddScoped<ITipoEntornoRepository, TipoEntornoRepository>();

        services.AddScoped<IStockService, StockService>();
        services.AddScoped<IStockRepository, StockRepository>();

        services.AddScoped<IEntornoService, SubcategoriaService>();
        services.AddScoped<IEntornoRepository, EntornoRepository>();

        services.AddScoped<IVentaService, VentaService>();
        services.AddScoped<IVentaRepository, VentaRepository>();
        
        services.AddScoped<IHVentasService, HVentasService>();
        services.AddScoped<IHVentasRepository, HVentasRepository>();

        services.AddScoped<IHVentasDetalleService, HVentasDetalleService>();
        services.AddScoped<IHVentasDetalleRepository, HVentasDetalleRepository>();
        
        // Registrar servicios y repositorios para PreguntasSeguridad
        services.AddScoped<IPreguntasSeguridadService, PreguntasSeguridadService>();
        services.AddScoped<IPreguntasSeguridadRepository, PreguntasSeguridadRepository>();
        
        // Registrar servicios y repositorios para Remitos de Producción
        services.AddScoped<IHRemitoProduccionService, HRemitoProduccionService>();
        services.AddScoped<IHRemitoProduccionRepository, HRemitoProduccionRepository>();
        services.AddScoped<IHRemitoDetalleProduccionService, HRemitoDetalleProduccionService>();
        services.AddScoped<IHRemitoDetalleProduccionRepository, HRemitoDetalleProduccionRepository>();

        services.AddScoped<IHerramientasService, HerramientasService>();
        services.AddScoped<IHerramientasRepository, HerramientasRepository>();
        
        // Registrar servicios y repositorios para Hoja de Vida
        services.AddScoped<IHojadeVidaService, HojadeVidaService>();
        services.AddScoped<IHojadeVidaRepository, HojadeVidaRepository>();

        services.AddScoped<IEntornoFormativoService, EntornoFormativoService>();
        services.AddScoped<IEntornoFormativoRepository,  EntornoFormativoRepository>();
    }
}