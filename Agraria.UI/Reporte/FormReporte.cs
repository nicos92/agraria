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

namespace Agraria.UI.Reporte
{
    public partial class FormReporte : Form
    {
        // Service dependencies (in a real implementation, these would be injected)
        private readonly IProductoStockService? _productoStockService;
        private readonly IEntornoService? _entornoService;
        private readonly IEntornoFormativoService? _entornoFormativoService;
        private readonly IUsuariosService _usuariosService;
        private readonly IProveedoresService _proveedorService;
        private readonly IHojadeVidaService _hojadeVidaService;
        private readonly IActividadService _actividadService;
        private readonly IHerramientasService _herramientasService;

        public FormReporte()
        {
            InitializeComponent();
        }

        // Constructor with service injection (for dependency injection pattern)
        public FormReporte(
            IProductoStockService? articuloStockService = null,
            IEntornoService? entornoService = null,
            IEntornoFormativoService? entornoFormativoService = null,
            IUsuariosService? usuariosService = null,
            IProveedoresService? proveedorService = null,
            IHojadeVidaService? hojadeVidaService = null,
            IActividadService? actividadService = null)
        {
            InitializeComponent();
            _productoStockService = articuloStockService;
            _entornoService = entornoService;
            _entornoFormativoService = entornoFormativoService;
            _usuariosService = usuariosService;
            _proveedorService = proveedorService;
            _hojadeVidaService = hojadeVidaService;
            _actividadService = actividadService;
        }

        private void btnMasVendidos_Click(object sender, EventArgs e)
        {
            // TODO: Implementar la lógica para cargar el reporte de artículos más vendidos
            
        }

        private void btnVentasGrandes_Click(object sender, EventArgs e)
        {
            // TODO: Implementar la lógica para cargar el reporte de ventas por período
           
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            // TODO: Implementar la lógica para cargar el reporte de stock actual
           
        }

        private async void btnActividades_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ID Actividad");
                dt.Columns.Add("ID Tipo Entorno");
                dt.Columns.Add("ID Entorno");
                dt.Columns.Add("ID Entorno Formativo");
                dt.Columns.Add("Fecha Actividad");
                dt.Columns.Add("Descripción");

                // In a real implementation, this would come from _actividadService.GetAll()
                var resultado = _actividadService != null ? await _actividadService.GetAll() : null;
                var actividades = resultado?.Value ?? new List<Modelo.Entidades.Actividad>();

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

        private async void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ID Producto");
                dt.Columns.Add("Código Producto");
                dt.Columns.Add("Descripción");
                dt.Columns.Add("ID Área");
                dt.Columns.Add("ID Entorno");
                dt.Columns.Add("ID Proveedor");
                dt.Columns.Add("Unidad de Medida");

                // In a real implementation, this would come from _articuloStockService.GetAllProductos()
                var resultado = _productoStockService != null ? await _productoStockService.GetAllArticuloStock() : null;
                var productos = resultado?.Value ?? new List<ProductoStock>();

                foreach (var producto in productos)
                {
                    dt.Rows.Add(
                        producto.Id_Producto,
                        producto.Cod_Producto,
                        producto.Art_Desc,
                        producto.Cod_TipoEntorno,
                        producto.Cod_Entorno,
                        producto.Id_Proveedor,
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

        private async void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ID Usuario");
                dt.Columns.Add("DNI");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Apellido");
                dt.Columns.Add("Teléfono");
                dt.Columns.Add("Email");
                dt.Columns.Add("ID Tipo");
                dt.Columns.Add("Descripción");

                // In a real implementation, this would come from _usuariosService.GetAll()
                var resultado = _usuariosService != null ? await _usuariosService.GetAll() : null;
                var usuarios = resultado?.Value ?? new List<Modelo.Entidades.Usuarios>();

                foreach (var usuario in usuarios)
                {
                    dt.Rows.Add(
                        usuario.Id_Usuario,
                        usuario.DNI,
                        usuario.Nombre,
                        usuario.Apellido,
                        usuario.Tel,
                        usuario.Mail,
                        usuario.Id_Tipo,
                        usuario.Descripcion
                    );
                }

                dgvReporte.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el reporte de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ID Proveedor");
                dt.Columns.Add("CUIT");
                dt.Columns.Add("Nombre Comercial");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Teléfono");
                dt.Columns.Add("Email");
                dt.Columns.Add("Observación");

                // In a real implementation, this would come from _proveedorService.GetAll()
                var resultado = _proveedorService != null ? await _proveedorService.GetAll() : null;
                var proveedores = resultado?.Value ?? new List<Modelo.Entidades.Proveedores>();

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

        private async void btnHerramientas_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ID Herramienta");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Descripción");
                dt.Columns.Add("Cantidad");

              
                var resultado = _herramientasService != null ? 
                    await _herramientasService.GetAll() : 
                    null;

                List<Herramientas> herramientas = resultado?.Value ?? new List<Herramientas>();

                if (herramientas.Count == 0)
                {
              
                    herramientas = new List<Herramientas>
                    {
                        new Herramientas { Id_Herramienta = 1, Nombre = "Pala", Descripcion = "Pala de jardinería", Cantidad = 5 },
                        new Herramientas { Id_Herramienta = 2, Nombre = "Azada", Descripcion = "Azada para labranza", Cantidad = 3 }
                    };
                }

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

        private async void btnEntorno_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ID Entorno");
                dt.Columns.Add("Nombre Entorno");
                dt.Columns.Add("ID Área");

                // In a real implementation, this would come from _entornoService.GetAll()
                var resultado = _entornoService != null ? await _entornoService.GetAll() : null;
                var entornos = resultado?.Value ?? new List<Entorno>();

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

        private async void btnEntornoFormativo_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("ID Entorno Formativo");
                dt.Columns.Add("ID Entorno");
                dt.Columns.Add("ID Usuario");
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
                            entornoFormativo.Activo
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

        private async void btnHojaVida_Click(object sender, EventArgs e)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Código");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Tipo Animal");
                dt.Columns.Add("Sexo");
                dt.Columns.Add("Fecha Nacimiento");
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
                            hojaVida.Activo
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
