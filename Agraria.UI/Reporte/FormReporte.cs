using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Utilidades;
using Agraria.Utilidades.Impresion;
using Agraria.Modelo.Records; // Añadir esta referencia

namespace Agraria.UI.Reporte
{
	public partial class FormReporte : Form
	{
		// Service dependencies (in a real implementation, these would be injected)
		private readonly IProductoStockService _productoStockService;
		private readonly IEntornoService _entornoService;
		private readonly IEntornoFormativoService _entornoFormativoService;
		private readonly IUsuariosService _usuariosService;
		private readonly IProveedoresService _proveedorService;
		private readonly IHojadeVidaService _hojadeVidaService;
		private readonly IActividadService _actividadService;
		private readonly IHerramientasService _herramientasService;
		private readonly IVentaService _ventaService;
		private readonly IProductoService _productosService;
		private readonly ITipoEntornosService _tipoEntornosService;
		private readonly IArticulosGralService _articulosGralService;

		private Button _btnClickeado;
		private List<Agraria.Modelo.Entidades.HojadeVida>? _currentHojasDeVida; // Variable para almacenar las hojas de vida actuales
		private List<Agraria.Modelo.Entidades.HVentasConUsuario>? _currentVentasGrandes; // Variable para almacenar las ventas grandes actuales
		private List<Agraria.Modelo.Records.EntornoFormativoConNombres>? _currentEntornosFormativos; // Variable para almacenar los entornos formativos actuales
		private List<Agraria.Modelo.Entidades.ProductoStockConNombres>? _currentProductosStock; // Variable para almacenar los productos con stock actuales
		private List<ProductosMasVendidos>? _currentProductosMasVendidos; // Variable para almacenar los productos más vendidos actuales
		private List<Agraria.Modelo.Records.ActividadConNombres>? _currentActividades; // Variable para almacenar las actividades actuales
		private List<Agraria.Modelo.Records.UsuarioConTipo>? _currentUsuarios; // Variable para almacenar los usuarios actuales
		private List<Agraria.Modelo.Entidades.Proveedores>? _currentProveedores; // Variable para almacenar los proveedores actuales
		private List<Agraria.Modelo.Entidades.Herramientas>? _currentHerramientas; // Variable para almacenar las herramientas actuales
		private List<Agraria.Modelo.Entidades.ArticulosGral>? _currentArticulosGral; // Variable para almacenar los artículos generales actuales


		private void ConfigBtnsTags()
		{
			btnActividades.Tag = typeof(ActividadConNombres);
			btnEntornoFormativo.Tag = typeof(EntornoFormativoConNombres);
			btnHerramientas.Tag = typeof(Herramientas);
			btnMasVendidos.Tag = typeof(ProductosMasVendidos);
			btnHojaVida.Tag = typeof(Modelo.Entidades.HojadeVida);
			btnProveedores.Tag = typeof(Modelo.Entidades.Proveedores);
			btnProductos.Tag = typeof(ProductoStockConNombres);
			btnUsuarios.Tag = typeof(UsuarioConTipo);
			btnVentasGrandes.Tag = typeof(HVentasConUsuario);
			BtnArticulosGral.Tag = typeof(Modelo.Entidades.ArticulosGral);


		}

		// Constructor with service injection (for dependency injection pattern)
		public FormReporte(
			IProductoStockService articuloStockService,
			IEntornoService entornoService,
			IEntornoFormativoService entornoFormativoService,
			IUsuariosService usuariosService,
			IProveedoresService proveedorService,
			IHojadeVidaService hojadeVidaService,
			IActividadService actividadService,
			IVentaService ventaService,
			IProductoService productosService,
			IHerramientasService herramientasService,
			ITipoEntornosService tipoEntornosService,
			IArticulosGralService articulosGralService)
		{
			InitializeComponent();
			_productoStockService = articuloStockService;
			_entornoService = entornoService;
			_entornoFormativoService = entornoFormativoService;
			_usuariosService = usuariosService;
			_proveedorService = proveedorService;
			_hojadeVidaService = hojadeVidaService;
			_actividadService = actividadService;
			_ventaService = ventaService;
			_productosService = productosService;
			_herramientasService = herramientasService;
			_tipoEntornosService = tipoEntornosService;
			_articulosGralService = articulosGralService;
			_btnClickeado = btnMasVendidos;
			dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			Utilidades.Util.ToolTipPdf(BtnImprimir, "Generar Reporte en PDF");


		}

