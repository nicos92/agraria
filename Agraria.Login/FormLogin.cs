using Agraria.Contrato.Servicios;
using Agraria.UI;
using Agraria.Util;
using Agraria.Util.Validaciones;
using Microsoft.Extensions.DependencyInjection;

namespace Agraria.Login;

public partial class FormLogin : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUsuariosService _usuariosService;
    private readonly ValidadorTextBox _vTxtDni;
    private readonly ValidadorTextBox _vTxtContra;
    private readonly ErrorProvider _epDni;

    private readonly ErrorProvider _epContra;
    public FormLogin(IServiceProvider serviceProvider, IUsuariosService usuariosService)
    {
        _serviceProvider = serviceProvider;
        _usuariosService = usuariosService;
        InitializeComponent();
        _epDni = new ErrorProvider();
        _vTxtDni = new ValidadorDni(TxtDni, _epDni)
        {
            MensajeError = "El DNI ingresado no es valido.\nIngrese 8 digitos 12345678."
        };
        _epContra = new ErrorProvider();
        _vTxtContra = new ValidadorPassword(TxtContra, _epContra);

        // Initialize error label visibility
        LblInicioError.Visible = false;
    }



    private void LblOlvide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        // Aca llamo al formulario principal que esta en Agraria.UI
        Form _formHijo = _serviceProvider.GetRequiredService<FormRecuperarContra>();
        _formHijo.Closed += (s, e) =>
        {
            this.Show();
        };
        _formHijo.Dock = DockStyle.Fill;
        _formHijo.Show();
        this.Hide();

    }

    private async void BtnIngresar_Click(object sender, EventArgs e)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(TxtDni.Text) || string.IsNullOrWhiteSpace(TxtContra.Text))
        {
            LblInicioError.Visible = true;
            return;
        }

        // Hide error message initially
        LblInicioError.Visible = false;

        try
        {
            // Authenticate user using the optimized method
            var result = await _usuariosService.GetByDniAndPassword(TxtDni.Text, TxtContra.Text);

            if (result.IsSuccess && result.Value != null)
            {
                // Authentication successful
                // Aca llamo al formulario principal que esta en Agraria.UI
                Form _formHijo = _serviceProvider.GetRequiredService<FormPrincipal>();
                _formHijo.Closed += (s, e) =>
                {
                    this.Show();
                };
                _formHijo.Dock = DockStyle.Fill;
                _formHijo.Show();
                LimpiarForm();
                this.Hide();
            }
            else
            {
                // Authentication failed
                LblInicioError.Visible = true;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error durante la autenticación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LblInicioError.Visible = true;
        }
    }

    private void LimpiarForm()
    {
        TxtDni.Clear();
        TxtContra.Clear();
        LblInicioError.Visible = false;
        TxtDni.Focus();
    }

    private void TxtDni_TextChanged(object sender, EventArgs e)
    {
        ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtContra, _vTxtDni);
    }

    private void TxtContra_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (BtnIngresar.Enabled && e.KeyChar == (char)Keys.Enter)
        {
            BtnIngresar_Click(sender, e);
        }
    }

    private void BtnIngresar_EnabledChanged(object sender, EventArgs e)
    {
        if (BtnIngresar.Enabled)
        {
            BtnIngresar.BackColor = AppColorsBlue.PrimaryContainer;

        }
        else
        {
            BtnIngresar.BackColor = AppColorsBlue.Secondary;
        }
    }

    private void FormLogin_Activated(object sender, EventArgs e)
    {
        TxtDni.Focus();
    }
}
