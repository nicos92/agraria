using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Serilog;

namespace Agraria.UI.Paniol
{
    public partial class UCConsultaHerramienta : UserControl
    {
        private readonly IHerramientasService _herramientasService;
        private List<Herramientas> _herramientasList;
        private Herramientas _herramientaSeleccionada;

        public UCConsultaHerramienta(IHerramientasService herramientasService)
        {
            InitializeComponent();
            _herramientasService = herramientasService;
            _herramientasList = [];
            ConfigurarEventos();
            ConfigurarDataGridView();
        }

        private void ConfigurarEventos()
        {
            
            TxtNombre.TextChanged += ValidarCamposEdicion;
            TxtCantidad.TextChanged += ValidarCamposEdicion;
        }

        private void ConfigurarDataGridView()
        {
            // Configurar las columnas del DataGridView
            ListBArticulos.AutoGenerateColumns = false;
            
            // Configurar las columnas existentes
            if (ListBArticulos.Columns["Codigo"] != null)
            {
                ListBArticulos.Columns["Codigo"].DataPropertyName = "Id_Herramienta";
            }
            
            if (ListBArticulos.Columns["Nombre"] != null)
            {
                ListBArticulos.Columns["Nombre"].DataPropertyName = "Nombre";
            }
        }

        private async void UCConsultaHerramienta_Load(object sender, EventArgs e)
        {
            await CargarHerramientas();
        }

        private async Task CargarHerramientas()
        {
            try
            {
                ProgressBar.Visible = true;
                
                var resultado = await _herramientasService.GetAll();
                
                if (resultado.IsSuccess)
                {
                    _herramientasList = resultado.Value;
                    ListBArticulos.DataSource = _herramientasList;
                    LimpiarCamposEdicion();
                }
                else
                {
                    MessageBox.Show($"Error al cargar las herramientas: {resultado.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Error al cargar herramientas: {Error}", resultado.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Error inesperado al cargar herramientas");
            }
            finally
            {
                ProgressBar.Visible = false;
            }
        }

        private async void ListBArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (ListBArticulos.SelectedRows.Count > 0)
            {
                _herramientaSeleccionada = (Herramientas)ListBArticulos.SelectedRows[0].DataBoundItem;
                CargarDatosEnFormulario(_herramientaSeleccionada);
            }
            else
            {
                _herramientaSeleccionada = null;
                LimpiarCamposEdicion();
            }
            
            ValidarCamposEdicion(sender, e);
        }

        private void CargarDatosEnFormulario(Herramientas herramienta)
        {
            if (herramienta != null)
            {
                TxtNombre.Text = herramienta.Nombre;
                TxtDescripcion.Text = herramienta.Descripcion;
                TxtCantidad.Text = herramienta.Cantidad.ToString();
            }
            else
            {
                LimpiarCamposEdicion();
            }
        }

        private void LimpiarCamposEdicion()
        {
            TxtNombre.Clear();
            TxtDescripcion.Clear();
            TxtCantidad.Clear();
            _herramientaSeleccionada = null;
        }

        private void ValidarCamposEdicion(object sender, EventArgs e)
        {
            bool haySeleccion = _herramientaSeleccionada != null;
            bool nombreValido = !string.IsNullOrWhiteSpace(TxtNombre.Text);
            bool cantidadValida = int.TryParse(TxtCantidad.Text, out int cantidad) && cantidad >= 0;
            
            BtnGuardar.Enabled = haySeleccion && nombreValido && cantidadValida;
            BtnEliminar.Enabled = haySeleccion;
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (_herramientaSeleccionada == null) return;

            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Estas Seguro que queres guardar la nueva herramienta?", "Gurdar al pañol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                ProgressBar.Visible = true;
                BtnGuardar.Enabled = false;

                // Actualizar los datos de la herramienta seleccionada
                _herramientaSeleccionada.Nombre = TxtNombre.Text.Trim();
                _herramientaSeleccionada.Descripcion = TxtDescripcion.Text.Trim();
                _herramientaSeleccionada.Cantidad = int.Parse(TxtCantidad.Text);

                var resultado = await _herramientasService.Update(_herramientaSeleccionada);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Herramienta actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await CargarHerramientas(); // Recargar la lista
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la herramienta: {resultado.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Error al actualizar herramienta: {Error}", resultado.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Error inesperado al actualizar herramienta");
            }
            finally
            {
                ProgressBar.Visible = false;
                BtnGuardar.Enabled = true;
            }
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (_herramientaSeleccionada == null) return;

            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar esta herramienta?", 
                "Confirmar eliminación", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    ProgressBar.Visible = true;
                    BtnEliminar.Enabled = false;

                    var resultadoEliminacion = _herramientasService.Delete(_herramientaSeleccionada.Id_Herramienta);

                    if (resultadoEliminacion.IsSuccess)
                    {
                        MessageBox.Show("Herramienta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await CargarHerramientas(); // Recargar la lista
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la herramienta: {resultadoEliminacion.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Log.Error("Error al eliminar herramienta: {Error}", resultadoEliminacion.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error(ex, "Error inesperado al eliminar herramienta");
                }
                finally
                {
                    ProgressBar.Visible = false;
                    BtnEliminar.Enabled = true;
                }
            }
        }
    }
}