		private async void BtnArticulosGral_Click_1(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);
				var dt = new DataTable();
				dt.Columns.Add("Código");
				dt.Columns.Add("Nombre");

				dt.Columns.Add("Precio", typeof(decimal));
				dt.Columns.Add("Descripción");
				dt.Columns.Add("Stock", typeof(int));
				dt.Columns.Add("Id Proveedor", typeof(int));



				// In a real implementation, this would come from _ventaService.GetArticulosMasVendidos()
				var resultado = await _articulosGralService.GetAll();
				var articulosgral = resultado?.Value ?? [];

				// Store the current most sold products for printing
				_currentArticulosGral = [.. articulosgral];

				foreach (var articulo in articulosgral)
				{
					dt.Rows.Add(
						articulo.Art_Cod,
						articulo.Art_Nombre,
						articulo.Art_Precio,
						articulo.Art_Descripcion,
						articulo.Art_Stock,
						articulo.Id_Proveedor
						);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de artículos : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnMasVendidos_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);
				var dt = new DataTable();
				dt.Columns.Add("Código Producto");
				dt.Columns.Add("Descripción");
				dt.Columns.Add("Cantidad Vendida", typeof(int));
				dt.Columns.Add("Total $ Vendido", typeof(decimal));

				// In a real implementation, this would come from _ventaService.GetArticulosMasVendidos()
				var resultado = await _productosService.GetArticulosMasVendidos(50);
				var articulosMasVendidos = resultado?.Value ?? [];

				// Store the current most sold products for printing
				_currentProductosMasVendidos = [.. articulosMasVendidos];

