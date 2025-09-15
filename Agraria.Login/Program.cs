using Agraria.Contrato.Servicios;
using Agraria.UI;
using Agraria.UI.Actividad;
using Agraria.UI.Animal;
using Agraria.UI.Industrial;
using Agraria.UI.Proveedores;
using Agraria.UI.Reporte;
using Agraria.UI.Usuarios;
using Agraria.UI.Vegetal;
using Agraria.UI.Venta;
using Agraria.Servicio.Implementaciones;
using Microsoft.Extensions.DependencyInjection;
using Agraria.Contrato.Repositorios;
using Agraria.Repositorio.Repositorios;

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
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        var mainForm = ServiceProvider.GetRequiredService<FormLogin>();
        Application.Run(mainForm);
    }
    private static void ConfigureServices(ServiceCollection services)
    {
        // Registrar formularios
        services.AddTransient<FormLogin>();      // Este Form estaría en Agraria.Login

        services.AddTransient<FormRecuperarContra>();     // Este Form estaría en Agraria.Login


        services.AddTransient<FormPrincipal>();   // Este Form estaría en Agraria.UI.Principal

        services.AddTransient<FormActividad>();   // Este Form estaría en Agraria.UI.Actividad

        services.AddTransient<FormAnimal>();     // Este Form estaría en Agraria.UI.Animal

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

    }
}