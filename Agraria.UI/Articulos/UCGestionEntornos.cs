using Microsoft.Extensions.Logging;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.UI.Articulos
{
    public partial class UCGestionEntornos : UserControl
    {
        private readonly ITipoEntornosService _tipoEntornoService;
        private readonly IEntornoService _entornoService;
        private readonly ILogger<UCGestionEntornos> _logger;
        private List<TipoEntorno> _tipoEntornos = [];
        private List<Entorno> _entornos = [];
        private int _selectedTipoEntornoId = -1;
        private int _selectedEntornoId = -1;

        public UCGestionEntornos(
            ITipoEntornosService tipoEntornosService,
            IEntornoService entornoService,
            ILogger<UCGestionEntornos> logger)
        {
            _tipoEntornoService = tipoEntornosService;
            _entornoService = entornoService;
            _logger = logger;

            InitializeComponent();
        }

        private async void UCGestionEntornos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                await CargarTipoEntornosAsync();
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
            DgvTipoEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvTipoEntornos.MultiSelect = false;
            DgvTipoEntornos.ReadOnly = true;
            DgvTipoEntornos.AllowUserToAddRows = false;
            DgvTipoEntornos.AllowUserToDeleteRows = false;
            DgvTipoEntornos.RowHeadersVisible = false;
            DgvTipoEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar DataGridView de subcategorías
            DgvEntornos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvEntornos.MultiSelect = false;
            DgvEntornos.ReadOnly = true;
            DgvEntornos.AllowUserToAddRows = false;
            DgvEntornos.AllowUserToDeleteRows = false;
            DgvEntornos.RowHeadersVisible = false;
            DgvEntornos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar estilos
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Aplicar colores consistentes con la aplicación
            this.BackColor = Color.FromArgb(238, 237, 240);

            // Estilo para los GroupBox
            GNTipoEntornos.ForeColor = Color.FromArgb(7, 100, 147);
            GBEntornos.ForeColor = Color.FromArgb(7, 100, 147);
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

        private async Task CargarTipoEntornosAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await TareasLargas.EjecutarAsync(
                    () => _tipoEntornoService.GetAll().Result,
                    "Cargando Tipo entornos...");

                if (result.IsSuccess)
                {
                    _tipoEntornos = result.Value;
                    ActualizarListaTipoEntornos();
                }
                else
                {
                    MessageBox.Show($"Error al cargar los tipo Entornos: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar los tipo de Entornos");
                MessageBox.Show($"Error al cargar los tipos de Entornos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async Task CargarEntornosAsync()
        {
            try
            {
                if (_selectedTipoEntornoId <= 0)
                {
                    _entornos.Clear();
                    ActualizarListaEntornos();
                    return;
                }

                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await TareasLargas.EjecutarAsync(
                    () => _entornoService.GetAllxEntorno(_selectedTipoEntornoId).Result,
                    "Cargando Entornos...");

                if (result.IsSuccess)
                {
                    _entornos = result.Value;
                    ActualizarListaEntornos();
                }
                else
                {
                    MessageBox.Show($"Error al cargar los Entornos: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar los Entornos");
                MessageBox.Show($"Error al cargar los Entornos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private void ActualizarListaTipoEntornos()
        {
            DgvTipoEntornos.DataSource = null;
            DgvTipoEntornos.DataSource = _tipoEntornos;

            // Configurar columnas
            if (DgvTipoEntornos.Columns.Contains("Id_categoria"))
            {
                DgvTipoEntornos.Columns["Id_categoria"].HeaderText = "ID";
                DgvTipoEntornos.Columns["Id_categoria"].FillWeight = 20;
            }

            if (DgvTipoEntornos.Columns.Contains("Categoria"))
            {
                DgvTipoEntornos.Columns["Categoria"].HeaderText = "Categoría";
                DgvTipoEntornos.Columns["Categoria"].FillWeight = 80;
            }
        }

        private void ActualizarListaEntornos()
        {
            DgvEntornos.DataSource = null;
            DgvEntornos.DataSource = _entornos;

            // Configurar columnas
            if (DgvEntornos.Columns.Contains("Id_Subcategoria"))
            {
                DgvEntornos.Columns["Id_Subcategoria"].HeaderText = "ID";
                DgvEntornos.Columns["Id_Subcategoria"].FillWeight = 20;
            }

            if (DgvEntornos.Columns.Contains("Sub_categoria"))
            {
                DgvEntornos.Columns["Sub_categoria"].HeaderText = "Subcategoría";
                DgvEntornos.Columns["Sub_categoria"].FillWeight = 80;
            }

            // Ocultar columnas innecesarias
            if (DgvEntornos.Columns.Contains("Id_Categoria"))
            {
                DgvEntornos.Columns["Id_Categoria"].Visible = false;
            }
        }

        private async void DgvtipoEntornos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvTipoEntornos.CurrentRow?.DataBoundItem is TipoEntorno tipoEntorno)
            {
                _selectedTipoEntornoId = tipoEntorno.Id_Tipo_Entorno;
                TxtTipoEntorno.Text = tipoEntorno.Tipo_Entorno ?? "";
                LblEntornoSeleccionado.Text = tipoEntorno.Tipo_Entorno ?? "";
                await CargarEntornosAsync();
            }
            else
            {
                _selectedTipoEntornoId = -1;
                TxtTipoEntorno.Text = "";
                LblEntornoSeleccionado.Text = "Ninguna";
                _entornos.Clear();
                ActualizarListaEntornos();
            }
        }

        private void DgvEntornos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvEntornos.CurrentRow?.DataBoundItem is Entorno entorno)
            {
                _selectedEntornoId = entorno.Id_Entorno;
                TxtEntorno.Text = entorno.Entorno_nombre ?? "";
            }
            else
            {
                _selectedEntornoId = -1;
                TxtEntorno.Text = "";
            }
        }

        private async void BtnNuevoTipoEntorno_Click(object sender, EventArgs e)
        {
            // Solicitar el nombre de la nueva categoría usando un diálogo simple
            string nombreTipoEntorno = Prompt.ShowDialog("Ingrese el nombre del nuevo Tipo de Entorno:", "Nuevo tipo de Entorno");

            // Verificar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombreTipoEntorno))
            {
                return;
            }

            // Limpiar espacios
            nombreTipoEntorno = nombreTipoEntorno.Trim();

            // Verificar si ya existe una categoría con el mismo nombre
            var tipoEntornoExistente = _tipoEntornos.FirstOrDefault(c =>
                c.Tipo_Entorno.Equals(nombreTipoEntorno, StringComparison.OrdinalIgnoreCase));

            if (tipoEntornoExistente != null)
            {
                MessageBox.Show($"Ya existe una categoría con el nombre '{nombreTipoEntorno}'.",
                    "Categoría existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Crear nueva categoría
                var tipoRntorno = new TipoEntorno
                {
                    Tipo_Entorno = nombreTipoEntorno
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _tipoEntornoService.Add(tipoRntorno),
                    "Agregando Tipo Entorno...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Tipo de Entorno agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de categorías
                    await CargarTipoEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al agregar tipo de Entorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar tipo de Entorno");
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
            if (_selectedTipoEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un Entorno para actualizar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtTipoEntorno.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del Entorno.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtTipoEntorno.Focus();
                return;
            }

            string nombreEntorno = TxtTipoEntorno.Text.Trim();

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Actualizar categoría existente
                var entorno = new TipoEntorno
                {
                    Id_Tipo_Entorno = _selectedTipoEntornoId,
                    Tipo_Entorno = nombreEntorno
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _tipoEntornoService.Update(entorno),
                    "Actualizando tipo de entorno...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("tipo de Entorno actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de categorías
                    await CargarTipoEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar el tipo de entorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar tipo de entorno");
                MessageBox.Show($"Error al actualizar tipo de Entorno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnEliminarEntorno_Click(object sender, EventArgs e)
        {
            if (_selectedTipoEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un tipo de entorno para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar si hay subcategorías asociadas
            //var subcategoriasResult = _entornoService.GetAllxEntorno(_selectedTipoEntornoId).Result;
            //if (subcategoriasResult.IsSuccess && subcategoriasResult.Value.Count != 0)
            //{
            //    MessageBox.Show("No se puede eliminar el Tipo de Entorno porque tiene Entornos asociados. Elimine primero los Entornos.", "Advertencia",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

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
                        () => _tipoEntornoService.Delete(_selectedTipoEntornoId),
                        "Eliminando Entorno...");

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Entorno eliminado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpiar formulario y recargar lista
                        TxtTipoEntorno.Text = "";
                        _selectedTipoEntornoId = -1;
                        await CargarTipoEntornosAsync();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la Entorno: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar Entorno {IdEntorno}", _selectedTipoEntornoId);
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
            if (_selectedTipoEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un Entorno primero.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Solicitar el nombre de la nueva subcategoría usando un diálogo simple
            string nombreSubEntorno = Prompt.ShowDialog("Ingrese el nombre el nuevo Entorno:", "Nueva Entorno");

            // Verificar que se haya ingresado un nombre
            if (string.IsNullOrWhiteSpace(nombreSubEntorno))
            {
                return;
            }

            // Limpiar espacios
            nombreSubEntorno = nombreSubEntorno.Trim();

            // Verificar si ya existe una subcategoría con el mismo nombre en la misma categoría
            var subEntornoExistente = _entornos.FirstOrDefault(s =>
                s.Entorno_nombre.Equals(nombreSubEntorno, StringComparison.OrdinalIgnoreCase));

            if (subEntornoExistente != null)
            {
                MessageBox.Show($"Ya existe una Entorno con el nombre '{nombreSubEntorno}' en este Entorno.",
                    "Entorno existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Crear nueva subcategoría
                var subEntorno = new Entorno
                {
                    Entorno_nombre = nombreSubEntorno,
                    Id_TipoEntorno = _selectedTipoEntornoId
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _entornoService.Add(subEntorno),
                    "Agregando Entorno...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Entorno agregado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    await CargarEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al agregar el Entorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar Entorno");
                MessageBox.Show($"Error al agregar el Entorno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnGuardarSubEntorno_Click(object sender, EventArgs e)
        {
            if (_selectedEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un Entorno para actualizar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedTipoEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un Entorno primero.", "Advertencia",
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

            string nombreSubEntorno = TxtEntorno.Text.Trim();

            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                // Actualizar subcategoría existente
                var subEntorno = new Entorno
                {
                    Id_Entorno = _selectedEntornoId,
                    Entorno_nombre = nombreSubEntorno,
                    Id_TipoEntorno = _selectedTipoEntornoId
                };

                var result = await TareasLargas.EjecutarAsync(
                    () => _entornoService.Update(subEntorno),
                    "Actualizando Entorno...");

                if (result.IsSuccess)
                {
                    MessageBox.Show("Entorno actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar lista de subcategorías
                    await CargarEntornosAsync();
                }
                else
                {
                    MessageBox.Show($"Error al actualizar el Entorno: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar Entorno");
                MessageBox.Show($"Error al actualizar el Entorno: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private async void BtnEliminarSubEntorno_Click(object sender, EventArgs e)
        {
            if (_selectedEntornoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un subEntorno para eliminar.", "Advertencia",
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
                        MessageBox.Show($"Error al eliminar la sEntorno: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al eliminar Entorno {Identorno}", _selectedEntornoId);
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
            await CargarTipoEntornosAsync();
        }

        private async void UCGestionEntornos_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                await CargarTipoEntornosAsync();
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