				foreach (var articulo in articulosMasVendidos)
				{
					dt.Rows.Add(
						articulo.Cod_Producto,
						articulo.Producto_Desc,
						articulo.CantidadVendida,
						articulo.TotalVendido
						);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de artículos más vendidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnClickeado(object sender)
		{
			BtnImprimir.Enabled = true;
			LblTituloReporte.Text = "Reporte de " + ((Button)sender).Text;
			_btnClickeado.BackColor = AppColorsBlue.Primary;
			_btnClickeado.Font = new Font("Segoe UI", 12f, FontStyle.Regular);
			_btnClickeado = (Button)sender;
			_btnClickeado.BackColor = AppColorsBlue.OnPrimaryContainer;
			_btnClickeado.Font = new Font("Segoe UI", 12f, FontStyle.Bold);

		}

		private async void BtnVentasGrandes_Click(object sender, EventArgs e)
		{
			try
			{

				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("ID Remito");
				dt.Columns.Add("Usuario"); // Nueva columna para el nombre del usuario
				dt.Columns.Add("Fecha y Hora", typeof(DateTime));
				dt.Columns.Add("Total $", typeof(decimal));
				dt.Columns.Add("Descripción");

				var resultado = _ventaService != null ? await _ventaService.GetVentasGrandes(10) : null;
				_currentVentasGrandes = resultado?.Value ?? [];

				foreach (var venta in _currentVentasGrandes)
				{
					dt.Rows.Add(
						venta.Id_Remito.ToString().Trim().PadLeft(8, '0'),
						$"{venta.NombreUsuario} {venta.ApellidoUsuario}", // Combinar nombre y apellido
						venta.Fecha_Hora.ToString("yyyy-MM-dd HH:mm"),
						venta.Total,
						venta.Descripcion
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de ventas grandes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnStock_Click(object sender, EventArgs e)
		{
			// TODO: Implementar la lógica para cargar el reporte de stock actual de los ArticulosGral
			BtnClickeado(sender);


		}

		private async void BtnActividades_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("Area", typeof(string));
				dt.Columns.Add("Entorno", typeof(string));
				dt.Columns.Add("Entorno Formativo");
				dt.Columns.Add("Fecha Actividad", typeof(DateTime));
				dt.Columns.Add("Descripción");

				// Use the new method that returns area and environment names instead of IDs
				var resultado = await _actividadService.GetAllConNombres();
				var actividades = resultado?.Value ?? [];

				// Store the current activities for printing
				_currentActividades = [.. actividades];

				foreach (var actividad in actividades)
				{
					dt.Rows.Add(
						actividad.Nombre_TipoEntorno,
						actividad.Nombre_Entorno,
						actividad.Nombre_EntornoFormativo,
						actividad.Fecha_Actividad.ToString("yyyy-MM-dd HH:mm"),
						actividad.Descripcion_Actividad
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de actividades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnProductos_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("Código Producto");
				dt.Columns.Add("Descripción");
				dt.Columns.Add("Área");
				dt.Columns.Add("Entorno");
				dt.Columns.Add("Proveedor");
				dt.Columns.Add("Ganancia");
				dt.Columns.Add("Cantidad", typeof(decimal));
				dt.Columns.Add("Costo");

				var resultado = _productoStockService != null ? await _productoStockService.GetAllArticuloStockConNombres() : null;
				var productos = resultado?.Value ?? [];

				_currentProductosStock = [.. productos];

				foreach (var producto in productos)
				{
					dt.Rows.Add(
						producto.Cod_Producto,
						producto.Producto_Desc,
						producto.Nombre_TipoEntorno,
						producto.Nombre_Entorno,
						producto.Nombre_Proveedor,
						producto.Ganancia,
						producto.Cantidad,
						producto.Costo
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnUsuarios_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("DNI", typeof(int));
				dt.Columns.Add("Nombre");
				dt.Columns.Add("Apellido");
				dt.Columns.Add("Teléfono");
				dt.Columns.Add("Email");
				dt.Columns.Add("Tipo");

				// Use the new method that returns user type name instead of ID
				var resultado = _usuariosService != null ? await _usuariosService.GetAllConTipo() : null;
				var usuarios = resultado?.Value ?? [];

				// Store the current users for printing
				_currentUsuarios = [.. usuarios];

				foreach (var usuario in usuarios)
				{
					dt.Rows.Add(
						usuario.DNI,
						usuario.Nombre,
						usuario.Apellido,
						usuario.Tel,
						usuario.Mail,
						usuario.Nombre_Tipo
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnProveedores_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("CUIT");
				dt.Columns.Add("Nombre Comercial");
				dt.Columns.Add("Nombre");
				dt.Columns.Add("Teléfono");
				dt.Columns.Add("Email");
				dt.Columns.Add("Observación");

				// In a real implementation, this would come from _proveedorService.GetAll()
				var resultado = _proveedorService != null ? await _proveedorService.GetAll() : null;
				var proveedores = resultado?.Value ?? [];

				// Store the current providers for printing
				_currentProveedores = [.. proveedores];

				foreach (var proveedor in proveedores)
				{
					dt.Rows.Add(
						proveedor.CUIT,
						proveedor.Proveedor,
						proveedor.Nombre,
						proveedor.Tel,
						proveedor.Email,
						proveedor.Observacion
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnHerramientas_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();

				dt.Columns.Add("ID Herramienta", typeof(int));        // Entero
				dt.Columns.Add("Nombre", typeof(string));              // Texto
				dt.Columns.Add("Descripción", typeof(string));         // Texto
				dt.Columns.Add("Cantidad", typeof(int));               // Entero


				var resultado = await _herramientasService.GetAll();

				List<Herramientas> herramientas = resultado?.Value ?? [];

				// Store the current tools for printing
				_currentHerramientas = [.. herramientas];


				foreach (var herramienta in herramientas)
				{
					dt.Rows.Add(
						herramienta.Id_Herramienta,
						herramienta.Nombre,
						herramienta.Descripcion,
						herramienta.Cantidad
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de herramientas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		

		private async void BtnEntorno_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("ID Entorno", typeof(int));
				dt.Columns.Add("Nombre Entorno");
				dt.Columns.Add("Área");

				// Use the new method that returns area name instead of ID
				var resultado = await _entornoService.GetAllConTipo();
				var entornos = resultado?.Value ?? [];

				foreach (var entorno in entornos)
				{
					dt.Rows.Add(
						entorno.Id_Entorno,
						entorno.Entorno_nombre,
						entorno.Nombre_Area
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de entornos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnEntornos_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("ID Tipo Entorno", typeof(int));
				dt.Columns.Add("Nombre Tipo Entorno");

				// Get the environment types (areas) with their names
				var resultado = _tipoEntornosService != null ? await _tipoEntornosService.GetAllConNombres() : null;
				var tiposEntornos = resultado?.Value ?? [];

				foreach (var tipoEntorno in tiposEntornos)
				{
					dt.Rows.Add(
						tipoEntorno.Id_TipoEntorno,
						tipoEntorno.Nombre
					);
				}

				dgvReporte.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de tipos de entornos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnEntornoFormativo_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("Entorno");
				dt.Columns.Add("Nombre Usuario");
				dt.Columns.Add("Apellido Usuario");
				dt.Columns.Add("Curso Año");
				dt.Columns.Add("Curso División");
				dt.Columns.Add("Curso Grupo");
				dt.Columns.Add("Observaciones");
				dt.Columns.Add("Activo");

				// Use the new method that returns user names and environment names instead of IDs
				var resultado = await _entornoFormativoService.GetAllConNombres();
				if (resultado.IsSuccess)
				{
					_currentEntornosFormativos = resultado?.Value ?? [];

					foreach (var entornoFormativo in _currentEntornosFormativos)
					{
						dt.Rows.Add(
							entornoFormativo.Nombre_Entorno,
							entornoFormativo.Nombre_Usuario,
							entornoFormativo.Apellido_Usuario,
							entornoFormativo.Curso_anio,
							entornoFormativo.Curso_Division,
							entornoFormativo.Curso_Grupo,
							entornoFormativo.Observaciones,
							entornoFormativo.Activo ? "Sí" : "No"
						);
					}

					dgvReporte.DataSource = dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de entornos formativos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void BtnHojaVida_Click(object sender, EventArgs e)
		{
			try
			{
				BtnClickeado(sender);

				var dt = new DataTable();
				dt.Columns.Add("Numero", typeof(int));
				dt.Columns.Add("Tipo Animal");
				dt.Columns.Add("Sexo");
				dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));
				dt.Columns.Add("Peso");
				dt.Columns.Add("Estado Salud");
				dt.Columns.Add("Activo");


				var resultado = await _hojadeVidaService.GetAll();
				if (resultado.IsSuccess)
				{
					_currentHojasDeVida = resultado.Value ?? [];

					foreach (var hojaVida in _currentHojasDeVida)
					{
						dt.Rows.Add(
							hojaVida.Numero,
							hojaVida.TipoAnimal,
							hojaVida.Sexo,
							hojaVida.FechaNacimiento.ToString("yyyy-MM-dd"),
							hojaVida.Peso,
							hojaVida.EstadoSalud,
							hojaVida.Activo ? "Sí" : "No"
						);
					}

					dgvReporte.DataSource = dt;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al cargar el reporte de hojas de vida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void BtnImprimir_Click(object sender, EventArgs e)
		{
			try
			{
				if (_btnClickeado.Tag is not Type tipoReporte)
				{
					MessageBox.Show("El botón seleccionado no tiene un tipo de reporte asociado para imprimir.");
					return;
				}

				IPrintStrategy? strategy = tipoReporte switch
				{
					Type t when t == typeof(Modelo.Entidades.HojadeVida) =>
						new HojaVidaPrintStrategy(ImprimirHojasDeVida()),

					Type t when t == typeof(HVentasConUsuario) =>
						new VentasGrandesPrintStrategy(ImprimirVentasGrandes()),

					Type t when t == typeof(EntornoFormativoConNombres) =>
						new EntornoFormativoPrintStrategy(ImprimirEntornosFormativos()),

					Type t when t == typeof(ProductoStockConNombres) =>
						new ProductosStockPrintStrategy(ImprimirProductosStock()),

					Type t when t == typeof(ProductosMasVendidos) =>
						new ProductosMasVendidosPrintStrategy(ImprimirProductosMasVendidos()),

					Type t when t == typeof(ActividadConNombres) =>
						new ActividadesPrintStrategy(ImprimirActividades()),

					Type t when t == typeof(UsuarioConTipo) =>
						new UsuariosPrintStrategy(ImprimirUsuarios()),

					Type t when t == typeof(Modelo.Entidades.Proveedores) =>
						new ProveedoresPrintStrategy(ImprimirProveedores()),

					Type t when t == typeof(Herramientas) =>
						new HerramientasPrintStrategy(ImprimirHerramientas()),

					Type t when t == typeof(Modelo.Entidades.ArticulosGral) =>
						new ArticulosGralPrintStrategy(ImprimirArticulosGral()),

					_ => null
				};

				if (strategy == null)
				{
					MessageBox.Show("No se ha seleccionado un tipo de reporte válido para imprimir.");
					return;
				}

				if (!strategy.CanPrint())
				{
					MessageBox.Show(strategy.GetEmptyMessage());
					return;
				}

				strategy.Print();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error al imprimir el reporte: {ex.Message}");
			}
		}

		private List<Herramientas> ImprimirHerramientas()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new Herramientas
				{
					Id_Herramienta = Convert.ToInt32(fila.Cells["ID Herramienta"].Value),
					Nombre = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty,
					Descripcion = fila.Cells["Descripción"].Value?.ToString() ?? string.Empty,
					Cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value)
				})
				];
		}

		private List<ActividadConNombres> ImprimirActividades()
		{
			return [..
				dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new ActividadConNombres(
						0,
						fila.Cells["Area"].Value?.ToString() ?? string.Empty,
						fila.Cells["Entorno"].Value?.ToString() ?? string.Empty,
						0,
						fila.Cells["Entorno Formativo"].Value?.ToString() ?? string.Empty,
						DateTime.Parse(fila.Cells["Fecha Actividad"].Value?.ToString() ?? string.Empty),
						fila.Cells["Descripción"].Value?.ToString() ?? string.Empty

					))

				];
		}

		private List<UsuarioConTipo> ImprimirUsuarios()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new UsuarioConTipo(
					
					fila.Cells["DNI"].Value?.ToString() ?? string.Empty,
					fila.Cells["Nombre"].Value?.ToString() ?? string.Empty,
					fila.Cells["Apellido"].Value?.ToString() ?? string.Empty,
					fila.Cells["Teléfono"].Value?.ToString() ?? string.Empty,
					fila.Cells["Email"].Value?.ToString() ?? string.Empty,
					
					fila.Cells["Tipo"].Value?.ToString() ?? string.Empty // Nombre_Tipo
				))
				];
		}

		private List<Modelo.Entidades.Proveedores> ImprimirProveedores()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new Modelo.Entidades.Proveedores
				{
					CUIT = fila.Cells["CUIT"].Value?.ToString() ?? string.Empty,
					Proveedor = fila.Cells["Nombre Comercial"].Value?.ToString() ?? string.Empty,
					Nombre = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty,
					Tel = fila.Cells["Teléfono"].Value?.ToString() ?? string.Empty,
					Email = fila.Cells["Email"].Value?.ToString() ?? string.Empty,
					Observacion = fila.Cells["Observación"].Value?.ToString() ?? string.Empty
				})
				];
		}

		private List<ProductosMasVendidos> ImprimirProductosMasVendidos()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new ProductosMasVendidos(
					fila.Cells["Código Producto"].Value?.ToString() ?? string.Empty,
					fila.Cells["Descripción"].Value?.ToString() ?? string.Empty,
					Convert.ToInt32(fila.Cells["Cantidad Vendida"].Value),
					Convert.ToDecimal(fila.Cells["Total $ Vendido"].Value)
				))
				];
		}

		private List<ProductoStockConNombres> ImprimirProductosStock()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new ProductoStockConNombres(
					0,
					fila.Cells["Código Producto"].Value?.ToString() ?? string.Empty,
					fila.Cells["Descripción"].Value?.ToString() ?? string.Empty,
					fila.Cells["Área"].Value?.ToString() ?? string.Empty,
					fila.Cells["Entorno"].Value?.ToString() ?? string.Empty,
					fila.Cells["Proveedor"].Value?.ToString() ?? string.Empty,
					Convert.ToDecimal(fila.Cells["Ganancia"].Value),
					Convert.ToDecimal(fila.Cells["Cantidad"].Value),
					Convert.ToDecimal(fila.Cells["Costo"].Value)
				))
				];
		}

		private List<EntornoFormativoConNombres> ImprimirEntornosFormativos()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new EntornoFormativoConNombres(
					0,
					fila.Cells["Entorno"].Value?.ToString() ?? string.Empty,
					fila.Cells["Nombre Usuario"].Value?.ToString() ?? string.Empty,
					fila.Cells["Apellido Usuario"].Value?.ToString() ?? string.Empty,
					fila.Cells["Curso Año"].Value?.ToString() ?? string.Empty,
					fila.Cells["Curso División"].Value?.ToString() ?? string.Empty,
					fila.Cells["Curso Grupo"].Value?.ToString() ?? string.Empty,
					fila.Cells["Observaciones"].Value?.ToString() ?? string.Empty,
					fila.Cells["Activo"].Value?.ToString() == "Sí" ? true : false
				))
				];
		}

