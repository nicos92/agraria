using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util.Validaciones;
using Agraria.Utilidades;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.EntornoFormativo
{
    public partial class UCConsultaEntornoFormativo : UserControl
    {


        #region Campos y Servicios

        private readonly ILogger<UCConsultaEntornoFormativo> _logger;
        private readonly ITipoEntornosService _tipoEntornoService;
        private readonly IEntornoService _entornoService;
        private readonly IUsuariosService _usuarioService;
        private readonly IEntornoFormativoService _entornoFormativoService;

        private List<TipoEntorno> _listaTipoEntorno;
        private List<Modelo.Entidades.Usuarios> _listaUsuarios;
        private List<Modelo.Entidades.EntornoFormativo> _listaEntornosFormativos;
        private Modelo.Entidades.EntornoFormativo? _entornoFormativoSeleccionado;
        private List<Modelo.Entidades.EntornoFormativo> _listaEntornosFormativosOriginal;

        private readonly ValidadorTextBox _vTxtCursoAnio;
        private readonly ValidadorTextBox _vTxtCursoDivision;
        private readonly ValidadorTextBox _vTxtCursoGrupo;
        private readonly ValidadorTextBox _vTxtObservacion;



        #endregion

        #region Constructor

        public UCConsultaEntornoFormativo(
            ITipoEntornosService tipoEntornoService,
            IEntornoService entornoService,
            IUsuariosService usuarioService,
            IEntornoFormativoService entornoFormativoService,
            ILogger<UCConsultaEntornoFormativo> logger)
        {
            InitializeComponent();

            _logger = logger;
            _tipoEntornoService = tipoEntornoService;
            _entornoService = entornoService;
            _usuarioService = usuarioService;
            _entornoFormativoService = entornoFormativoService;

            _listaTipoEntorno = [];
            _listaUsuarios = [];
            _listaEntornosFormativos = [];

            _vTxtCursoAnio = new ValidadorDireccion(TxtCursoAnio, new ErrorProvider()) { MensajeError = "El curso/año no puede estar vacío y debe tener entre 1 y 10 caracteres." };
            _vTxtCursoDivision = new ValidadorDireccion(TxtCursoDivision, new ErrorProvider()) { MensajeError = "La división no puede estar vacía y debe tener entre 1 y 10 caracteres." };
            _vTxtCursoGrupo = new ValidadorDireccion(TxtCursoGrupo, new ErrorProvider()) { MensajeError = "El grupo no puede estar vacío y debe tener entre 1 y 10 caracteres." };
            _vTxtObservacion = new ValidadorDireccion(TxtObservacion, new ErrorProvider()) { MensajeError = "La observación no puede estar vacía y debe tener entre 1 y 255 caracteres." };

            _logger.LogInformation("UCConsultaEntornoFormativo inicializado.");
        }

        #endregion

        #region Eventos

        private void UCConsultaEntornoFormativo_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("UCConsultaEntornoFormativo cargado.");
            ConfigurarDGV();
            TareasLargas tareasLargas = new(TLPForm, ProgressBar, CargaDeDatos, LLenarCMBGrilla);
            tareasLargas.Iniciar();

            //CargarDGVEntornosFormativos();

            //CargarCMBs();
            //LimpiarFormulario();
        }

        private void LLenarCMBGrilla()
        {
            this.Invoke(
                () =>
                {
                    _logger.LogInformation("Llenando ComboBoxes y grilla.");
                    CargarDGVEntornosFormativos();

                    CargarCMBs();
                    LimpiarFormulario();

                    // Inicializar los filtros con valores por defecto
                    CMFTipoEntorno.SelectedIndex = -1;
                    CMBFiltroEntorno.DataSource = null;
                    CMBFiltroEntorno.SelectedIndex = -1;
                    CMBFiltroEntornoFormativo.DataSource = null;
                    CMBFiltroEntornoFormativo.SelectedIndex = -1;

                    _logger.LogInformation("ComboBoxes y grilla llenados exitosamente.");
                });

        }

        private async Task CargaDeDatos()
        {
            _logger.LogInformation("Iniciando carga de datos.");
            await Task.WhenAll(
                            CargaInicial(),
                            CargarGrilla()
                            );
            _logger.LogInformation("Carga de datos completada.");
        }

        private async void DgvEntornosFormativos_SelectionChanged(object sender, EventArgs e)
        {
            _logger.LogDebug("Cambio de selección en DataGridView de entornos formativos.");
            if (DgvEntornosFormativos.SelectedRows.Count > 0 && DgvEntornosFormativos.SelectedRows[0].DataBoundItem is Modelo.Entidades.EntornoFormativo item)
            {
                // Buscar el objeto EntornoFormativo original usando el ID
                Modelo.Entidades.EntornoFormativo? entornoFormativo = _listaEntornosFormativos.FirstOrDefault(ef => ef.Id_Entorno_Formativo == item.Id_Entorno_Formativo);
                _entornoFormativoSeleccionado = entornoFormativo;

                if (_entornoFormativoSeleccionado != null)
                {
                    _logger.LogInformation("Entorno formativo seleccionado con ID: {IdEntornoFormativo}", _entornoFormativoSeleccionado.Id_Entorno_Formativo);
                    await PoblarFormulario(_entornoFormativoSeleccionado);
                    BtnGuardar.Enabled = true;
                }
            }
        }

        private async void CMBTipoEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logger.LogInformation("Cambio de selección en ComboBox de tipo de entorno.");
            if (CMBTipoEntorno.SelectedValue is int idTipoEntorno)
            {
                await CargarEntornos(idTipoEntorno);
            }
        }

        private async void CMFTipoEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logger.LogInformation("Cambio de selección en ComboBox de filtro de tipo de entorno.");
            if (CMFTipoEntorno.SelectedValue is int idTipoEntorno)
            {
                await CargarEntornosFiltro(idTipoEntorno);
            }
        }

        private async void CMBFiltroEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logger.LogInformation("Cambio de selección en ComboBox de filtro de entorno.");
            if (CMBFiltroEntorno.SelectedValue is int idEntorno)
            {
                await CargarEntornosFormativosFiltro(idEntorno);
            }
        }



        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("Botón Guardar clickeado.");
            if (!ValidarCampos())
            {
                _logger.LogWarning("Validación de campos fallida.");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("¿Esta seguro que quiere guardar los cambios?", "Guardar Cambios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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

                if (_entornoFormativoSeleccionado != null && _entornoFormativoSeleccionado.Id_Entorno_Formativo != 0)
                {
                    entornoFormativo.Id_Entorno_Formativo = _entornoFormativoSeleccionado.Id_Entorno_Formativo;
                    _logger.LogInformation("Actualizando entorno formativo con ID: {IdEntornoFormativo}", _entornoFormativoSeleccionado.Id_Entorno_Formativo);
                    resultado = await _entornoFormativoService.Update(entornoFormativo);



                    if (resultado.IsSuccess)
                    {
                        _logger.LogInformation("Entorno formativo actualizado exitosamente.");
                        MessageBox.Show("Operación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarGrilla();
                        LimpiarFormulario();
                    }
                    else
                    {
                        _logger.LogError("Error al actualizar entorno formativo: {ErrorMessage}", resultado.Error);
                        MessageBox.Show(resultado.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UCConsultaEntornoFormativo_VisibleChanged(object sender, EventArgs e)
        {

            if (Visible)
            {
                _logger.LogInformation("Visibilidad del control cambiada a: {Visible}", Visible);
                // Only reload data if lists are empty (first load or after being cleared)
                if (_listaTipoEntorno == null || _listaTipoEntorno.Count == 0 ||
                    _listaUsuarios == null || _listaUsuarios.Count == 0)
                {
                    TareasLargas tareasLargas = new(TLPForm, ProgressBar, CargaDeDatos, LLenarCMBGrilla);
                    tareasLargas.Iniciar();
                }
                else
                {
                    // If data is already loaded, just refill the combos and grid
                    this.Invoke(() =>
                    {
                        CargarCMBs();
                        CargarDGVEntornosFormativos();
                    });
                }

            }


        }

        private void TxtCursoAnio_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnGuardar, _vTxtCursoAnio, _vTxtCursoDivision, _vTxtCursoGrupo, _vTxtObservacion);
        }

        private async void BtnAplicarFiltros_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("Botón Aplicar Filtros clickeado.");

            // Obtener los valores seleccionados en los filtros
            var idTipoEntorno = CMFTipoEntorno.SelectedValue as int?;
            var idEntorno = CMBFiltroEntorno.SelectedValue as int?;
            var nombreEntornoFormativo = CMBFiltroEntornoFormativo.SelectedValue as string;

            // Filtrar la lista original según los criterios seleccionados
            IEnumerable<Modelo.Entidades.EntornoFormativo> listaFiltrada = _listaEntornosFormativosOriginal.AsEnumerable();

            if (idTipoEntorno.HasValue && idTipoEntorno.Value > 0)
            {
                // Para filtrar por tipo de entorno, necesitamos relacionar con los entornos
                // Obtener la lista de IDs de entornos que pertenecen al tipo de entorno seleccionado
                var resultadoEntornos = await _entornoService.GetAllxEntorno(idTipoEntorno.Value);
                if (resultadoEntornos.IsSuccess)
                {
                    var idsEntornos = resultadoEntornos.Value.Select(e => e.Id_Entorno).ToList();
                    listaFiltrada = listaFiltrada.Where(ef => idsEntornos.Contains(ef.Id_Entorno));
                }
            }

            if (idEntorno.HasValue && idEntorno.Value > 0)
            {
                listaFiltrada = listaFiltrada.Where(ef => ef.Id_Entorno == idEntorno.Value);
            }

            if (!string.IsNullOrEmpty(nombreEntornoFormativo))
            {
                listaFiltrada = listaFiltrada.Where(ef =>
                    (ef.Usuario_Nombre + " " + ef.Usuario_Apellido).Contains(nombreEntornoFormativo) ||
                    ef.Entorno_Nombre.Contains(nombreEntornoFormativo) ||
                    ef.Curso_anio.Contains(nombreEntornoFormativo) ||
                    ef.Curso_Division.Contains(nombreEntornoFormativo) ||
                    ef.Curso_Grupo.Contains(nombreEntornoFormativo)
                );
            }

            _listaEntornosFormativos = listaFiltrada.ToList();
            CargarDGVEntornosFormativos();
        }

        private void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            _logger.LogInformation("Botón Limpiar Filtros clickeado.");

            // Limpiar los controles de filtro
            CMFTipoEntorno.SelectedIndex = -1;
            CMBFiltroEntorno.DataSource = null;
            CMBFiltroEntorno.SelectedIndex = -1;
            CMBFiltroEntornoFormativo.DataSource = null;
            CMBFiltroEntornoFormativo.SelectedIndex = -1;

            // Restaurar la lista original en el DataGridView
            _listaEntornosFormativos = _listaEntornosFormativosOriginal.ToList();
            CargarDGVEntornosFormativos();
        }

        #endregion

        #region Métodos Privados

        private async Task CargaInicial()
        {
            _logger.LogInformation("Iniciando carga inicial.");
            await Task.WhenAll(
                CargarTiposEntorno(),
                CargarUsuarios()
            );

            // Cargar también los tipos de entorno para los filtros
            CMFTipoEntorno.DataSource = new List<TipoEntorno>(); // Inicializar con una lista vacía para evitar errores
            CMFTipoEntorno.DisplayMember = "Tipo_Entorno";
            CMFTipoEntorno.ValueMember = "Id_Tipo_Entorno";

            // Ahora sí, cargar los tipos de entorno
            CMFTipoEntorno.DataSource = _listaTipoEntorno;

            _logger.LogInformation("Carga inicial completada.");
        }

        private async Task CargarGrilla()
        {
            _logger.LogInformation("Cargando grilla de entornos formativos.");
            var resultado = await _entornoFormativoService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaEntornosFormativosOriginal = resultado.Value;
                _listaEntornosFormativos = _listaEntornosFormativosOriginal.ToList();
                _logger.LogInformation("Grilla cargada exitosamente. Total de registros: {Count}", _listaEntornosFormativos.Count);
            }
            else
            {
                _logger.LogError("Error al cargar la grilla de entornos formativos: {ErrorMessage}", resultado.Error);
                MessageBox.Show(resultado.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDGVEntornosFormativos()
        {
            _logger.LogInformation("Cargando DataGridView de entornos formativos.");
            DgvEntornosFormativos.DataSource = null;

            DgvEntornosFormativos.DataSource = _listaEntornosFormativos;
            _logger.LogInformation("DataGridView de entornos formativos cargado exitosamente.");
        }

        private void ConfigurarDGV()
        {

            DgvEntornosFormativos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEntornosFormativos.AllowUserToAddRows = false;
            DgvEntornosFormativos.AllowUserToDeleteRows = false;
            DgvEntornosFormativos.ReadOnly = true;
            DgvEntornosFormativos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvEntornosFormativos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvEntornosFormativos.MultiSelect = false;
            DgvEntornosFormativos.RowHeadersVisible = false;
            DgvEntornosFormativos.AllowUserToResizeRows = false;
            DgvEntornosFormativos.AllowUserToResizeColumns = true;
            DgvEntornosFormativos.AutoGenerateColumns = false;

            // Asegurar que el DataGridView puede recibir el foco y selecciones
            DgvEntornosFormativos.TabStop = true;
            DgvEntornosFormativos.Enabled = true;

            ConfigurarColumnasDataGridView();

        }

        private void ConfigurarColumnasDataGridView()
        {
            DgvEntornosFormativos.Columns.Clear();

            var columns = new[]
            {
        new DataGridViewTextBoxColumn
        {
            Name = "Id_Entorno_Formativo",
            DataPropertyName = "Id_Entorno_Formativo",
            HeaderText = "ID",
            Visible = false
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Entorno_Nombre",
            DataPropertyName = "Entorno_Nombre",
            HeaderText = "Entorno",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Usuario_Apellido",
            DataPropertyName = "Usuario_Apellido",
            HeaderText = "Apellido",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Usuario_Nombre",
            DataPropertyName = "Usuario_Nombre",
            HeaderText = "Nombre",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Curso_Anio",
            DataPropertyName = "Curso_Anio",
            HeaderText = "Año",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Curso_Division",
            DataPropertyName = "Curso_Division",
            HeaderText = "Division",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Curso_Grupo",
            DataPropertyName = "Curso_Grupo",
            HeaderText = "Grupo",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        }
    };

            foreach (var column in columns)
            {
                DgvEntornosFormativos.Columns.Add(column);
            }
        }

        private void CargarCMBs()
        {
            CMBUsuario.DataSource = _listaUsuarios;
            CMBUsuario.DisplayMember = "Dato";
            CMBUsuario.ValueMember = "Id_Usuario";

            CMBEntorno.DataSource = null;
            CMBTipoEntorno.DataSource = _listaTipoEntorno;
            CMBTipoEntorno.DisplayMember = "Area";
            CMBTipoEntorno.ValueMember = "Id_Area";

            // También aseguramos que el combo de filtro esté inicializado
            CMFTipoEntorno.DataSource = null;
            CMFTipoEntorno.DataSource = _listaTipoEntorno;
            CMFTipoEntorno.DisplayMember = "Area";
            CMFTipoEntorno.ValueMember = "Id_Area";
        }

        private async Task CargarTiposEntorno()
        {
            _logger.LogInformation("Cargando tipos de entorno.");
            var resultado = await _tipoEntornoService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaTipoEntorno = resultado.Value;
                _logger.LogInformation("Tipos de entorno cargados exitosamente. Total: {Count}", _listaTipoEntorno.Count);
            }
            else
            {
                _logger.LogError("Error al cargar tipos de entorno: {ErrorMessage}", resultado.Error);
            }
        }

        private async Task CargarUsuarios()
        {
            _logger.LogInformation("Cargando usuarios.");
            var resultado = await _usuarioService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaUsuarios = resultado.Value;
                _logger.LogInformation("Usuarios cargados exitosamente. Total: {Count}", _listaUsuarios.Count);
            }
            else
            {
                _logger.LogError("Error al cargar usuarios: {ErrorMessage}", resultado.Error);
            }
        }

        private async Task CargarEntornos(int idTipoEntorno)
        {
            _logger.LogInformation("Cargando entornos para tipo de entorno ID: {IdTipoEntorno}", idTipoEntorno);
            var resultado = await _entornoService.GetAllxEntorno(idTipoEntorno);
            if (resultado.IsSuccess)
            {
                CMBEntorno.DataSource = resultado.Value;
                CMBEntorno.DisplayMember = "Entorno_Nombre";
                CMBEntorno.ValueMember = "Id_Entorno";
                _logger.LogInformation("Entornos cargados exitosamente para tipo de entorno ID: {IdTipoEntorno}. Total: {Count}", idTipoEntorno, resultado.Value.Count);
            }
            else
            {
                _logger.LogError("Error al cargar entornos para tipo de entorno ID: {IdTipoEntorno}. Error: {ErrorMessage}", idTipoEntorno, resultado.Error);
            }
        }

        private async Task PoblarFormulario(Modelo.Entidades.EntornoFormativo entornoFormativo)
        {
            _logger.LogInformation("Poblando formulario con datos del entorno formativo ID: {IdEntornoFormativo}", entornoFormativo.Id_Entorno_Formativo);
            // Desactivar evento para evitar recargas no deseadas
            //CMBTipoEntorno.SelectedIndexChanged -= CMBTipoEntorno_SelectedIndexChanged;

            var resultadoEntorno = _entornoService.GetById(entornoFormativo.Id_Entorno);
            if (resultadoEntorno.IsSuccess && resultadoEntorno.Value != null)
            {
                var entornoPadre = resultadoEntorno.Value;

                // 1. Seleccionar el Tipo de Entorno
                CMBTipoEntorno.SelectedValue = entornoPadre.Id_Area;

                // 2. Cargar los entornos hijos para ese tipo
                await CargarEntornos(entornoPadre.Id_Area);

                // 3. Seleccionar el Entorno específico
                CMBEntorno.SelectedValue = entornoFormativo.Id_Entorno;
            }

            // Reactivar el evento
            //CMBTipoEntorno.SelectedIndexChanged += CMBTipoEntorno_SelectedIndexChanged;

            // Poblar el resto de los campos
            CMBUsuario.SelectedValue = entornoFormativo.Id_Usuario;
            TxtCursoAnio.Text = entornoFormativo.Curso_anio;
            TxtCursoDivision.Text = entornoFormativo.Curso_Division;
            TxtCursoGrupo.Text = entornoFormativo.Curso_Grupo;
            TxtObservacion.Text = entornoFormativo.Observaciones;
            ChkActivo.Checked = entornoFormativo.Activo;
            _logger.LogInformation("Formulario poblado exitosamente.");
        }

        private void LimpiarFormulario()
        {
            _logger.LogInformation("Limpiando formulario.");
            _entornoFormativoSeleccionado = null;
            DgvEntornosFormativos.ClearSelection();
            TxtCursoAnio.Clear();
            TxtCursoDivision.Clear();
            TxtCursoGrupo.Clear();
            TxtObservacion.Clear();
            ChkActivo.Checked = true;
            CMBTipoEntorno.SelectedIndex = -1;
            CMBEntorno.DataSource = null;
            CMBUsuario.SelectedIndex = -1;
            BtnGuardar.Enabled = false; // Cambiado de true a false, ya que no hay selección
            _logger.LogInformation("Formulario limpiado exitosamente.");
        }

        private bool ValidarCampos()
        {
            _logger.LogDebug("Validando campos del formulario.");
            if (CMBTipoEntorno.SelectedValue == null || CMBEntorno.SelectedValue == null || CMBUsuario.SelectedValue == null ||
                string.IsNullOrWhiteSpace(TxtCursoAnio.Text) ||
                string.IsNullOrWhiteSpace(TxtCursoDivision.Text) ||
                string.IsNullOrWhiteSpace(TxtCursoGrupo.Text) ||
              string.IsNullOrWhiteSpace(TxtObservacion.Text))
            {
                _logger.LogWarning("Validación de campos fallida. Uno o más campos requeridos están vacíos.");
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            _logger.LogDebug("Validación de campos exitosa.");
            return true;
        }

        private async Task CargarEntornosFiltro(int idTipoEntorno)
        {
            _logger.LogInformation("Cargando entornos para filtro de tipo de entorno ID: {IdTipoEntorno}", idTipoEntorno);
            var resultado = await _entornoService.GetAllxEntorno(idTipoEntorno);
            if (resultado.IsSuccess)
            {
                CMBFiltroEntorno.DataSource = resultado.Value;
                CMBFiltroEntorno.DisplayMember = "Entorno_Nombre";
                CMBFiltroEntorno.ValueMember = "Id_Entorno";
                _logger.LogInformation("Entornos para filtro cargados exitosamente para tipo de entorno ID: {IdTipoEntorno}. Total: {Count}", idTipoEntorno, resultado.Value.Count);
            }
            else
            {
                _logger.LogError("Error al cargar entornos para filtro de tipo de entorno ID: {IdTipoEntorno}. Error: {ErrorMessage}", idTipoEntorno, resultado.Error);
            }
        }

        private async Task CargarEntornosFormativosFiltro(int idEntorno)
        {
            _logger.LogInformation("Cargando entornos formativos para filtro de entorno ID: {IdEntorno}", idEntorno);

            // Buscar entornos formativos que correspondan al entorno seleccionado
            var entornosFormativosParaEntorno = _listaEntornosFormativosOriginal
                .Where(ef => ef.Id_Entorno == idEntorno)
                .Select(ef => new
                {
                    NombreCompleto = ef.Usuario_Nombre + " " + ef.Usuario_Apellido,
                    CursoAnio = ef.Curso_anio,
                    CursoDivision = ef.Curso_Division,
                    CursoGrupo = ef.Curso_Grupo
                })
                .Distinct()
                .ToList();

            // Crear una lista de opciones para el combo
            var opciones = new List<object>();
            foreach (var ef in entornosFormativosParaEntorno)
            {
                opciones.Add(new
                {
                    Display = $"{ef.NombreCompleto} - {ef.CursoAnio} {ef.CursoDivision} {ef.CursoGrupo}",
                    Value = ef.NombreCompleto
                });
            }

            // Asegurarse de que haya un elemento seleccionado por defecto
            if (opciones.Count > 0)
            {


                CMBFiltroEntornoFormativo.DataSource = opciones;
                CMBFiltroEntornoFormativo.DisplayMember = "Display";
                CMBFiltroEntornoFormativo.ValueMember = "Value";

                CMBFiltroEntornoFormativo.SelectedIndex = 0;
            }
            else
            {
                CMBFiltroEntornoFormativo.DataSource = null;
            }
            _logger.LogInformation("Entornos formativos para filtro cargados exitosamente para entorno ID: {IdEntorno}. Total: {Count}", idEntorno, entornosFormativosParaEntorno.Count);
        }

        #endregion


       
    }
}