using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Agraria.Contrato.Servicios;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;
using Agraria.Contrato;
using Agraria.Util;
using Agraria.Servicio;

namespace Agraria.UI.Ventas
{
    public partial class UCIngresoVenta : UserControl
    {
        // TODO: REVISAR POR QUE NO SE PUEDE EFECUTAR LA VENTA QUE NO ENCUENTRA ARTICULOS EN LA LISTA
        private readonly IArticuloStockService _articuloStockService;
        private readonly IVentaService _ventaService;
        private readonly ILogger<UCIngresoVenta> _logger;
        private bool _evitarBucleEventos = false;
        private int _indiceSeleccionado;
        private bool _procesandoSeleccion = false;
        private string? _ultimoCodigoArticuloSeleccionado;
        private int _ultimoIndiceSeleccionado = -1;
        private BindingList<ProductoResumen> _productosResumen = [];
        private List<ArticuloStock> _todosLosProductos = [];
        // Agregar en el inicio de la clase
        private readonly CultureInfo _cultureArgentina = new("es-AR");

        public UCIngresoVenta(IArticuloStockService articuloStockService,
                             IVentaService ventaService, ILogger<UCIngresoVenta> logger)
        {
            _articuloStockService = articuloStockService;
            _ventaService = ventaService;
            _logger = logger;
            _indiceSeleccionado = 0;
            _ultimoCodigoArticuloSeleccionado = "";

            InitializeComponent();

            this.Disposed += UCIngresoVenta_Disposed;
        }





        private string FormatearPesoArgentino(decimal valor)
        {
            return valor.ToString("C", _cultureArgentina);
        }

        private static (int cantidad, decimal total) CalcularTotales(List<ProductoResumen> productos)
        {
            int cantidad = productos.Count;
            decimal total = productos.Sum(p => p.Producto_PrecioxCantidad);

            return (cantidad, total);
        }

        private void ConfigurarDGV()
        {
            DgvProductosSeleccionados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvProductosSeleccionados.AllowUserToAddRows = false;
            DgvProductosSeleccionados.AllowUserToDeleteRows = false;
            DgvProductosSeleccionados.ReadOnly = true;
            DgvProductosSeleccionados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgvProductosSeleccionados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvProductosSeleccionados.MultiSelect = false;
            DgvProductosSeleccionados.RowHeadersVisible = false;
            DgvProductosSeleccionados.AllowUserToResizeRows = false;
            DgvProductosSeleccionados.AllowUserToResizeColumns = true;
            DgvProductosSeleccionados.AutoGenerateColumns = false;

            // Asegurar que el DataGridView puede recibir el foco y selecciones
            DgvProductosSeleccionados.TabStop = true;
            DgvProductosSeleccionados.Enabled = true;

            ConfigurarColumnasDataGridView();
        }

        private void SeleccionarFilaPorCodigoArticulo(string codigoArticulo)
        {
            for (int i = 0; i < DgvProductosSeleccionados.Rows.Count; i++)
            {
                if (DgvProductosSeleccionados.Rows[i].DataBoundItem is ProductoResumen producto &&
                    producto.Cod_Articulo == codigoArticulo)
                {
                    DgvProductosSeleccionados.ClearSelection();
                    DgvProductosSeleccionados.Rows[i].Selected = true;
                    DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[i].Cells[1];

                    // Actualizar el seguimiento
                    _ultimoCodigoArticuloSeleccionado = codigoArticulo;
                    _ultimoIndiceSeleccionado = i;
                    break;
                }
            }
        }

        private void ConfigurarColumnasDataGridView()
        {
            DgvProductosSeleccionados.Columns.Clear();

            var stylePesos = new DataGridViewCellStyle
            {
                Format = "C",
                FormatProvider = _cultureArgentina,
                Alignment = DataGridViewContentAlignment.MiddleRight
            };

            var columns = new[]
            {
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoId",
                    DataPropertyName = "Cod_Articulo",
                    HeaderText = "ID",
                    Visible = false
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoNombre",
                    DataPropertyName = "Producto_Nombre",
                    HeaderText = "Producto",
                    Width = 200,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,

                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoCantidad",
                    DataPropertyName = "Producto_Cantidad",
                    HeaderText = "Cantidad",
                    Width = 80,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoPrecioUnitario",
                    DataPropertyName = "Producto_Precio",
                    HeaderText = "Precio Unitario",
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,

                    DefaultCellStyle = stylePesos
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "ProductoPrecioTotal",
                    DataPropertyName = "Producto_PrecioxCantidad",
                    HeaderText = "Total",
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,

                    DefaultCellStyle = stylePesos
                }
            };

