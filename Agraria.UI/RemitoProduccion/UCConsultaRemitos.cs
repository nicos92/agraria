using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.UI.RemitoProduccion
{
    public partial class UCConsultaRemitos : UserControl
    {
        private readonly IHRemitoProduccionService _hRemitoProduccionService;
        private readonly IHRemitoDetalleProduccionService _hRemitoDetalleProduccionService;
        private readonly IUsuariosService _usuariosService;
        private List<HRemitoProduccion> _remitos = [];
        private List<HRemitoDetalleProduccion> _detallesRemito = [];
        private int _selectedRemitoId = -1;

        public UCConsultaRemitos(
            IHRemitoProduccionService hRemitoProduccionService,
            IHRemitoDetalleProduccionService hRemitoDetalleProduccionService,
            IUsuariosService usuariosService)
        {
            _hRemitoProduccionService = hRemitoProduccionService;
            _hRemitoDetalleProduccionService = hRemitoDetalleProduccionService;
            _usuariosService = usuariosService;

            InitializeComponent();
        }

        private async void UCConsultaRemitos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarControles();
                await CargarRemitosAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el control de consulta de remitos: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarControles()
        {
            // Configurar DataGridView de remitos
            DgvRemitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvRemitos.MultiSelect = false;
            DgvRemitos.ReadOnly = true;
            DgvRemitos.AllowUserToAddRows = false;
            DgvRemitos.AllowUserToDeleteRows = false;
            DgvRemitos.RowHeadersVisible = false;
            DgvRemitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar DataGridView de detalles
            DgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetalles.MultiSelect = false;
            DgvDetalles.ReadOnly = true;
            DgvDetalles.AllowUserToAddRows = false;
            DgvDetalles.AllowUserToDeleteRows = false;
            DgvDetalles.RowHeadersVisible = false;
            DgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configurar fechas por defecto
            DtpFechaDesde.Value = DateTime.Today.AddDays(-30);
            DtpFechaHasta.Value = DateTime.Today;

            // Configurar estilos
            AplicarEstilos();
        }

        private void AplicarEstilos()
        {
            // Aplicar colores consistentes con la aplicación
            this.BackColor = Color.FromArgb(218, 218, 220);
            
            // Estilo para los GroupBox
            GBLista.ForeColor = Color.FromArgb(7, 100, 147);
            GBForm.ForeColor = Color.FromArgb(7, 100, 147);
            
            // Estilo para las etiquetas
            foreach (Control control in GBForm.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = Color.FromArgb(26, 28, 30);
                }
                else if (control is TableLayoutPanel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is Label subLabel)
                        {
                            subLabel.ForeColor = Color.FromArgb(26, 28, 30);
                        }
                    }
                }
            }
            
            // Configurar formato de moneda para las etiquetas de totales
            LblSubtotal.Text = DecimalFormatter.ToCurrency(0);
            LblDescuento.Text = DecimalFormatter.ToCurrency(0);
            LblTotal.Text = DecimalFormatter.ToCurrency(0);
        }

        private async Task CargarRemitosAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                var result = await Task.Run(() => _hRemitoProduccionService.GetAll());

                if (result.IsSuccess)
                {
                    _remitos = result.Value;
                    ActualizarListaRemitos();
                }
                else
                {
                    MessageBox.Show($"Error al cargar los remitos: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los remitos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private void ActualizarListaRemitos()
        {
            DgvRemitos.DataSource = null;
            DgvRemitos.DataSource = _remitos;

            // Configurar columnas
            if (DgvRemitos.Columns.Contains("Id_Remito"))
            {
                DgvRemitos.Columns["Id_Remito"].HeaderText = "Nº Remito";
                DgvRemitos.Columns["Id_Remito"].FillWeight = 20;
            }
            
            if (DgvRemitos.Columns.Contains("Fecha_Hora"))
            {
                DgvRemitos.Columns["Fecha_Hora"].HeaderText = "Fecha";
                DgvRemitos.Columns["Fecha_Hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                DgvRemitos.Columns["Fecha_Hora"].FillWeight = 30;
            }
            
            if (DgvRemitos.Columns.Contains("Total"))
            {
                DgvRemitos.Columns["Total"].HeaderText = "Total";
                DgvRemitos.Columns["Total"].DefaultCellStyle.Format = "C2";
                DgvRemitos.Columns["Total"].DefaultCellStyle.FormatProvider = DecimalFormatter.ArgentinaCulture;
                DgvRemitos.Columns["Total"].FillWeight = 25;
            }

            // Ocultar columnas innecesarias
            var columnasOcultar = new[] { "Cod_Usuario", "Id_Cliente", "Subtotal", "Descu" };
            foreach (var columna in columnasOcultar)
            {
                if (DgvRemitos.Columns.Contains(columna))
                    DgvRemitos.Columns[columna].Visible = false;
            }
        }

        private async void DgvRemitos_SelectionChanged(object sender, EventArgs e)
        {
            if (DgvRemitos.CurrentRow?.DataBoundItem is HRemitoProduccion remito)
            {
                _selectedRemitoId = remito.Id_Remito;
                await CargarDetallesRemitoAsync(remito.Id_Remito);
                MostrarDetallesRemito(remito);
            }
            else
            {
                _selectedRemitoId = -1;
                LimpiarDetallesRemito();
            }
        }

        private async Task CargarDetallesRemitoAsync(int idRemito)
        {
            try
            {
                var result = await Task.Run(() => _hRemitoDetalleProduccionService.GetByRemitoId(idRemito));

                if (result.IsSuccess)
                {
                    _detallesRemito = result.Value;
                    ActualizarListaDetalles();
                }
                else
                {
                    MessageBox.Show($"Error al cargar detalles: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar detalles: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void ActualizarListaDetalles()
        {
            DgvDetalles.DataSource = null;
            DgvDetalles.DataSource = _detallesRemito;

            // Ocultar columnas innecesarias
            var columnasOcultar = new[] { "Id_Det_Remito", "Id_Remito" };
            foreach (var columna in columnasOcultar)
            {
                if (DgvDetalles.Columns.Contains(columna))
                    DgvDetalles.Columns[columna].Visible = false;
            }
                
            // Configurar columnas visibles
            if (DgvDetalles.Columns.Contains("Cod_Art"))
            {
                DgvDetalles.Columns["Cod_Art"].HeaderText = "Código";
                DgvDetalles.Columns["Cod_Art"].FillWeight = 15;
            }
                
            if (DgvDetalles.Columns.Contains("Descr"))
            {
                DgvDetalles.Columns["Descr"].HeaderText = "Descripción";
                DgvDetalles.Columns["Descr"].FillWeight = 40;
            }
                
            if (DgvDetalles.Columns.Contains("P_Unit"))
            {
                DgvDetalles.Columns["P_Unit"].HeaderText = "Precio Unit.";
                DgvDetalles.Columns["P_Unit"].DefaultCellStyle.Format = "C2";
                DgvDetalles.Columns["P_Unit"].DefaultCellStyle.FormatProvider = DecimalFormatter.ArgentinaCulture;
                DgvDetalles.Columns["P_Unit"].FillWeight = 15;
            }
                
            if (DgvDetalles.Columns.Contains("Cant"))
            {
                DgvDetalles.Columns["Cant"].HeaderText = "Cantidad";
                DgvDetalles.Columns["Cant"].FillWeight = 10;
            }
                
            if (DgvDetalles.Columns.Contains("P_X_Cant"))
            {
                DgvDetalles.Columns["P_X_Cant"].HeaderText = "Total";
                DgvDetalles.Columns["P_X_Cant"].DefaultCellStyle.Format = "C2";
                DgvDetalles.Columns["P_X_Cant"].DefaultCellStyle.FormatProvider = DecimalFormatter.ArgentinaCulture;
                DgvDetalles.Columns["P_X_Cant"].FillWeight = 15;
            }
        }

        private void MostrarDetallesRemito(HRemitoProduccion remito)
        {
            LblIdRemito.Text = remito.Id_Remito.ToString();
            LblFecha.Text = remito.Fecha_Hora.ToString("dd/MM/yyyy HH:mm");
            LblSubtotal.Text = DecimalFormatter.ToCurrency(remito.Subtotal);
            LblDescuento.Text = DecimalFormatter.ToCurrency(remito.Descu);
            LblTotal.Text = DecimalFormatter.ToCurrency(remito.Total);

            // Cargar información adicional (cliente, usuario) de forma asíncrona
            // TODO: Descomentar cuando los servicios estén disponibles
            //async CargarInformacionAdicionalAsync(remito);
        }

        private static async Task CargarInformacionAdicionalAsync(HRemitoProduccion remito)
        {
            // TODO: Descomentar cuando los servicios estén disponibles
            //try
            //{
            //    // Cargar información del cliente
            //    var clienteResult = await _clientesService.GetById(remito.Id_Cliente);
            //    if (clienteResult.IsSuccess)
            //    {
            //        LblCliente.Text = clienteResult.Value?.Nombre ?? "Cliente no encontrado";
            //    }
            //    else
            //    {
            //        LblCliente.Text = "Error al cargar cliente";
            //    }

            //    // Cargar información del usuario
            //    var usuarioResult = await _usuariosService.GetById(remito.Cod_Usuario);
            //    if (usuarioResult.IsSuccess)
            //    {
            //        LblUsuario.Text = usuarioResult.Value?.Nombre ?? "Usuario no encontrado";
            //    }
            //    else
            //    {
            //        LblUsuario.Text = "Error al cargar usuario";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, "Error al cargar información adicional para remito {IdRemito}", remito.Id_Remito);
            //    LblCliente.Text = "Error al cargar";
            //    LblUsuario.Text = "Error al cargar";
            //}
        }

        private void LimpiarDetallesRemito()
        {
            LblIdRemito.Text = "";
            LblFecha.Text = "";
            LblCliente.Text = "";
            LblUsuario.Text = "";
            LblSubtotal.Text = "";
            LblDescuento.Text = "";
            LblTotal.Text = "";
            
            DgvDetalles.DataSource = null;
            _detallesRemito.Clear();
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (_selectedRemitoId <= 0)
            {
                MessageBox.Show("Por favor, seleccione un remito para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dr = MessageBox.Show("¿Está seguro que desea eliminar este remito? Esta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PbProgreso.Visible = true;
                    PbProgreso.Style = ProgressBarStyle.Marquee;

                    var result = await Task.Run(() => _hRemitoProduccionService.Delete(_selectedRemitoId));

                    if (result.IsSuccess)
                    {
                        MessageBox.Show("Remito eliminado correctamente.", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Recargar la lista de remitos
                        await CargarRemitosAsync();
                        LimpiarDetallesRemito();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar el remito: {result.Error}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el remito: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    PbProgreso.Visible = false;
                }
            }
        }

        private async void BtnBuscar_Click(object sender, EventArgs e)
        {
            await FiltrarRemitosAsync();
        }

        private async Task FiltrarRemitosAsync()
        {
            try
            {
                PbProgreso.Visible = true;
                PbProgreso.Style = ProgressBarStyle.Marquee;

                DateTime fechaDesde = DtpFechaDesde.Value.Date;
                DateTime fechaHasta = DtpFechaHasta.Value.Date.AddDays(1).AddTicks(-1); // Fin del día
                string cliente = TxtCliente.Text.Trim();
                string idRemitoText = TxtIdRemito.Text.Trim();
                
                // Intentar parsear el ID de remito si se proporciona
                int? idRemito = null;
                if (!string.IsNullOrEmpty(idRemitoText) && int.TryParse(idRemitoText, out int parsedId))
                {
                    idRemito = parsedId;
                }

                var result = await Task.Run(() => _hRemitoProduccionService.GetFiltered(fechaDesde, fechaHasta, cliente, idRemito));

                if (result.IsSuccess)
                {
                    _remitos = result.Value;
                    ActualizarListaRemitos();
                }
                else
                {
                    MessageBox.Show($"Error al filtrar remitos: {result.Error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar remitos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PbProgreso.Visible = false;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            _ = CargarRemitosAsync();
        }
    }
}