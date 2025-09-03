using Agraria.UI;
using Microsoft.Extensions.DependencyInjection;

namespace Agraria.Login;

public partial class FormLogin : Form
{
    private IServiceProvider _serviceProvider;
    public FormLogin(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }



    private void LblOlvide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        // Aca llamo al formulario principal que esta en PrimeSystem.UI
        Form _formHijo = _serviceProvider.GetRequiredService<FormRecuperarContra>();
        _formHijo.Closed += (s, e) =>
        {
            this.Show();
        };
        _formHijo.Dock = DockStyle.Fill;
        _formHijo.Show();
        this.Hide();

    }

    private void BtnIngresar_Click(object sender, EventArgs e)
    {
        // Aca llamo al formulario principal que esta en PrimeSystem.UI
        Form _formHijo = _serviceProvider.GetRequiredService<FormPrincipal>();
        _formHijo.Closed += (s, e) =>
        {
            this.Show();
        };
        _formHijo.Dock = DockStyle.Fill;
        _formHijo.Show();
        this.Hide();
    }
}
