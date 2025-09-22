using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.UI.Properties;
using Agraria.Util.Validaciones;
using Agraria.Utilidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.EntornoFormativo
{
    public partial class UCIngresoEntornoFormativo : UserControl
    {
        #region Servicios y Campos

        private readonly ILogger<UCIngresoEntornoFormativo> _logger;
        private readonly ITipoEntornosService _tipoEntornoService;
        private readonly IEntornoService _entornoService;
        private readonly IUsuariosService _usuarioService;
        private readonly IEntornoFormativoService _entornoFormativoService;

        private List<TipoEntorno> _listaTipoEntorno = [];
        private List<Modelo.Entidades.Usuarios> _listaUsuarios = [];
        private Modelo.Entidades.EntornoFormativo? _entornoFormativoActual;
        private TareasLargas? _tareaLarga;

        private readonly ValidadorTextBox _vTxtCursoAnio;
        private readonly ValidadorTextBox _vTxtCursoDivision;
        private readonly ValidadorTextBox _vTxtCursoGrupo;
        private readonly ValidadorTextBox _vTxtObservacion;

        #endregion

        #region Constructor

        public UCIngresoEntornoFormativo(ITipoEntornosService tipoEntornoService, IEntornoService entornoService, IUsuariosService usuarioService, IEntornoFormativoService entornoFormativoService, ILogger<UCIngresoEntornoFormativo> logger)
        {
            InitializeComponent();

            _logger = logger;
            _tipoEntornoService = tipoEntornoService;
            _entornoService = entornoService;
            _usuarioService = usuarioService;
            _entornoFormativoService = entornoFormativoService;

            _vTxtCursoAnio = new ValidadorDireccion(TxtCursoAnio, new ErrorProvider()) { MensajeError = "El curso/año no puede estar vacío y debe tener entre 1 y 10 caracteres." };
            _vTxtCursoDivision = new ValidadorDireccion(TxtCursoDivision, new ErrorProvider()) { MensajeError = "La división no puede estar vacía y debe tener entre 1 y 10 caracteres." };
            _vTxtCursoGrupo = new ValidadorDireccion(TxtCursoGrupo, new ErrorProvider()) { MensajeError = "El grupo no puede estar vacío y debe tener entre 1 y 10 caracteres." };
            _vTxtObservacion = new ValidadorDireccion(TxtObservacion, new ErrorProvider()) { MensajeError = "La observación no puede estar vacía y debe tener entre 1 y 255 caracteres." };

            // Cambiar el nombre del botón en el diseñador si es necesario, o aquí:
            BtnIngresar.Text = "GUARDAR";
            
            // Initialize Activo checkbox to true by default
            ChkActivo.Checked = true;
            
            _logger.LogInformation("UCIngresoEntornoFormativo inicializado.");
        }

        #endregion

        #region Eventos del Control

        private void UCIngresoEntornoFormativo_Load(object sender, EventArgs e)
        {            
            _logger.LogInformation("UCIngresoEntornoFormativo cargado.");
            // Iniciar la carga inicial con barra de progreso
            _tareaLarga = new TareasLargas(PanelMedio, ProgressBar, CargaInicialControles, LimpiarFormulario);
            
            _tareaLarga.Iniciar();
        }

        private async void CMBCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logger.LogInformation("Cambio de selección en ComboBox de categoría.");
            if (CMBTipoEntorno.SelectedItem is TipoEntorno tipoEntorno)
            {
                await CargarEntornos(tipoEntorno.Id_Tipo_Entorno);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("Botón Ingresar clickeado.");
            if (!ValidarCampos()) 
            {
                _logger.LogWarning("Validación de campos fallida.");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("¿Estas de Acuerdo en Ingresar el Entorno Formativo?", "Ingreso Entorno Formativo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.OK) 
            {
                _logger.LogInformation("Operación cancelada por el usuario.");
                return;
            }

            if (CMBEntorno.SelectedValue is int identorno && CMBUsuario.SelectedValue is int idusuario)
            {


                var entornoFormativo = new Modelo.Entidades.EntornoFormativo
                {
                    Id_Entorno = identorno,
                    Id_Usuario = idusuario,
                    Curso_anio = TxtCursoAnio.Text,
                    Curso_Division = TxtCursoDivision.Text,
                    Curso_Grupo = TxtCursoGrupo.Text,
                    Observaciones = TxtObservacion.Text,
                    Activo = ChkActivo.Checked
                };

                Result<Modelo.Entidades.EntornoFormativo> resultado;

                
                    // Inserción
                    _logger.LogInformation("Intentando agregar nuevo entorno formativo.");
                    resultado = _entornoFormativoService.Add(entornoFormativo);
                

                if (resultado.IsSuccess)
                {
                    _logger.LogInformation("Entorno formativo agregado exitosamente.");
                    MessageBox.Show("Operación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
                else
                {
                    _logger.LogError("Error al agregar entorno formativo: {ErrorMessage}", resultado.Error);
                    MessageBox.Show(resultado.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Métodos Públicos

       

        public void LimpiarFormulario()
        {
            _logger.LogInformation("Limpiando formulario.");
            _entornoFormativoActual = null;
            TxtCursoAnio.Clear();
            TxtCursoDivision.Clear();
            TxtCursoGrupo.Clear();
            TxtObservacion.Clear();
            ChkActivo.Checked = true;
            
            // Set default selections
            if (_listaUsuarios.Count > 0)
                CMBUsuario.SelectedIndex = 0;
            else
                CMBUsuario.SelectedIndex = -1;
                
            if (_listaTipoEntorno.Count > 0)
            {
                CMBTipoEntorno.SelectedIndex = 0;
                // Load entornos for the default selected tipo entorno
                var defaultTipoEntorno = _listaTipoEntorno[0];
                _ = CargarEntornos(defaultTipoEntorno.Id_Tipo_Entorno);
            }
            else
            {
                CMBTipoEntorno.SelectedIndex = -1;
                CMBEntorno.DataSource = null;
            }
                
            BtnIngresar.Enabled = false;
        }

        #endregion

        #region Métodos Privados

        private void CargaInicialControles()
        {
            _logger.LogInformation("Iniciando carga inicial de controles.");
            // Ejecutar las tareas de carga de forma paralela
            var tareaTipoEntornos = CargarTipoEntornos();
            var tareaUsuarios = CargarUsuarios();
            
            // Esperar a que ambas tareas se completen
            Task.WaitAll(tareaTipoEntornos, tareaUsuarios);
            
            // Cargar los ComboBoxes en el hilo de UI
            Invoke((MethodInvoker)delegate {
                CargarCMBs();
            });
            _logger.LogInformation("Carga inicial de controles completada.");
        }

        private void CargarCMBs()
        {
            _logger.LogInformation("Cargando ComboBoxes.");
            CMBUsuario.DataSource = _listaUsuarios;
            CMBUsuario.DisplayMember = "Dato"; 
            CMBUsuario.ValueMember = "Id_Usuario";

            CMBTipoEntorno.DataSource = _listaTipoEntorno;
            CMBTipoEntorno.DisplayMember = "Tipo_Entorno";
            CMBTipoEntorno.ValueMember = "Id_Tipo_Entorno";

            // Set default selections
            if (_listaUsuarios.Count > 0)
                CMBUsuario.SelectedIndex = 0;
            
            if (_listaTipoEntorno.Count > 0)
            {
                CMBTipoEntorno.SelectedIndex = 0;
                // Load entornos for the default selected tipo entorno
                var defaultTipoEntorno = _listaTipoEntorno[0];
                // We need to invoke this on the UI thread
                var task = CargarEntornos(defaultTipoEntorno.Id_Tipo_Entorno);
                task.Wait(); // Wait for the task to complete
            }
            _logger.LogInformation("ComboBoxes cargados exitosamente.");
        }

        private async Task CargarUsuarios()
        {
            _logger.LogInformation("Cargando usuarios.");
            var result = await _usuarioService.GetAll();
            if (result.IsSuccess) 
            {
                _listaUsuarios = result.Value;
                _logger.LogInformation("Usuarios cargados exitosamente. Total: {Count}", _listaUsuarios.Count);
            }
            else
            {
                _logger.LogError("Error al cargar usuarios: {ErrorMessage}", result.Error);
            }
        }

        private async Task CargarTipoEntornos()
        {
            _logger.LogInformation("Cargando tipos de entorno.");
            var result = await _tipoEntornoService.GetAll();
            if (result.IsSuccess) 
            {
                _listaTipoEntorno = result.Value;
                _logger.LogInformation("Tipos de entorno cargados exitosamente. Total: {Count}", _listaTipoEntorno.Count);
            }
            else
            {
                _logger.LogError("Error al cargar tipos de entorno: {ErrorMessage}", result.Error);
            }
        }

        private async Task CargarEntornos(int idTipoEntorno)
        {
            _logger.LogInformation("Cargando entornos para tipo de entorno ID: {IdTipoEntorno}", idTipoEntorno);
            var result = await _entornoService.GetAllxEntorno(idTipoEntorno);
            if (result.IsSuccess)
            {
                CMBEntorno.DataSource = result.Value;
                CMBEntorno.DisplayMember = "Entorno_Nombre"; // Asumiendo esta propiedad
                CMBEntorno.ValueMember = "Id_Entorno";
                _logger.LogInformation("Entornos cargados exitosamente para tipo de entorno ID: {IdTipoEntorno}. Total: {Count}", idTipoEntorno, result.Value.Count);
            }
            else
            {
                _logger.LogError("Error al cargar entornos para tipo de entorno ID: {IdTipoEntorno}. Error: {ErrorMessage}", idTipoEntorno, result.Error);
            }
        }

        private bool ValidarCampos()
        {
            _logger.LogDebug("Validando campos del formulario.");
            // Habilitar el botón si todos los campos requeridos tienen texto.
            bool camposDeTextoValidos = !string.IsNullOrWhiteSpace(TxtCursoAnio.Text) &&
                                        !string.IsNullOrWhiteSpace(TxtCursoDivision.Text) &&
                                        !string.IsNullOrWhiteSpace(TxtCursoGrupo.Text);

            bool combosValidos = CMBTipoEntorno.SelectedValue != null &&
                                 CMBEntorno.SelectedValue != null &&
                                 CMBUsuario.SelectedValue != null;

            if (!camposDeTextoValidos || !combosValidos)
            {
                _logger.LogWarning("Validación de campos fallida. Campos de texto válidos: {CamposDeTextoValidos}, Combos válidos: {CombosValidos}", camposDeTextoValidos, combosValidos);
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            _logger.LogDebug("Validación de campos exitosa.");
            return true;
        }

        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtCursoAnio, _vTxtCursoDivision, _vTxtCursoGrupo, _vTxtObservacion);
            
        }

       

        #endregion
    }
}