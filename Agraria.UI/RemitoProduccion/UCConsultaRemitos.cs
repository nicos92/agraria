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
using Agraria.Utilidades;

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
            ConfigurarDGV();

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
            try
            {
                DgvRemitos.SuspendLayout();
                int primeraFilaVisible = DgvRemitos.FirstDisplayedScrollingRowIndex;

                DgvRemitos.AutoGenerateColumns = false;
                DgvRemitos.DataSource = null;
                DgvRemitos.DataSource = _remitos ?? [];

                if (primeraFilaVisible >= 0 && primeraFilaVisible < DgvRemitos.Rows.Count)
                {
                    DgvRemitos.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar DataGridView de Remitos: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DgvRemitos.ResumeLayout();
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
            try
            {
                DgvDetalles.SuspendLayout();
                int primeraFilaVisible = DgvDetalles.FirstDisplayedScrollingRowIndex;

                DgvDetalles.AutoGenerateColumns = false;
                DgvDetalles.DataSource = null;
                DgvDetalles.DataSource = _detallesRemito ?? [];

                if (primeraFilaVisible >= 0 && primeraFilaVisible < DgvDetalles.Rows.Count)
                {
                    DgvDetalles.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar DataGridView de Detalles: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DgvDetalles.ResumeLayout();
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

        private void ConfigurarDGV()
        {
            // Configurar DataGridView de remitos
            DgvRemitos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvRemitos.MultiSelect = false;
            DgvRemitos.ReadOnly = true;
            DgvRemitos.AllowUserToAddRows = false;
            DgvRemitos.AllowUserToDeleteRows = false;
            DgvRemitos.RowHeadersVisible = false;
            DgvRemitos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvRemitos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvRemitos.AllowUserToResizeRows = false;
            DgvRemitos.AllowUserToResizeColumns = true;
            DgvRemitos.AutoGenerateColumns = false;
            
            // Asegurar que el DataGridView puede recibir el foco y selecciones
            DgvRemitos.TabStop = true;
            DgvRemitos.Enabled = true;

            // Configurar DataGridView de detalles
            DgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvDetalles.MultiSelect = false;
            DgvDetalles.ReadOnly = true;
            DgvDetalles.AllowUserToAddRows = false;
            DgvDetalles.AllowUserToDeleteRows = false;
            DgvDetalles.RowHeadersVisible = false;
            DgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvDetalles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvDetalles.AllowUserToResizeRows = false;
            DgvDetalles.AllowUserToResizeColumns = true;
            DgvDetalles.AutoGenerateColumns = false;
            
            // Asegurar que el DataGridView puede recibir el foco y selecciones
            DgvDetalles.TabStop = true;
            DgvDetalles.Enabled = true;

            ConfigurarColumnasDataGridView();
        }

        private void ConfigurarColumnasDataGridView()
        {
            // Limpiar columnas existentes
            DgvRemitos.Columns.Clear();
            DgvDetalles.Columns.Clear();

            // Configurar columnas para DgvRemitos
            var remitosColumns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Id_Remito",
                    DataPropertyName = "Id_Remito",
                    HeaderText = "Nº Remito",
                    Visible = true,
                    FillWeight = 20f,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Fecha_Hora",
                    DataPropertyName = "Fecha_Hora",
                    HeaderText = "Fecha",
                    Visible = true,
                    FillWeight = 30f,
                    DefaultCellStyle = new DataGridViewCellStyle 
                    { 
                        Format = "dd/MM/yyyy HH:mm" 
                    },
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Cod_Usuario",
                    DataPropertyName = "Cod_Usuario",
                    HeaderText = "Usuario",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Subtotal",
                    DataPropertyName = "Subtotal",
                    HeaderText = "Subtotal",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Descu",
                    DataPropertyName = "Descu",
                    HeaderText = "Descuento",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Total",
                    DataPropertyName = "Total",
                    HeaderText = "Total",
                    Visible = true,
                    FillWeight = 25f,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Format = "C2",
                        FormatProvider = DecimalFormatter.ArgentinaCulture
                    },
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                }
            };

            foreach (var column in remitosColumns)
            {
                DgvRemitos.Columns.Add(column);
            }

            // Configurar columnas para DgvDetalles
            var detallesColumns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "Id_Det_Remito",
                    DataPropertyName = "Id_Det_Remito",
                    HeaderText = "ID Detalle",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Id_Remito",
                    DataPropertyName = "Id_Remito",
                    HeaderText = "ID Remito",
                    Visible = false,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Cod_Art",
                    DataPropertyName = "Art_Cod",
                    HeaderText = "Código",
                    Visible = false,
                    FillWeight = 15f,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Descr",
                    DataPropertyName = "Descr",
                    HeaderText = "Descripción",
                    Visible = true,
                    FillWeight = 40f,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "P_Unit",
                    DataPropertyName = "P_Unit",
                    HeaderText = "Precio Unit.",
                    Visible = true,
                    FillWeight = 15f,
                    DefaultCellStyle = new DataGridViewCellStyle 
                    { 
                        Format = "C2",
                        FormatProvider = DecimalFormatter.ArgentinaCulture
                    }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Cant",
                    DataPropertyName = "Cant",
                    HeaderText = "Cantidad",
                    Visible = true,
                    FillWeight = 10f
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "P_X_Cant",
                    DataPropertyName = "P_X_Cant",
                    HeaderText = "Total",
                    Visible = true,
                    FillWeight = 15f,
                    DefaultCellStyle = new DataGridViewCellStyle 
                    { 
                        Format = "C2",
                        FormatProvider = DecimalFormatter.ArgentinaCulture
                    }
                }
            };

            foreach (var column in detallesColumns)
            {
                DgvDetalles.Columns.Add(column);
            }
        }

        private async void BtnActualizar_Click(object sender, EventArgs e)
        {
            await CargarRemitosAsync();
        }
    }
}