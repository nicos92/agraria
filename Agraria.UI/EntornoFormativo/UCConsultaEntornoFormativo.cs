using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Agraria.UI.EntornoFormativo
{
    public partial class UCConsultaEntornoFormativo : UserControl
    {


        #region Campos y Servicios

        private readonly ITipoEntornosService _tipoEntornoService;
        private readonly IEntornoService _entornoService;
        private readonly IUsuariosService _usuarioService;
        private readonly IEntornoFormativoService _entornoFormativoService;

        private List<TipoEntorno> _listaTipoEntorno;
        private List<Modelo.Entidades.Usuarios> _listaUsuarios;
        private List<Modelo.Entidades.EntornoFormativo> _listaEntornosFormativos;
        private Modelo.Entidades.EntornoFormativo _entornoFormativoSeleccionado;

        #endregion

        #region Constructor

        public UCConsultaEntornoFormativo(
            ITipoEntornosService tipoEntornoService,
            IEntornoService entornoService,
            IUsuariosService usuarioService,
            IEntornoFormativoService entornoFormativoService)
        {
            InitializeComponent();

            _tipoEntornoService = tipoEntornoService;
            _entornoService = entornoService;
            _usuarioService = usuarioService;
            _entornoFormativoService = entornoFormativoService;

            _listaTipoEntorno = [];
            _listaUsuarios = [];
            _listaEntornosFormativos = [];


        }

        #endregion

        #region Eventos

        private async void UCConsultaEntornoFormativo_Load(object sender, EventArgs e)
        {

            ConfigurarDGV();
            await Task.WhenAll(
                CargaInicial(),
                CargarGrilla()
                );


            LimpiarFormulario();
        }

        private async void DgvEntornosFormativos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvEntornosFormativos.SelectedRows.Count > 0 && DgvEntornosFormativos.SelectedRows[0].DataBoundItem is Modelo.Entidades.EntornoFormativo item)
            {
                // Buscar el objeto EntornoFormativo original usando el ID
                Modelo.Entidades.EntornoFormativo? entornoFormativo = _listaEntornosFormativos.FirstOrDefault(ef => ef.Id_Entorno_Formativo == item.Id_Entorno_Formativo);
                _entornoFormativoSeleccionado = entornoFormativo;

                if (_entornoFormativoSeleccionado != null)
                {
                    await PoblarFormulario(_entornoFormativoSeleccionado);
                    BtnGuardar.Enabled = true;
                }
            }
        }

        private async void CMBTipoEntorno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CMBTipoEntorno.SelectedValue is int idTipoEntorno)
            {
                await CargarEntornos(idTipoEntorno);
            }
        }



        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            var entornoFormativo = new Modelo.Entidades.EntornoFormativo
            {
                Id_Entorno = (int)CMBEntorno.SelectedValue,
                Id_Usuario = (int)CMBUsuario.SelectedValue,
                Curso_anio = TxtCursoAnio.Text,
                Curso_Division = TxtCursoDivision.Text,
                Curso_Grupo = TxtCursoGrupo.Text,
                Observaciones = TxtObservacion.Text
            };

            Result<Modelo.Entidades.EntornoFormativo> resultado;

            if (_entornoFormativoSeleccionado != null && _entornoFormativoSeleccionado.Id_Entorno_Formativo != 0)
            {
                entornoFormativo.Id_Entorno_Formativo = _entornoFormativoSeleccionado.Id_Entorno_Formativo;
                resultado = await _entornoFormativoService.Update(entornoFormativo);



                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Operación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarGrilla();
                    LimpiarFormulario();
                }
                else
                {
                    MessageBox.Show(resultado.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Métodos Privados

        private async Task CargaInicial()
        {
            await Task.WhenAll(
                CargarTiposEntorno(),
                CargarUsuarios()
            );
            CargarCMBs();
        }

        private async Task CargarGrilla()
        {
            var resultado = await _entornoFormativoService.GetAll();
            if (resultado.IsSuccess)
            {
                _listaEntornosFormativos = resultado.Value;
                DgvEntornosFormativos.DataSource = null;

                DgvEntornosFormativos.DataSource = _listaEntornosFormativos;
            }
            else
            {
                MessageBox.Show(resultado.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Name = "Usuario_Nombre",
            DataPropertyName = "Usuario_Nombre",
            HeaderText = "Usuario",
            Width = 150,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Curso_anio",
            DataPropertyName = "Curso_anio",
            HeaderText = "Año",
            Width = 80,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Curso_Division",
            DataPropertyName = "Curso_Division",
            HeaderText = "División",
            Width = 80,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        },
        new DataGridViewTextBoxColumn
        {
            Name = "Curso_Grupo",
            DataPropertyName = "Curso_Grupo",
            HeaderText = "Grupo",
            Width = 80,
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

            CMBTipoEntorno.DataSource = _listaTipoEntorno;
            CMBTipoEntorno.DisplayMember = "Tipo_Entorno";
            CMBTipoEntorno.ValueMember = "Id_Tipo_Entorno";
        }

        private async Task CargarTiposEntorno()
        {
            var resultado = await _tipoEntornoService.GetAll();
            if (resultado.IsSuccess) _listaTipoEntorno = resultado.Value;
        }

        private async Task CargarUsuarios()
        {
            var resultado = await _usuarioService.GetAll();
            if (resultado.IsSuccess) _listaUsuarios = resultado.Value;
        }

        private async Task CargarEntornos(int idTipoEntorno)
        {
            var resultado = await _entornoService.GetAllxEntorno(idTipoEntorno);
            if (resultado.IsSuccess)
            {
                CMBEntorno.DataSource = resultado.Value;
                CMBEntorno.DisplayMember = "Entorno_nombre";
                CMBEntorno.ValueMember = "Id_Entorno";
            }
        }

        private async Task PoblarFormulario(Modelo.Entidades.EntornoFormativo entornoFormativo)
        {
            // Desactivar evento para evitar recargas no deseadas
            CMBTipoEntorno.SelectedIndexChanged -= CMBTipoEntorno_SelectedIndexChanged;

            var resultadoEntorno = _entornoService.GetById(entornoFormativo.Id_Entorno);
            if (resultadoEntorno.IsSuccess && resultadoEntorno.Value != null)
            {
                var entornoPadre = resultadoEntorno.Value;

                // 1. Seleccionar el Tipo de Entorno
                CMBTipoEntorno.SelectedValue = entornoPadre.Id_TipoEntorno;

                // 2. Cargar los entornos hijos para ese tipo
                await CargarEntornos(entornoPadre.Id_TipoEntorno);

                // 3. Seleccionar el Entorno específico
                CMBEntorno.SelectedValue = entornoFormativo.Id_Entorno;
            }

            // Reactivar el evento
            CMBTipoEntorno.SelectedIndexChanged += CMBTipoEntorno_SelectedIndexChanged;

            // Poblar el resto de los campos
            CMBUsuario.SelectedValue = entornoFormativo.Id_Usuario;
            TxtCursoAnio.Text = entornoFormativo.Curso_anio;
            TxtCursoDivision.Text = entornoFormativo.Curso_Division;
            TxtCursoGrupo.Text = entornoFormativo.Curso_Grupo;
            TxtObservacion.Text = entornoFormativo.Observaciones;
        }

        private void LimpiarFormulario()
        {
            _entornoFormativoSeleccionado = null;
            DgvEntornosFormativos.ClearSelection();
            TxtCursoAnio.Clear();
            TxtCursoDivision.Clear();
            TxtCursoGrupo.Clear();
            TxtObservacion.Clear();
            CMBTipoEntorno.SelectedIndex = -1;
            CMBEntorno.DataSource = null;
            CMBUsuario.SelectedIndex = -1;
            BtnGuardar.Enabled = true;
        }

        private bool ValidarCampos()
        {
            if (CMBTipoEntorno.SelectedValue == null || CMBEntorno.SelectedValue == null || CMBUsuario.SelectedValue == null ||
                string.IsNullOrWhiteSpace(TxtCursoAnio.Text) ||
                string.IsNullOrWhiteSpace(TxtCursoDivision.Text) ||
                string.IsNullOrWhiteSpace(TxtCursoGrupo.Text) || 
              string.IsNullOrWhiteSpace(TxtObservacion.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion

        private async void UCConsultaEntornoFormativo_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                ConfigurarDGV();
                await Task.WhenAll(
                    CargaInicial(),
                    CargarGrilla()
                    );


                LimpiarFormulario();
            }
        }
    }
}