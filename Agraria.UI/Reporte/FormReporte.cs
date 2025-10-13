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
using Agraria.Contrato.Servicios;
using BitMiracle.LibTiff.Classic;
using Agraria.Utilidades;

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

        private Button _btnClickeado;

       

        // Constructor with service injection (for dependency injection pattern)
        public FormReporte(
            IProductoStockService articuloStockService ,
            IEntornoService entornoService,
            IEntornoFormativoService entornoFormativoService ,
            IUsuariosService usuariosService,
            IProveedoresService proveedorService,
            IHojadeVidaService hojadeVidaService,
            IActividadService actividadService,
            IVentaService ventaService,
            IProductoService productosService,
            IHerramientasService herramientasService)
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
            _btnClickeado = btnMasVendidos;
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private async void BtnMasVendidos_Click(object sender, EventArgs e)
        {
            try
            {
                BtnClickeado(sender);
                var dt = new DataTable();
                dt.Columns.Add("Código Artículo");
                dt.Columns.Add("Descripción");
                dt.Columns.Add("Cantidad Vendida", typeof(int));
                dt.Columns.Add("Total Vendido");

                // In a real implementation, this would come from _ventaService.GetArticulosMasVendidos()
                var resultado = _ventaService != null ? await _productosService.GetArticulosMasVendidos(50) : null;
                var articulosMasVendidos = resultado?.Value ?? [];

                foreach (var articulo in articulosMasVendidos)
                {
                    dt.Rows.Add(
                        articulo.Cod_Producto,
                        articulo.CantidadVendida,
                        articulo.TotalVendido,
                        articulo.Producto_Desc);
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
            _btnClickeado.BackColor = AppColorsBlue.Primary;
            _btnClickeado.Font = new Font("Segoe UI", 12f, FontStyle.Regular);
            _btnClickeado = (Button)sender;
            _btnClickeado.BackColor = AppColorsBlue.OnPrimaryContainer;
            _btnClickeado.Font = new Font("Segoe UI", 14f, FontStyle.Regular);

        }

        private async void BtnVentasGrandes_Click(object sender, EventArgs e)
        {
            try
            {

                BtnClickeado(sender);

                var dt = new DataTable();
                dt.Columns.Add("ID Remito", typeof(int));
                dt.Columns.Add("Fecha y Hora", typeof(DateTime));
                dt.Columns.Add("Total");
                dt.Columns.Add("Descripción");

                // In a real implementation, this would come from _ventaService.GetVentasGrandes()
                var resultado = _ventaService != null ? await _ventaService.GetVentasGrandes( 10) : null;
                var ventasGrandes = resultado?.Value ?? [];

                foreach (var venta in ventasGrandes)
                {
                    dt.Rows.Add(
                        venta.Id_Remito,
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
            // TODO: Implementar la lógica para cargar el reporte de stock actual
            BtnClickeado(sender);


        }

        private async void BtnActividades_Click(object sender, EventArgs e)
        {
            try
            {
                BtnClickeado(sender);

                var dt = new DataTable();
                dt.Columns.Add("ID Actividad", typeof(int));
                dt.Columns.Add("ID Tipo Entorno", typeof(int));
                dt.Columns.Add("ID Entorno", typeof(int));
                dt.Columns.Add("ID Entorno Formativo", typeof(int));
                dt.Columns.Add("Fecha Actividad", typeof(DateTime));
                dt.Columns.Add("Descripción");

                // In a real implementation, this would come from _actividadService.GetAll()
                var resultado = _actividadService != null ? await _actividadService.GetAll() : null;
                var actividades = resultado?.Value ?? [];

                foreach (var actividad in actividades)
                {
                    dt.Rows.Add(
                        actividad.Id_Actividad,
                        actividad.Id_TipoEntorno,
                        actividad.Id_Entorno,
                        actividad.Id_EntornoFormativo,
                        actividad.Fecha_Actividad.ToString("yyyy-MM-dd"),
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

                // In a real implementation, this would come from _articuloStockService.GetAllProductos()
                var resultado = _productoStockService != null ? await _productoStockService.GetAllArticuloStockConNombres() : null;
                var productos = resultado?.Value ?? [];

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
                dt.Columns.Add("ID Tipo", typeof(int));

                // In a real implementation, this would come from _usuariosService.GetAll()
                var resultado = _usuariosService != null ? await _usuariosService.GetAll() : null;
                var usuarios = resultado?.Value ?? [];

                foreach (var usuario in usuarios)
                {
                    dt.Rows.Add(
                        usuario.DNI,
                        usuario.Nombre,
                        usuario.Apellido,
                        usuario.Tel,
                        usuario.Mail,
                        usuario.Id_Tipo
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
                dt.Columns.Add("ID Proveedor", typeof(int));
                dt.Columns.Add("CUIT", typeof(int));
                dt.Columns.Add("Nombre Comercial");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Teléfono");
                dt.Columns.Add("Email");
                dt.Columns.Add("Observación");

                // In a real implementation, this would come from _proveedorService.GetAll()
                var resultado = _proveedorService != null ? await _proveedorService.GetAll() : null;
                var proveedores = resultado?.Value ?? [];

                foreach (var proveedor in proveedores)
                {
                    dt.Rows.Add(
                        proveedor.Id_Proveedor,
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
                dt.Columns.Add("ID Área", typeof(int));

                // In a real implementation, this would come from _entornoService.GetAll()
                var resultado = _entornoService != null ? await _entornoService.GetAll() : null;
                var entornos = resultado?.Value ?? [];

                foreach (var entorno in entornos)
                {
                    dt.Rows.Add(
                        entorno.Id_Entorno,
                        entorno.Entorno_nombre,
                        entorno.Id_Area
                    );
                }

                dgvReporte.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de entornos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEntornoFormativo_Click(object sender, EventArgs e)
        {
            try
            {
                BtnClickeado(sender);

                var dt = new DataTable();
                dt.Columns.Add("ID Entorno Formativo", typeof(int));
                dt.Columns.Add("ID Entorno", typeof(int));
                dt.Columns.Add("ID Usuario", typeof(int));
                dt.Columns.Add("Curso Año");
                dt.Columns.Add("Curso División");
                dt.Columns.Add("Curso Grupo");
                dt.Columns.Add("Observaciones");
                dt.Columns.Add("Activo");

                var resultado = await _entornoFormativoService.GetAll();
                if (resultado.IsSuccess)
                {


                    var entornosFormativos = resultado?.Value ?? [];

                    foreach (var entornoFormativo in entornosFormativos)
                    {
                        dt.Rows.Add(
                            entornoFormativo.Id_Entorno_Formativo,
                            entornoFormativo.Id_Entorno,
                            entornoFormativo.Id_Usuario,
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
                dt.Columns.Add("Código", typeof(int));
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Tipo Animal");
                dt.Columns.Add("Sexo");
                dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));
                dt.Columns.Add("Peso");
                dt.Columns.Add("Estado Salud");
                dt.Columns.Add("Observaciones");
                dt.Columns.Add("Activo");

                
                var resultado = await _hojadeVidaService.GetAll();
                if (resultado.IsSuccess)
                {


                    var hojasVida = resultado.Value ?? [] ;

                    foreach (var hojaVida in hojasVida)
                    {
                        dt.Rows.Add(
                            hojaVida.Codigo,
                            hojaVida.Nombre,
                            hojaVida.TipoAnimal,
                            hojaVida.Sexo,
                            hojaVida.FechaNacimiento.ToString("yyyy-MM-dd"),
                            hojaVida.Peso,
                            hojaVida.EstadoSalud,
                            hojaVida.Observaciones,
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
    }
}
