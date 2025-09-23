using Agraria.Contrato.Servicios;
using Agraria.Util.Validaciones;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.Usuarios
{
    public partial class UCIngresoUsuarios : UserControl
    {
        
        private readonly IUsuariosService _usuariosService;
        private readonly IUsuariosTipoService _usuariosTipoService;
        private readonly IPreguntasSeguridadService _preguntasSeguridadService;

        private Modelo.Entidades.Usuarios _usuarioSeleccionado;

        private readonly ValidadorTextBox _vTxtDni;
        private readonly ValidadorTextBox _vTxtApellido;
        private readonly ValidadorTextBox _vTxtNombre;
        private readonly ValidadorTextBox _vTxtTel;
        private readonly ValidadorTextBox _vTxtEmail;
        private readonly ValidadorTextBox _vTxtContra;
        private readonly ValidadorTextBox _vTxtContraDos;
        private readonly ValidadorTextBox _vTxtRespues;
        private readonly ErrorProvider _epDni;
        private readonly ErrorProvider _epApellido;
        private readonly ErrorProvider _epNombre;
        private readonly ErrorProvider _epTel;
        private readonly ErrorProvider _epEmail;
        private readonly ErrorProvider _epContra;
        private readonly ErrorProvider _epContraDos;
        private readonly ErrorProvider _epRespues;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCIngresoUsuarios"/>.
        /// </summary>
        /// <param name="usuariosService">El servicio de usuarios.</param>
        /// <param name="usuariosTipoService">El servicio de tipos de usuario.</param>
        /// <param name="preguntasSeguridadService">El servicio de preguntas de seguridad.</param>
        public UCIngresoUsuarios(IUsuariosService usuariosService, IUsuariosTipoService usuariosTipoService, IPreguntasSeguridadService preguntasSeguridadService)
        {
            _usuariosService = usuariosService;
            _usuariosTipoService = usuariosTipoService;
            _preguntasSeguridadService = preguntasSeguridadService;
            InitializeComponent();
            _usuarioSeleccionado = new Modelo.Entidades.Usuarios();

            _epDni = new ErrorProvider();
            _vTxtDni = new ValidadorDni(TxtDni, _epDni)
            {
                MensajeError = "El DNI ingresado no es válido.\nIngrese 8 digitos 12345678.\nSino tiene DNI ingrese cero (0)"
            };

            _epApellido = new ErrorProvider();
            _vTxtApellido = new ValidadorNombre(TxtApellido, _epApellido)
            {
                MensajeError = "El apelido del proveedor no puede estar vacío."
            };

            _epNombre = new ErrorProvider();
            _vTxtNombre = new ValidadorNombre(TxtNombre, _epNombre)
            {
                MensajeError = "El nombre no puede estar vacío."
            };

            _epTel = new ErrorProvider();
            _vTxtTel = new ValidadorEntero(TxtTel, _epTel)
            {
                MensajeError = "El teléfono ingresado no es válido.\nSino tiene telefono ingrese cero (0)"
            };

            _epEmail = new ErrorProvider();
            _vTxtEmail = new ValidadorEmail(TxtEmail, _epEmail)
            {
                MensajeError = "El email ingresado no es válido."
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

        }

        /// <summary>
        /// Maneja el evento de carga del control de usuario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private async void UCIngresoUsuarios_Load(object sender, EventArgs e)
        {
            TxtDni.Focus();
            ConfigBtns();
            await Task.WhenAll(
                
                CargarTiposUsuarios(),
                CargarPreguntasSeguridad()
            );
           

            // Establecer un valor predeterminado para el combo box de preguntas
            if (CMBPregunta.Items.Count > 0)
            {
                CMBPregunta.SelectedIndex = 0;
            }
            TxtContra_PassqordChar();
        }

        /// <summary>
        /// Carga los tipos de usuario en el ComboBox.
        /// </summary>
        private async Task CargarTiposUsuarios()
        {
            var tiposUsuarios = await _usuariosTipoService.GetAll();

            if (tiposUsuarios.IsSuccess && tiposUsuarios.Value != null)
            {
                CMBTipoUsuario.DataSource = null;
                CMBTipoUsuario.DataSource = tiposUsuarios.Value;
                CMBTipoUsuario.DisplayMember = "Descripcion";
                CMBTipoUsuario.ValueMember = "Tipo";

            }
            else
            {
                MessageBox.Show("Error al cargar los tipos de usuarios: " + tiposUsuarios.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las preguntas de seguridad en el ComboBox.
        /// </summary>
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

        /// <summary>
        /// Maneja el evento de cambio de texto en el cuadro de texto de DNI.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void TxtDni_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtDni, _vTxtApellido, _vTxtNombre, _vTxtTel, _vTxtEmail, _vTxtContra, _vTxtContraDos, _vTxtRespues);
            if (TxtContra.Text != TxtContraDos.Text)
            {
                LblError.Visible = true;
            }
            else
            {
                LblError.Visible = false;
            }
        }

        /// <summary>
        /// Crea un objeto de usuario a partir de los datos del formulario.
        /// </summary>
        private void CrearUsuario()
        {
            if (CMBTipoUsuario.SelectedValue is not int tipoUsuario)
            {
                MessageBox.Show("El tipo de usuario seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idPregunta = 0;
            if (CMBPregunta.SelectedValue is int preguntaId)
            {
                idPregunta = preguntaId;
            }

            _usuarioSeleccionado = new Modelo.Entidades.Usuarios
            {
                Apellido = TxtApellido.Text,
                DNI = TxtDni.Text,
                Nombre = TxtNombre.Text,
                Tel = TxtTel.Text,
                Mail = TxtEmail.Text,
                Id_Tipo = tipoUsuario,
                Contra = TxtContra.Text, // Contraseña por defecto al crear un nuevo usuario
                Respues = TxtRespues.Text,
                Id_Pregunta = idPregunta,
                Activo = ChkActivo.Checked
            };
        }

        /// <summary>
        /// Maneja el evento de clic en el botón Ingresar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea ingresar el usuario?", "Confirmación de ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes)
            {
                return; // Salir si el usuario no confirma
            }
            CrearUsuario();
            Result<Modelo.Entidades.Usuarios> resultado = _usuariosService.Add(_usuarioSeleccionado);

            if (resultado.IsSuccess)
            {
                MessageBox.Show("Usuario ingresado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Utilidades.Util.LimpiarForm(TLPForm, TxtDni);
            }
            else
            {
                MessageBox.Show($"{resultado.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura los botones del formulario.
        /// </summary>
        private void ConfigBtns()
        {
            BtnIngresar.Tag = AppColorsBlue.Primary;
        }

        /// <summary>
        /// Maneja el evento de cambio de estado de habilitación del botón Ingresar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnIngresar_EnabledChanged(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Tag is Color color)
                {
                    btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;
                }
            }
        }

        private void TxtContra_PassqordChar()
        {
            TxtContra.PasswordChar = '\uFFFD';
            TxtContraDos.PasswordChar = '\uFFFD';

        }
    }
}