            foreach (var column in columns)
            {
                DgvProductosSeleccionados.Columns.Add(column);
            }
        }

        private void LsvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_evitarBucleEventos) return;

            if (LsvProductos.SelectedItem is ArticuloStock selectedItem)
            {
                LblProducto.Text = selectedItem.Art_Desc;
                // Corregir el cálculo del precio
                decimal precio = selectedItem.Costo * (1 + selectedItem.Ganancia / 100);
                LblPrecio.Text = precio.ToString();

                // Seleccionar la fila correspondiente en el DataGridView
                _evitarBucleEventos = true;
                SeleccionarFilaPorCodigoArticulo(selectedItem.Cod_Articulo);
                _evitarBucleEventos = false;
            }
            else
            {
                LblProducto.Text = string.Empty;
                LblPrecio.Text = string.Empty;
                if (!_evitarBucleEventos)
                {
                    DgvProductosSeleccionados.ClearSelection();
                }
            }

            ActualizarTotalPrecioPorCantidad();
            NumericUpDown1.Value = 1;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ActualizarTotalPrecioPorCantidad();
        }

        private void ActualizarTotalPrecioPorCantidad()
        {
            decimal precio = 0m;
            if (LsvProductos.SelectedItem is ArticuloStock selectedItem)
            {
                precio = selectedItem.Costo * (1 + selectedItem.Ganancia / 100);
            }

            decimal total = precio * NumericUpDown1.Value;
            LblPrecioCant.Text = FormatearPesoArgentino(total);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (LsvProductos.SelectedItem is ArticuloStock producto)
            {
                decimal cantidad = NumericUpDown1.Value;
                AgregarProductosAlCarrito(producto, cantidad);

                _evitarBucleEventos = true;
                CargarDataGridView();

                // Después de agregar, seleccionar el producto añadido
                SeleccionarFilaPorCodigoArticulo(producto.Cod_Articulo);

                _evitarBucleEventos = false;
            }
            else
            {
                MostrarMensajeAdvertencia("Por favor, selecciona un producto.");
            }
        }

        private void AgregarProductosAlCarrito(ArticuloStock producto, decimal cantidad)
        {
            // Calcular el precio unitario correctamente
            decimal precioUnitario = producto.Costo * (1 + producto.Ganancia / 100);
            decimal precioTotal = precioUnitario * cantidad;

            // Buscar si el producto ya existe en el carrito
            var productoExistente = SingleListas.Instance.ProductoResumen
                .FirstOrDefault(p => p.Cod_Articulo == producto.Cod_Articulo);

            if (productoExistente != null)
            {
                // Si existe, actualizar la cantidad y el precio total
                productoExistente.Producto_Cantidad += cantidad;
                productoExistente.Producto_PrecioxCantidad = productoExistente.Producto_Cantidad * productoExistente.Producto_Precio;
            }
            else
            {
                // Si no existe, crear un nuevo producto resumen
                ProductoResumen nuevoProducto = new()
                {
                    Cod_Articulo = producto.Cod_Articulo,
                    Producto_Nombre = producto.Art_Desc,
                    Producto_Precio = precioUnitario,
                    Producto_Cantidad = cantidad,
                    Producto_PrecioxCantidad = precioTotal
                };
                SingleListas.Instance.ProductoResumen.Add(nuevoProducto);
            }
        }

        private void CargarDataGridView()
        {
            string? codigoArticuloSeleccionado = _ultimoCodigoArticuloSeleccionado;
            int indiceSeleccionado = _ultimoIndiceSeleccionado;

            //ListaProductos(SingleListas.Instance.ProductosSeleccionados);

            var (cantidad, total) = CalcularTotales(SingleListas.Instance.ProductoResumen);
            LblCantProductos.Text = cantidad.ToString();
            LblPrecioTotal.Text = FormatearPesoArgentino(total);

            // Limpiar y recargar la lista de productos resumen
            _productosResumen.Clear();
            foreach (var item in SingleListas.Instance.ProductoResumen)
            {
                _productosResumen.Add(item);
            }

            if (_productosResumen.Count == 0)
            {
                LimpiarSeleccionCompleta();
                _ultimoCodigoArticuloSeleccionado = null;
                _ultimoIndiceSeleccionado = -1;
                return;
            }

            int indiceParaSeleccionar = -1;

            if (!string.IsNullOrEmpty(codigoArticuloSeleccionado))
            {
                indiceParaSeleccionar = _productosResumen
                    .ToList()
                    .FindIndex(p => p.Cod_Articulo == codigoArticuloSeleccionado);

                if (indiceParaSeleccionar == -1)
                {
                    // El artículo que estaba seleccionado por código ya no existe.
                    // Seleccionar la primera fila y continuar.
                    indiceParaSeleccionar = 0;
                }
            }
            else if (indiceSeleccionado >= 0)
            {
                // No había selección por código, intentar por índice.
                indiceParaSeleccionar = Math.Min(indiceSeleccionado, _productosResumen.Count - 1);
            }
            else
            {
                // Sin selección previa, seleccionar la primera fila.
                indiceParaSeleccionar = 0;
            }

            if (indiceParaSeleccionar >= 0)
            {
                DgvProductosSeleccionados.ClearSelection();
                DgvProductosSeleccionados.Rows[indiceParaSeleccionar].Selected = true;
                DgvProductosSeleccionados.CurrentCell = DgvProductosSeleccionados.Rows[indiceParaSeleccionar].Cells[1];

                if (DgvProductosSeleccionados.Rows[indiceParaSeleccionar].DataBoundItem is ProductoResumen productoSeleccionado)
                {
                    SeleccionarProductoEnListBox(productoSeleccionado.Cod_Articulo);
                    _ultimoCodigoArticuloSeleccionado = productoSeleccionado.Cod_Articulo;
                    _ultimoIndiceSeleccionado = indiceParaSeleccionar;
                }
            }
            else
            {
                LimpiarSeleccionCompleta();
            }
        }

        private void LimpiarSeleccionCompleta()
        {
            _evitarBucleEventos = true;

            LsvProductos.SelectedIndex = -1;
            DgvProductosSeleccionados.ClearSelection();
            LblProducto.Text = string.Empty;
            LblPrecio.Text = string.Empty;
            LblPrecioCant.Text = 0m.ToString("C2");
            NumericUpDown1.Value = 1;

            _evitarBucleEventos = false;
        }


        private async void UCIngresoVenta_Load(object sender, EventArgs e)
        {


            _logger.LogInformation("Cargando UCIngresoVenta.");
            // Configurar primero los controles
            ConfigurarDGV();
            ConfigurarListBox();
            DgvProductosSeleccionados.DataSource = _productosResumen;

            // Asegurar que el UserControl pueda recibir teclas
            this.Focus();
            this.Select();
            // Establecer el foco en el primer control relevante
            TxtBuscardor.Focus();

            // Luego cargar productos asíncronamente
            await CargarProductosAsync();

            // Forzar un refresh visual
            this.Refresh();
        }

        private void ConfigurarListBox()
        {
            // Configuración del control ListBox que reemplaza al ListView
            LsvProductos.DisplayMember = "Art_Desc";
            LsvProductos.ValueMember = "Cod_Articulo";
            LsvProductos.SelectionMode = SelectionMode.One;
        }

        private void FiltrarYMostrarProductos()
        {
            try
            {
                string filtro = TxtBuscardor.Text.Trim().ToLowerInvariant();

                var productosFiltrados = _todosLosProductos
                    .Where(p => string.IsNullOrEmpty(filtro) || p.Art_Desc.Contains(filtro, StringComparison.InvariantCultureIgnoreCase) || p.Cod_Articulo.StartsWith(filtro))
                    .ToList();

                LsvProductos.BeginUpdate();
                LsvProductos.Items.Clear();

                foreach (var articulo in productosFiltrados)
                {
                    LsvProductos.Items.Add(articulo);
                }

                // Seleccionar el primer item si existe
                if (LsvProductos.Items.Count > 0)
                {
                    LsvProductos.SelectedIndex = 0;
                }
                else
                {
                    LsvProductos_SelectedIndexChanged(this, EventArgs.Empty);
                }

                LsvProductos.EndUpdate();

                // Forzar redibujado
                LsvProductos.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en FiltrarYMostrarProductos: {ex.Message}");

            }
        }

        private async Task CargarProductosAsync()
        {
            try
            {
                // Mostrar indicador de carga
                LsvProductos.Visible = false;
                Cursor = Cursors.WaitCursor;

                var result = await _articuloStockService.GetAllArticuloStock();
                if (result.IsSuccess)
                {
                    _todosLosProductos = result.Value;

                    // Invoke para asegurar ejecución en el hilo de UI
                    this.Invoke((MethodInvoker)delegate
                    {
                        FiltrarYMostrarProductos();
                        LsvProductos.Visible = true;
                    });
                }
                else
                {
                    MostrarMensajeError("Error al cargar los productos. " + result.Error);
                    _todosLosProductos.Clear();
                    LsvProductos.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task ConfirmarVentaAsync()
        {
            if (SingleListas.Instance.ProductosSeleccionados.Count == 0)
            {
                MostrarMensajeAdvertencia("No hay productos seleccionados para la venta.");
                return;
            }
            DialogResult dr = MessageBox.Show("¿Estas seguro que queres finalizar la venta?", "Confirmación de venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            await ProcesarVentaAsync();
        }
        private async void BtnConfirmarVenta_Click(object sender, EventArgs e)
        {
            await ConfirmarVentaAsync();
        }

        private async Task ProcesarVentaAsync()
        {
            Result<bool>? result = null;
            try
            {
                decimal subtotal = Convert.ToDecimal(LblPrecioTotal.Text.Split('$')[1], _cultureArgentina);
                decimal descuento = 0;

                var hVentas = new HVentas
                {
                    Cod_Usuario = 2, // TODO: Reemplazar con el usuario actual
                    Id_Cliente = 2,     // TODO: Reemplazar con el cliente seleccionado
                    Descu = descuento,
                    Subtotal = subtotal,
                    Total = subtotal - descuento
                };

                result = await _ventaService.Add(hVentas, [.. _productosResumen]);

                if (result.IsSuccess)
                {
                    MostrarMensajeExito("Venta procesada correctamente.");
                    LimpiarFormulario();
                }
                else
                {
                    MostrarMensajeError("Error al procesar la venta.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al procesar venta UI: {ex.Message} " + result?.Error);
            }
        }

        private void LimpiarFormulario()
        {
            SingleListas.Instance.ProductosSeleccionados.Clear();
            _productosResumen.Clear();

            LimpiarSeleccion();
            NumericUpDown1.Value = 1;
            LblCantProductos.Text = "0";
            LblPrecioTotal.Text = 0m.ToString("C2");

            // Resetear las variables de seguimiento
            _ultimoCodigoArticuloSeleccionado = null;
            _ultimoIndiceSeleccionado = -1;
        }

        private void LimpiarSeleccion()
        {
            _evitarBucleEventos = true;

            LsvProductos.SelectedIndex = -1;
            DgvProductosSeleccionados.ClearSelection();
            LblProducto.Text = string.Empty;
            LblPrecio.Text = string.Empty;
            ActualizarTotalPrecioPorCantidad();

            _evitarBucleEventos = false;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            QuitarUnidadSeleccionada();
        }

        private void QuitarUnidadSeleccionada()
        {
            if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is not ProductoResumen articulo)
            {
                return;
            }

            var articuloQuitar = SingleListas.Instance.ProductosSeleccionados
                .FirstOrDefault(p => p.Cod_Articulo == articulo.Cod_Articulo);

            if (articuloQuitar != null)
            {
                SingleListas.Instance.ProductosSeleccionados.Remove(articuloQuitar);
                CargarDataGridView();

            }
        }

        private void QuitarFilaSeleccionada()
        {
            if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is not ProductoResumen articulo)
            {
                return;
            }

            var articuloQuitar = SingleListas.Instance.ProductosSeleccionados
                .FirstOrDefault(p => p.Cod_Articulo == articulo.Cod_Articulo);

            if (articuloQuitar != null)
            {
                SingleListas.Instance.ProductosSeleccionados.RemoveAll(p => p.Cod_Articulo == articulo.Cod_Articulo);
                CargarDataGridView();

            }
        }


        private void DgvProductosSeleccionados_SelectionChanged(object sender, EventArgs e)
        {
            if (_procesandoSeleccion || _evitarBucleEventos) return;

            _procesandoSeleccion = true;
            try
            {
                if (DgvProductosSeleccionados.CurrentRow?.DataBoundItem is ProductoResumen productoSeleccionado)
                {
                    _indiceSeleccionado = DgvProductosSeleccionados.CurrentRow.Index;
                    _ultimoCodigoArticuloSeleccionado = productoSeleccionado.Cod_Articulo;
                    _ultimoIndiceSeleccionado = _indiceSeleccionado;

                    if (productoSeleccionado.Cod_Articulo != null)
                        SeleccionarProductoEnListBox(productoSeleccionado.Cod_Articulo);
                }
            }
            finally
            {
                _procesandoSeleccion = false;
            }
        }

        private void SeleccionarProductoEnListBox(string codigoArticulo)
        {
            if (DgvProductosSeleccionados.Rows.Count == 0)
            {
                LimpiarSeleccionCompleta();
                return;
            }

            if (LsvProductos.Items.Count == 0) return;

            if (_evitarBucleEventos && !_procesandoSeleccion) return;

            var itemASeleccionar = LsvProductos.Items.OfType<ArticuloStock>()
                .FirstOrDefault(a => a.Cod_Articulo == codigoArticulo);

            LsvProductos.SelectedIndexChanged -= LsvProductos_SelectedIndexChanged;

            LsvProductos.SelectedItem = itemASeleccionar;

            if (itemASeleccionar != null)
            {
                LblProducto.Text = itemASeleccionar.Art_Desc;
                decimal precio = itemASeleccionar.Costo * (1 + itemASeleccionar.Ganancia / 100);
                LblPrecio.Text = precio.ToString();
            }
            else
            {
                // Si no se encuentra el artículo (p.ej. fue quitado), limpiar los labels
                LblProducto.Text = string.Empty;
                LblPrecio.Text = string.Empty;
                ActualizarTotalPrecioPorCantidad();
            }

            LsvProductos.SelectedIndexChanged += LsvProductos_SelectedIndexChanged;
        }

        #region Métodos de utilidad para mensajes
        private static void MostrarMensajeAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private static void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void MostrarMensajeExito(string mensaje)
        {
            MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void DgvProductosSeleccionados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Deshabilitar temporalmente los eventos
                _evitarBucleEventos = true;

                try
                {
                    var selectedRow = DgvProductosSeleccionados.Rows[e.RowIndex];
                    if (selectedRow.DataBoundItem is ProductoResumen producto && producto.Cod_Articulo != null)
                    {
                        SeleccionarProductoEnListBox(producto.Cod_Articulo);
                    }
                }
                finally
                {
                    _evitarBucleEventos = false;
                }
            }
        }

        private void UCIngresoVenta_Disposed(object sender, EventArgs e)
        {
            SingleListas.Instance.ProductoResumen.Clear();
            SingleListas.Instance.ProductosSeleccionados.Clear();
        }

        private void TxtBuscardor_TextChanged(object sender, EventArgs e)
        {
            FiltrarYMostrarProductos();
        }

        /// <summary>
        /// Procesa las teclas de función y otros comandos antes de que sean procesados por el control
        /// </summary>
        /// <param name="msg">Mensaje de ventana</param>
        /// <param name="keyData">Tecla presionada</param>
        /// <returns>True si la tecla fue procesada, false en caso contrario</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    QuitarUnidadSeleccionada();
                    return true;

                case Keys.F9:
                    QuitarFilaSeleccionada();
                    return true;

                case Keys.Enter:
                    if (TxtBuscardor.Focused || LsvProductos.Focused || NumericUpDown1.Focused)
                    {
                        BtnAceptar.PerformClick();
                        return true;
                    }
                    break;

                case Keys.Delete:
                    if (DgvProductosSeleccionados.Focused)
                    {
                        QuitarUnidadSeleccionada();
                        return true;
                    }
                    break;

                case Keys.F12:
                    _ = ConfirmarVentaAsync(); // Usamos el operador de descarte (_) para no esperar
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}