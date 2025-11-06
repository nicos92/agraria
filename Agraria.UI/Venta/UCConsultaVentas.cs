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
using System.Windows.Forms.VisualStyles;

namespace Agraria.UI.Ventas
{
	public partial class UCConsultaVentas : UserControl
	{
		private readonly IHVentasService _hVentasService;
		private readonly IHVentasDetalleService _hVentasDetalleService;
		private readonly IUsuariosService _usuariosService;
		private readonly ILogger<UCConsultaVentas> _logger;
		private List<HVentas> _ventas = [];
		private List<HVentasDetalle> _detallesVenta = [];
		private int _selectedVentaId = -1;

		public UCConsultaVentas(
			IHVentasService hVentasService,
			IHVentasDetalleService hVentasDetalleService,
			IUsuariosService usuariosService,
			ILogger<UCConsultaVentas> logger)
		{
			_hVentasService = hVentasService;
			_hVentasDetalleService = hVentasDetalleService;
			_usuariosService = usuariosService;
			_logger = logger;

			InitializeComponent();
			Utilidades.Util.ToolTipPdf(BtnImprimir, "Generar Reporte en PDF");

		}

		private async void UCConsultaVentas_Load(object sender, EventArgs e)
		{
			// TODO: CAMBIAR TEXTBOX DE CLIENTE POR UN COMBO BOX
			try
			{
				ConfigurarControles();
				await CargarVentasAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al cargar el control de consulta de ventas");
				MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error",
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

		private async Task CargarVentasAsync()
		{
			try
			{
				PbProgreso.Visible = true;
				PbProgreso.Style = ProgressBarStyle.Marquee;

				var result = await Task.Run(() => _hVentasService.GetAll());

				if (result.IsSuccess)
				{
					_ventas = result.Value;
					ActualizarListaVentas();
				}
				else
				{
					MessageBox.Show($"Error al cargar las ventas: {result.Error}", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al cargar las ventas");
				MessageBox.Show($"Error al cargar las ventas: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				PbProgreso.Visible = false;
			}
		}

		private void ActualizarListaVentas()
		{
			try
			{
				DgvVentas.SuspendLayout();
				int primeraFilaVisible = DgvVentas.FirstDisplayedScrollingRowIndex;

				DgvVentas.AutoGenerateColumns = false;

				DgvVentas.DataSource = null;
				DgvVentas.DataSource = _ventas ?? [];

				if (primeraFilaVisible >= 0 && primeraFilaVisible < DgvVentas.Rows.Count)
				{
					DgvVentas.FirstDisplayedScrollingRowIndex = primeraFilaVisible;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al cargar DataGridView de Ventas: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				DgvVentas.ResumeLayout();
			}
		}

		private async void DgvVentas_SelectionChanged(object sender, EventArgs e)
		{
			if (DgvVentas.CurrentRow?.DataBoundItem is HVentas venta)
			{
				_selectedVentaId = venta.Id_Remito;
				await CargarDetallesVentaAsync(venta.Id_Remito);
				MostrarDetallesVenta(venta);
			}
			else
			{
				_selectedVentaId = -1;
				LimpiarDetallesVenta();
			}
		}

		private async Task CargarDetallesVentaAsync(int idRemito)
		{
			try
			{
				var result = await Task.Run(() => _hVentasDetalleService.GetByRemitoId(idRemito));

				if (result.IsSuccess)
				{
					_detallesVenta = result.Value;
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
				_logger.LogError(ex, "Error al cargar detalles de venta {IdRemito}", idRemito);
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

				// Simply rebind the data without clearing and recreating columns
				DgvDetalles.AutoGenerateColumns = false; // Ensure auto-generation is disabled
				DgvDetalles.DataSource = null;
				DgvDetalles.DataSource = _detallesVenta ?? [];

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
		private void ConfigurarColumnasDetalles()
		{
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
			HeaderText = "ID VENTA",
			Visible = false
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

		private void MostrarDetallesVenta(HVentas venta)
		{
			LblIdRemito.Text = venta.Id_Remito.ToString();
			LblFecha.Text = venta.Fecha_Hora.ToString("dd/MM/yyyy HH:mm");
			LblUsuario.Text = venta.Cod_Usuario.ToString();
			LblSubtotal.Text = DecimalFormatter.ToCurrency(venta.Subtotal);
			LblDescuento.Text = DecimalFormatter.ToCurrency(venta.Descu);
			LblTotal.Text = DecimalFormatter.ToCurrency(venta.Total);
			LblDescripcion.Text = venta.Descripcion;

			// Cargar información adicional (cliente, usuario) de forma asíncrona
			// TODO: Descomentar cuando los servicios estén disponibles
			//async CargarInformacionAdicionalAsync(venta);
		}

		
		private void LimpiarDetallesVenta()
		{
			LblIdRemito.Text = "";
			LblFecha.Text = "";
			LblDescripcion.Text = "";
			LblUsuario.Text = "";
			LblSubtotal.Text = "";
			LblDescuento.Text = "";
			LblTotal.Text = "";

			//DgvDetalles.DataSource = null;
			_detallesVenta.Clear();
		}

		private async void BtnEliminar_Click(object sender, EventArgs e)
		{
			if (_selectedVentaId <= 0)
			{
				MessageBox.Show("Por favor, seleccione una venta para eliminar.", "Advertencia",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var dr = MessageBox.Show("¿Está seguro que desea eliminar esta venta? Esta acción no se puede deshacer.",
				"Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (dr == DialogResult.Yes)
			{
				try
				{
					PbProgreso.Visible = true;
					PbProgreso.Style = ProgressBarStyle.Marquee;

					var result = await Task.Run(() => _hVentasService.Delete(_selectedVentaId));

					if (result.IsSuccess)
					{
						MessageBox.Show("Venta eliminada correctamente.", "Éxito",
							MessageBoxButtons.OK, MessageBoxIcon.Information);

						// Recargar la lista de ventas
						await CargarVentasAsync();
						LimpiarDetallesVenta();
					}
					else
					{
						MessageBox.Show($"Error al eliminar la venta: {result.Error}", "Error",
							MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Error al eliminar venta {IdRemito}", _selectedVentaId);
					MessageBox.Show($"Error al eliminar la venta: {ex.Message}", "Error",
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
			await FiltrarVentasAsync();
		}

		private async Task FiltrarVentasAsync()
		{
			try
			{
				PbProgreso.Visible = true;
				PbProgreso.Style = ProgressBarStyle.Marquee;

				DateTime fechaDesde = DtpFechaDesde.Value.Date;
				DateTime fechaHasta = DtpFechaHasta.Value.Date.AddDays(1); // Fin del día
				string cliente = TxtCliente.Text.Trim();
				string idRemitoText = TxtIdRemito.Text.Trim();

				// Intentar parsear el ID de remito si se proporciona
				int? idRemito = null;
				if (!string.IsNullOrEmpty(idRemitoText) && int.TryParse(idRemitoText, out int parsedId))
				{
					idRemito = parsedId;
				}

				var result = await Task.Run(() => _hVentasService.GetFiltered(fechaDesde, fechaHasta, cliente, idRemito));

				if (result.IsSuccess)
				{
					_ventas = result.Value;
					ActualizarListaVentas();
				}
				else
				{
					MessageBox.Show($"Error al filtrar ventas: {result.Error}", "Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error al filtrar ventas");
				MessageBox.Show($"Error al filtrar ventas: {ex.Message}", "Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				PbProgreso.Visible = false;
			}
		}



		private void ConfigurarDGV()
		{
			// Configurar DataGridView de ventas
			DgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DgvVentas.MultiSelect = false;
			DgvVentas.ReadOnly = true;
			DgvVentas.AllowUserToAddRows = false;
			DgvVentas.AllowUserToDeleteRows = false;
			DgvVentas.RowHeadersVisible = false;
			DgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DgvVentas.AllowUserToResizeRows = false;
			DgvVentas.AllowUserToResizeColumns = true;
			DgvVentas.AutoGenerateColumns = false;


			// Asegurar que el DataGridView puede recibir el foco y selecciones
			DgvVentas.TabStop = true;
			DgvVentas.Enabled = true;

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
			DgvVentas.Columns.Clear();
			DgvDetalles.Columns.Clear();

			// Configurar columnas para DgvVentas
			var ventasColumns = new[]
			{
				new DataGridViewTextBoxColumn
				{
					Name = "Id_Remito",
					DataPropertyName = "Id_Remito",
					HeaderText = "Nº VENTA",
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
					Name = "Id_Cliente",
					DataPropertyName = "Id_Cliente",
					HeaderText = "Cliente",
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
					Name = "Descripcion",
					DataPropertyName = "Descripcion",
					HeaderText = "Descripción",
					Visible = true,
					AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
				}
			};

			foreach (var column in ventasColumns)
			{
				DgvVentas.Columns.Add(column);
			}


			// Configurar columnas para DgvDetalles usando el nuevo método
			ConfigurarColumnasDetalles();
		}

		private async void BtnActualizar_Click(object sender, EventArgs e)
		{
			await CargarVentasAsync();
		}

		private void BtnImprimir_Click(object sender, EventArgs e)
		{
			Utilidades.Impresion.ImpresionTicket imp = new();
			imp.ImprimiriTextSharp(
				productos: [.. _detallesVenta.Select(d => new Utilidades.Impresion.ProductoVenta
				{
					Nombre = d.Descr,
					Cantidad = d.Cant,
					Precio = d.P_Unit,
					Subtotal = d.P_X_Cant, // Asumiendo que P_X_Cant es el subtotal sin IVA ni descuento
					IVA = 0, // Ajustar según sea necesario
					Descuento = 0, // Ajustar según sea necesario
					Total = d.P_X_Cant, // Ajustar según sea necesario

				})],

				numeroOperacion: _selectedVentaId.ToString(),
				motivo: LblDescripcion.Text,
				montoTotal: LblTotal.Text,
				fechaOperacion: LblFecha.Text,
				tituloOperacion: "Ticket de Venta",
				descuento: LblDescuento.Text
			);
		}

		private void UCConsultaVentas_VisibleChanged(object sender, EventArgs e)
		{

			AsegurarConfiguracionColumnasDetalles();
		}


		private void UCConsultaVentas_Paint(object sender, PaintEventArgs e)
		{
			AsegurarConfiguracionColumnasDetalles();

		}

		private void AsegurarConfiguracionColumnasDetalles()
		{
			// Ensure auto-generation is disabled
			DgvDetalles.AutoGenerateColumns = false;

			// Verify that hidden columns remain hidden
			if (DgvDetalles.Columns["Id_Det_Remito"] != null)
				DgvDetalles.Columns["Id_Det_Remito"]!.Visible = false;

			if (DgvDetalles.Columns["Id_Remito"] != null)
				DgvDetalles.Columns["Id_Remito"]!.Visible = false;


		}

		
	}
}
