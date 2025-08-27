using Microsoft.Extensions.DependencyInjection;

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

        var mainForm = ServiceProvider.GetRequiredService<Form1>();
        Application.Run(mainForm);
    }
    private static void ConfigureServices(ServiceCollection services)
    {
        // Registrar formularios
        services.AddTransient<Form1>();      // Este Form estaría en Agraria.Login

        services.AddTransient<FormRecuperarContra>();     // Este Form estaría en Agraria.Login



        // Registrar servicios (ejemplo)



    }
}