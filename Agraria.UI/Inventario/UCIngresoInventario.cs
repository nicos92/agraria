using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Agraria.Util.Validaciones;
using Agraria.Utilidades;
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

namespace Agraria.UI.Inventario
{
    public partial class UCIngresoInventario : UserControl
    {
        #region Atributos y Propiedades

        private readonly IArticulosGralService _articulosService;
        private readonly IProveedoresService _proveedoresService;

        private readonly ArticulosGral _articuloSeleccionado;

        private readonly ValidadorTextBox _vTxtNombre;
        private readonly ValidadorTextBox _vTxtCantidad;
        private readonly ValidadorTextBox _vTxtPrecio;

        private readonly ErrorProvider _epTxtNombre;
        private readonly ErrorProvider _epTxtCantidad;
        private readonly ErrorProvider _epTxtPrecio;

        #endregion Atributos y Propiedades

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCIngresoInventario"/>.
        /// </summary>
        public UCIngresoInventario(IArticulosGralService articulosService, IProveedoresService proveedoresService)
        {
            _articulosService = articulosService;
            _proveedoresService = proveedoresService;
            InitializeComponent();

            _articuloSeleccionado = new ArticulosGral();

            _epTxtNombre = new ErrorProvider();
            _vTxtNombre = new ValidadorDireccion(TxtNombre, _epTxtNombre) { MensajeError = "El Nombre no puede estar vacío" };

            _epTxtCantidad = new ErrorProvider();
            _vTxtCantidad = new ValidadorEntero(TxtCantidad, _epTxtCantidad) { MensajeError = "Número ingresado no válido" };

            _epTxtPrecio = new ErrorProvider();
            _vTxtPrecio = new ValidadorNumeroDecimal(TxtPrecio, _epTxtPrecio) { MensajeError = "Número ingresado no válido" };
        }

        #region Eventos

        /// <summary>
        /// Controla el evento TextChanged de los cuadros de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtNombre, _vTxtCantidad, _vTxtPrecio);
            ValidarUnidadMedida();
        }

        /// <summary>
        /// Controla el evento TextChanged del cuadro de texto de descripción.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void TxtDescripcion_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtNombre, _vTxtCantidad, _vTxtPrecio);
            ValidarUnidadMedida();
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Valida que se haya seleccionado una unidad de medida.
        /// </summary>
        private void ValidarUnidadMedida()
        {
            // Only enable the button if all validations pass AND a unit of measure is selected
            if (CMBUnidadMedida.SelectedItem != null)
            {
                ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtNombre, _vTxtCantidad, _vTxtPrecio);
            }
            else
            {
                BtnIngresar.Enabled = false;
            }
        }

        /// <summary>
        /// Controla el evento SelectedIndexChanged del ComboBox de unidades de medida.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void CmbUnidadMedida_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtNombre, _vTxtCantidad, _vTxtPrecio);
        }

        /// <summary>
        /// Crea un nuevo artículo a partir de los datos introducidos por el usuario.
        /// </summary>
        /// <returns>Verdadero si el artículo se creó correctamente, falso en caso contrario.</returns>
        private bool CrearArticulo()
        {
            if (CMBUnidadMedida.SelectedItem is not UnidadMedida unidadMedida)
            {
                MessageBox.Show("Debe seleccionar una unidad de medida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _articuloSeleccionado.Art_Nombre = TxtNombre.Text;
            _articuloSeleccionado.Art_Stock = Convert.ToInt32(TxtCantidad.Text);
            _articuloSeleccionado.Art_Precio = DecimalFormatter.ParseDecimal(TxtPrecio.Text);
            _articuloSeleccionado.Art_Descripcion = TxtDescripcion.Text;
            _articuloSeleccionado.Art_Uni_Med = unidadMedida;
            if (CMBProveedor.SelectedItem is Modelo.Entidades.Proveedores proveedor)
            {
                _articuloSeleccionado.Id_Proveedor = proveedor.Id_Proveedor;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        /// <summary>
        /// Maneja el evento Load del UserControl.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private async void UCIngresoInventario_Load(object sender, EventArgs e)
        {
            CargarUnidadesMedida();
            await CargarProveedores();
        }

        private async Task CargarProveedores()
        {
            var result = await _proveedoresService.GetAll();
            if (!result.IsSuccess)
            {
                MessageBox.Show($"Ocurrió un error al cargar los proveedores: {result.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CMBProveedor.DataSource = null;
            CMBProveedor.DataSource = result.Value;
            CMBProveedor.DisplayMember = "Proveedor";
            CMBProveedor.ValueMember = "Id_Proveedor";
        }

        /// <summary>
        /// Carga las unidades de medida en el ComboBox correspondiente.
        /// </summary>
        private void CargarUnidadesMedida()
        {
            try
            {
                var unidades = Enum.GetValues<UnidadMedida>()
                    .Cast<UnidadMedida>()
                    .ToList();
                CMBUnidadMedida.DataSource = unidades;
                CMBUnidadMedida.DisplayMember = "ToString";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al cargar las unidades de medida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

        

        #endregion Métodos Privados

        #region Otros Metodos

        /// <summary>
        /// Controla el evento Click del botón Ingresar.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Estas seguro que queres hacer el ingreso?", "Ingreso de Artículo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;
            if (!CrearArticulo())
            {
                MessageBox.Show("Artículo no creado", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tarea = new TareasLargas(PanelMedio, ProgressBar, InsertarArticuloStock, LimpiarAsync);
            tarea.Iniciar();
        }

        private void LimpiarAsync()
        {
            this.Invoke(
                () =>
                {
                    Utilidades.Util.LimpiarForm(TLPForm, TxtNombre);

                });
        }

        /// <summary>
        /// Inserta un nuevo artículo en la base de datos.
        /// </summary>

        public async Task InsertarArticuloStock()
        {
            var insercionResult = await _articulosService.Add(_articuloSeleccionado);

            if (!insercionResult.IsSuccess)
                MessageBox.Show(insercionResult.Error, "Error en la inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Ingreso correcto", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Otros Metodos
    }
}