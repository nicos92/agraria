using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.UI.Articulos
{
    public partial class UCGestionEntornos : UserControl
    {
        private readonly IEntornosService _entornoService;
        private readonly ISubEntornoService _subEntornoService;
        private readonly ILogger<UCGestionEntornos> _logger;
        private List<Entornos> _entornos = [];
        private List<SubEntornos> _subEntornos = [];
        private int _selectedEntornoId = -1;
        private int _selectedSubEntornoId = -1;

        public UCGestionEntornos(
            IEntornosService categoriasService,
            ISubEntornoService subcategoriasService,
            ILogger<UCGestionEntornos> logger)
        {
            _entornoService = categoriasService;
            _subEntornoService = subcategoriasService;
            _logger = logger;

            InitializeComponent();
        }

        private async void UCGestionEntornos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                await CargarEntornosAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el control de gestión de Entornos");
                MessageBox.Show($"Error al cargar los Entornos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            // Configurar DataGridView de categorías
            DgvEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEntornos.MultiSelect = false;
            DgvEntornos.ReadOnly = true;
            DgvEntornos.AllowUserToAddRows = false;
            DgvEntornos.AllowUserToDeleteRows = false;
            DgvEntornos.RowHeadersVisible = false;
            DgvEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar DataGridView de subcategorías
            DgvSubEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvSubEntornos.MultiSelect = false;
            DgvSubEntornos.ReadOnly = true;
            DgvSubEntornos.AllowUserToAddRows = false;
            DgvSubEntornos.AllowUserToDeleteRows = false;
            DgvSubEntornos.RowHeadersVisible = false;
            DgvSubEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar estilos
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Aplicar colores consistentes con la aplicación
            this.BackColor = Color.FromArgb(238, 237, 240);

            // Estilo para los GroupBox
            GNEntornos.ForeColor = Color.FromArgb(7, 100, 147);
            GBSubEntornos.ForeColor = Color.FromArgb(7, 100, 147);
            GBFormEntornos.ForeColor = Color.FromArgb(7, 100, 147);
            GBFormSubEntornos.ForeColor = Color.FromArgb(7, 100, 147);

            // Estilo para las etiquetas
            foreach (Control control in GBFormEntornos.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(26, 28, 30);
                }
            }

            foreach (Control control in GBFormSubEntornos.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(26, 28, 30);
                }
            }
        }

        private async Task CargarEntornosAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await TareasLargas.EjecutarAsync(
                    () => _entornoService.GetAll().Result,
                    "Cargando categorías...");

                if (result.IsSuccess)
                {
                    _entornos = result.Value;
                    ActualizarListaEntornos();
                }
                else
                {
                    MessageBox.Show($"Error al cargar las Entornos: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar las Entornos");
                MessageBox.Show($"Error al cargar las Entornos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async Task CargarSubEntornosAsync()
        {
            try
            {
                if (_selectedEntornoId <= 0)
                {
                    _subEntornos.Clear();
                    ActualizarListaSubEntornos();
                    return;
                }

                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await TareasLargas.EjecutarAsync(
                    () => _subEntornoService.GetAllxEntorno(_selectedEntornoId).Result,
                    "Cargando subEntornos...");

                if (result.IsSuccess)
                {
                    _subEntornos = result.Value;
                    ActualizarListaSubEntornos();
                }
                else
                {
                    MessageBox.Show($"Error al cargar las SubEntornos: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar las SubEntornos");
                MessageBox.Show($"Error al cargar las SubEntornos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private void ActualizarListaEntornos()
        {
            DgvEntornos.DataSource = null;
            DgvEntornos.DataSource = _entornos;

            // Configurar columnas
            if (DgvEntornos.Columns.Contains("Id_categoria"))
            {
                DgvEntornos.Columns["Id_categoria"].HeaderText = "ID";
                DgvEntornos.Columns["Id_categoria"].FillWeight = 20;
            }

            if (DgvEntornos.Columns.Contains("Categoria"))
            {
                DgvEntornos.Columns["Categoria"].HeaderText = "Categoría";
                DgvEntornos.Columns["Categoria"].FillWeight = 80;
            }
        }

        private void ActualizarListaSubEntornos()
        {
            DgvSubEntornos.DataSource = null;
            DgvSubEntornos.DataSource = _subEntornos;

            // Configurar columnas
            if (DgvSubEntornos.Columns.Contains("Id_Subcategoria"))
            {
                DgvSubEntornos.Columns["Id_Subcategoria"].HeaderText = "ID";
                DgvSubEntornos.Columns["Id_Subcategoria"].FillWeight = 20;
            }

            if (DgvSubEntornos.Columns.Contains("Sub_categoria"))
            {
                DgvSubEntornos.Columns["Sub_categoria"].HeaderText = "Subcategoría";
                DgvSubEntornos.Columns["Sub_categoria"].FillWeight = 80;
            }

            // Ocultar columnas innecesarias
            if (DgvSubEntornos.Columns.Contains("Id_Categoria"))
            {
                DgvSubEntornos.Columns["Id_Categoria"].Visible = false;
            }
        }

        private async void DgvEntornos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvEntornos.CurrentRow?.DataBoundItem is Entornos entorno)
            {
                _selectedEntornoId = entorno.Id_entorno;
                TxtEntorno.Text = entorno.Entorno ?? "";
                LblEntornoSeleccionado.Text = entorno.Entorno ?? "";
                await CargarSubEntornosAsync();
            }
            else
            {
                _selectedEntornoId = -1;
                TxtEntorno.Text = "";
                LblEntornoSeleccionado.Text = "Ninguna";
                _subEntornos.Clear();
                ActualizarListaSubEntornos();
            }
        }

        private void DgvSubEntornos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvSubEntornos.CurrentRow?.DataBoundItem is SubEntornos subEntorno)
            {
                _selectedSubEntornoId = subEntorno.Id_SubEntorno;
                TxtSubEntorno.Text = subEntorno.Sub_Entorno ?? "";
            }
            else
            {
                _selectedSubEntornoId = -1;
                TxtSubEntorno.Text = "";
            }
        }

        private async void BtnNuevoEntorno_Click(object sender, EventArgs e)
        {
            // Solicitar el nombre de la nueva categoría usando un diálogo simple
            string nombreEntorno = Prompt.ShowDialog("Ingrese el nombre del nuevo Entorno:", "Nuevo Entorno");

            // Verificar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombreEntorno))
            {
                return;
            }

            // Limpiar espacios
            nombreEntorno = nombreEntorno.Trim();

            // Verificar si ya existe una categoría con el mismo nombre
            var entornoExistente = _entornos.FirstOrDefault(c =>
                c.Entorno.Equals(nombreEntorno, StringComparison.OrdinalIgnoreCase));

            if (entornoExistente != null)
            {
                MessageBox.Show($"Ya existe una categoría con el nombre '{nombreEntorno}'.",
                    "Categoría existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Crear nueva categoría
                var entorno = new Entornos
                {
                    Entorno = nombreEntorno
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _entornoService.Add(entorno),
                    "Agregando Entorno...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Entorno agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de categorías
                    await CargarEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al agregar Entorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar Entorno");
                MessageBox.Show($"Error al agregar Entorno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnGuardarEntorno_Click(object sender, EventArgs e)
        {
            // El botón guardar ahora solo actualizará la categoría seleccionada
            if (_selectedEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un Entorno para actualizar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtEntorno.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del Entorno.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtEntorno.Focus();
                return;
            }

            string nombreEntorno = TxtEntorno.Text.Trim();

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Actualizar categoría existente
                var entorno = new Entornos
                {
                    Id_entorno = _selectedEntornoId,
                    Entorno = nombreEntorno
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _entornoService.Update(entorno),
                    "Actualizando categoría...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Entorno actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de categorías
                    await CargarEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar la Entorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar Rntorno");
                MessageBox.Show($"Error al actualizar la Entorno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnEliminarEntorno_Click(object sender, EventArgs e)
        {
            if (_selectedEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione una Entorno para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si hay subcategorías asociadas
            var subcategoriasResult = _subEntornoService.GetAllxEntorno(_selectedEntornoId).Result;
            if (subcategoriasResult.IsSuccess && subcategoriasResult.Value.Count != 0)
            {
                MessageBox.Show("No se puede eliminar el Entorno porque tiene subEntornos asociados. Elimine primero los subEntornos.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea eliminar este Entorno? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    // CORRECCIÓN: Usar await en lugar de .Result para evitar el congelamiento
                    var result = await TareasLargas.EjecutarAsync(
                        () => _entornoService.Delete(_selectedEntornoId),
                        "Eliminando Entorno...");

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Entorno eliminado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar formulario y recargar lista
                        TxtEntorno.Text = "";
                        _selectedEntornoId = -1;
                        await CargarEntornosAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la Entorno: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar Entorno {IdEntorno}", _selectedEntornoId);
                    MessageBox.Show($"Error al eliminar el Entorno: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PbProgreso.Visible = false;
                }
            }
        }

        private async void BtnNuevaSubEntorno_Click(object sender, EventArgs e)
        {
            if (_selectedEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un Entorno primero.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Solicitar el nombre de la nueva subcategoría usando un diálogo simple
            string nombreSubEntorno = Prompt.ShowDialog("Ingrese el nombre el nuevo subEntorno:", "Nueva SubEntorno");

            // Verificar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombreSubEntorno))
            {
                return;
            }

            // Limpiar espacios
            nombreSubEntorno = nombreSubEntorno.Trim();

            // Verificar si ya existe una subcategoría con el mismo nombre en la misma categoría
            var subEntornoExistente = _subEntornos.FirstOrDefault(s =>
                s.Sub_Entorno.Equals(nombreSubEntorno, StringComparison.OrdinalIgnoreCase));

            if (subEntornoExistente != null)
            {
                MessageBox.Show($"Ya existe una subEntorno con el nombre '{nombreSubEntorno}' en este Entorno.",
                    "SubEntorno existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Crear nueva subcategoría
                var subEntorno = new SubEntornos
                {
                    Sub_Entorno = nombreSubEntorno,
                    Id_Entorno = _selectedEntornoId
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _subEntornoService.Add(subEntorno),
                    "Agregando subEntorno...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("SubEntorno agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    await CargarSubEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al agregar el subEntorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar subEntorno");
                MessageBox.Show($"Error al agregar el subEntorno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnGuardarSubEntorno_Click(object sender, EventArgs e)
        {
            if (_selectedSubEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un subEntorno para actualizar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un subEntorno primero.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtSubEntorno.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del subEntorno.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtSubEntorno.Focus();
                return;
            }

            string nombreSubEntorno = TxtSubEntorno.Text.Trim();

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Actualizar subcategoría existente
                var subEntorno = new SubEntornos
                {
                    Id_SubEntorno = _selectedSubEntornoId,
                    Sub_Entorno = nombreSubEntorno,
                    Id_Entorno = _selectedEntornoId
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _subEntornoService.Update(subEntorno),
                    "Actualizando subEntorno...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("SubEntorno actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de subcategorías
                    await CargarSubEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar el subEntorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar subEntorno");
                MessageBox.Show($"Error al actualizar el subEntorno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnEliminarSubEntorno_Click(object sender, EventArgs e)
        {
            if (_selectedSubEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un subEntorno para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea eliminar este subEntorno? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    // CORRECCIÓN: Usar await en lugar de .Result para evitar el congelamiento
                    var result = await TareasLargas.EjecutarAsync(
                        () => _subEntornoService.Delete(_selectedSubEntornoId),
                        "Eliminando subEntorno...");

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("SubEntorno eliminado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar formulario y recargar lista
                        TxtSubEntorno.Text = "";
                        _selectedSubEntornoId = -1;
                        await CargarSubEntornosAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la subEntorno: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar subEntorno {IdSubentorno}", _selectedSubEntornoId);
                    MessageBox.Show($"Error al eliminar subEntorno: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PbProgreso.Visible = false;
                }
            }
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            await CargarEntornosAsync();
        }

        private async void UCGestionEntornos_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                await CargarEntornosAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar el control de gestión de Entornos");
                MessageBox.Show($"Error al cargar los Entornos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Clase auxiliar para mostrar diálogos de entrada
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new() { Left = 20, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new() { Left = 20, Top = 50, Width = 350 };
            Button confirmation = new() { Text = "Aceptar", Left = 200, Width = 80, Top = 80, DialogResult = DialogResult.OK };
            Button cancel = new() { Text = "Cancelar", Left = 290, Width = 80, Top = 80, DialogResult = DialogResult.Cancel };
            
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };
            
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}