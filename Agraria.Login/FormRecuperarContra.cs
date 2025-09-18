using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using Agraria.Util.Validaciones;

namespace Agraria.Login
{
    public partial class FormRecuperarContra : Form
    {
        private readonly IPreguntasSeguridadService _preguntasSeguridadService;
        private readonly IUsuariosService _usuariosService;
        private readonly ValidadorTextBox _vTxtDni;
        private readonly ValidadorTextBox _vTxtContra;
        private readonly ValidadorTextBox _vTxtContraDos;
        private readonly ValidadorTextBox _vTxtRespues;
        private readonly ErrorProvider _epDni;
        private readonly ErrorProvider _epContra;
        private readonly ErrorProvider _epContraDos;
        private readonly ErrorProvider _epRespues;

        public FormRecuperarContra(IPreguntasSeguridadService preguntasSeguridadService, IUsuariosService usuariosService)
        {
            _preguntasSeguridadService = preguntasSeguridadService;
            _usuariosService = usuariosService;
            InitializeComponent();

            _epDni = new ErrorProvider();
            _vTxtDni = new ValidadorDni(TxtDNI, _epDni)
            {
                MensajeError = "El DNI ingresado no es válido.\nIngrese 8 digitos 12345678."
            };
            _epContra = new ErrorProvider();
            _vTxtContra = new ValidadorPassword(TxtContra, _epContra);
            _epContraDos = new ErrorProvider();
            _vTxtContraDos = new ValidadorPassword(TxtContraDos, _epContraDos);
            _epRespues = new ErrorProvider();
            _vTxtRespues = new ValidadorNombre(TxtRespues, _epRespues)
            {
                MensajeError = "La respuesta no puede estar vacía."
            };

            // Initialize error label visibility
            LblInicioError.Visible = false;
        }

        private async void FormRecuperarContra_Load(object sender, EventArgs e)
        {
            await CargarPreguntasSeguridad();
        }

        private async Task CargarPreguntasSeguridad()
        {
            var preguntas = await _preguntasSeguridadService.GetAll();

            if (preguntas.IsSuccess && preguntas.Value != null)
            {
                CMBPregunta.DataSource = null;
                CMBPregunta.DataSource = preguntas.Value;
                CMBPregunta.DisplayMember = "Pregunta";
                CMBPregunta.ValueMember = "Id_Pregunta";
            }
            else
            {
                MessageBox.Show("Error al cargar las preguntas de seguridad: " + preguntas.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnIngresar_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(TxtDNI.Text) ||
                string.IsNullOrWhiteSpace(TxtRespues.Text) ||
                string.IsNullOrWhiteSpace(TxtContra.Text) ||
                string.IsNullOrWhiteSpace(TxtContraDos.Text))
            {
                LblInicioError.Text = "Todos los campos son obligatorios.";
                LblInicioError.Visible = true;
                return;
            }

            // Check if passwords match
            if (TxtContra.Text != TxtContraDos.Text)
            {
                LblInicioError.Text = "Las contraseñas no coinciden.";
                LblInicioError.Visible = true;
                return;
            }

            // Hide error message initially
            LblInicioError.Visible = false;

            try
            {
                // Get selected question ID
                int preguntaId = 0;
                if (CMBPregunta.SelectedValue is int id)
                {
                    preguntaId = id;
                }
                else if (CMBPregunta.SelectedValue != null)
                {
                    // Handle case where ValueMember might be a string
                    if (int.TryParse(CMBPregunta.SelectedValue.ToString(), out int parsedId))
                    {
                        preguntaId = parsedId;
                    }
                }

                // Validate user credentials
                var result = await _usuariosService.GetByDniAndQuestionAndAnswer(TxtDNI.Text, preguntaId, TxtRespues.Text);

                if (result.IsSuccess && result.Value != null)
                {
                    // Update user's password
                    var usuario = result.Value;
                    usuario.Contra = TxtContra.Text;

                    var updateResult = _usuariosService.Update(usuario);

                    if (updateResult.IsSuccess)
                    {
                        MessageBox.Show("Contraseña actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        LblInicioError.Text = "Error al actualizar la contraseña: " + updateResult.Error;
                        LblInicioError.Visible = true;
                    }
                }
                else
                {
                    LblInicioError.Text = "Datos incorrectos. Verifique DNI, pregunta y respuesta.";
                    LblInicioError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la recuperación de contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LblInicioError.Text = "Error durante la recuperación de contraseña.";
                LblInicioError.Visible = true;
            }
        }

        private void TxtDNI_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtDni, _vTxtRespues, _vTxtContra, _vTxtContraDos);
            if (TxtContra.Text != TxtContraDos.Text)
            {
                LblInicioError.Visible = true;
            }
            else { LblInicioError.Visible = false; }
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

        private void TxtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (BtnIngresar.Enabled && e.KeyChar == (char)Keys.Enter)
            {
                BtnIngresar_Click(sender, e);
            }
        }
    }
}