		private List<HVentasConUsuarioReporte> ImprimirVentasGrandes()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new HVentasConUsuarioReporte(
					Convert.ToInt32(fila.Cells["ID Remito"].Value),
					fila.Cells["Usuario"].Value?.ToString() ?? string.Empty,
					Convert.ToDateTime(fila.Cells["Fecha y Hora"].Value),
					Convert.ToDecimal(fila.Cells["Total $"].Value),
					fila.Cells["Descripción"].Value?.ToString() ?? string.Empty
				))
				];
		}

		private List<HojaDeVidaReporte> ImprimirHojasDeVida()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new HojaDeVidaReporte
				(
					fila.Cells["Numero"].Value?.ToString() ?? string.Empty,
					fila.Cells["Tipo Animal"].Value ?.ToString() ?? string.Empty,
					fila.Cells["Sexo"].Value?.ToString() ?? string.Empty,
					Convert.ToDateTime(fila.Cells["Fecha Nacimiento"].Value),
					Convert.ToDecimal(fila.Cells["Peso"].Value),
					fila.Cells["Estado Salud"].Value?.ToString() ?? string.Empty,
					fila.Cells["Activo"].Value?.ToString() ?? string.Empty
				))
				];
		}

		private List<ArticulosGral> ImprimirArticulosGral()
		{
			return [.. dgvReporte.Rows
				.Cast<DataGridViewRow>()
				.Where(fila => !fila.IsNewRow)
				.Select(fila => new ArticulosGral
				{
					Art_Id = 0,
					Art_Cod = fila.Cells["Código"].Value?.ToString() ?? string.Empty,
					Art_Nombre = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty,
					Art_Uni_Med = UnidadMedida.Kilogramo,
					Art_Precio = Convert.ToDecimal(fila.Cells["Precio"].Value),
					Art_Descripcion = fila.Cells["Descripción"].Value?.ToString() ?? string.Empty,
					Art_Stock = Convert.ToDecimal(fila.Cells["Stock"].Value),
					Id_Proveedor = Convert.ToInt32(fila.Cells["ID Proveedor"].Value)
				})
				];
		}



		private void FormReporte_Load(object sender, EventArgs e)
		{
			ConfigBtnsTags();

		}

		private void BtnImprimir_EnabledChanged(object sender, EventArgs e)
		{
			if (BtnImprimir.Enabled)
			{
				BtnImprimir.BackColor = AppColorsBlue.Error;
			}
			else
			{
				BtnImprimir.BackColor = AppColorsBlue.Secondary;
			}
		}

		

		// Interfaces y implementaciones
		public interface IPrintStrategy
		{
			bool CanPrint();
			void Print();
			string GetEmptyMessage();
		}




	}
}
