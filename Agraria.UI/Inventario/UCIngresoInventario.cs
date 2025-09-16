using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Agraria.Util;
using Agraria.Util.Validaciones;
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

        private readonly IArticulosService _articulosService;
        private readonly IArticuloStockService _articuloStockService;

        private readonly ArticulosGral _articuloSeleccionado;
        private readonly Modelo.Entidades.Stock _stockSeleccionado;

        private readonly ValidadorTextBox _vTxtNombre;
        private readonly ValidadorTextBox _vTxtCantidad;
        private readonly ValidadorTextBox _vTxtPrecio;

        private readonly ErrorProvider _epTxtNombre;
        private readonly ErrorProvider _epTxtCantidad;
        private readonly ErrorProvider _epTxtPrecio;
        private readonly CultureInfo cultureArg = new("es-AR");

        #endregion Atributos y Propiedades

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCIngresoInventario"/>.
        /// </summary>
        public UCIngresoInventario(IArticulosService articulosService, IArticuloStockService articuloStockService)
        {
            _articulosService = articulosService;
            _articuloStockService = articuloStockService;

            InitializeComponent();

            _articuloSeleccionado = new ArticulosGral();
            _stockSeleccionado = new Modelo.Entidades.Stock();

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
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtNombre, _vTxtCantidad, _vTxtPrecio);
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Crea un nuevo artículo a partir de los datos introducidos por el usuario.
        /// </summary>
        /// <returns>Verdadero si el artículo se creó correctamente, falso en caso contrario.</returns>
        private bool CrearArticulo()
        {
            _articuloSeleccionado.Art_Nombre = TxtNombre.Text;
            _articuloSeleccionado.Art_Uni_Med = CMBUnidadMedida.SelectedItem?.ToString() ?? UnidadMedida.Unidad.ToString();
            _articuloSeleccionado.Art_Descripcion = TxtDescripcion.Text;

            return true;
        }

        /// <summary>
        /// Crea un nuevo registro de stock a partir de los datos introducidos por el usuario.
        /// </summary>
        private void CrearStock()
        {
            _stockSeleccionado.Cantidad = Convert.ToDouble(TxtCantidad.Text);
            _stockSeleccionado.Costo = Convert.ToDouble(TxtPrecio.Text, CultureInfo.InvariantCulture);
            _stockSeleccionado.Ganancia = 0; // No se utiliza en este contexto
        }

        /// <summary>
        /// Maneja el evento Load del UserControl.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void UCIngresoInventario_Load(object sender, EventArgs e)
        {
            var taskHelper = new TareasLargas(PanelMedio, ProgressBar, CargaInicial, CargarCMB);
            taskHelper.Iniciar();
        }

        /// <summary>
        /// Realiza la carga inicial de datos de forma asíncrona.
        /// </summary>
        private async Task CargaInicial()
        {
            // No se requiere carga inicial para este caso
            await Task.CompletedTask;
        }

        /// <summary>
        /// Carga los datos en el ComboBox de unidades de medida.
        /// </summary>
        private void CargarCMB()
        {
            CMBUnidadMedida.DataSource = Enum.GetValues(typeof(UnidadMedida)).Cast<UnidadMedida>().ToList();
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
            if (!CrearArticulo())
            {
                MessageBox.Show("Artículo no creado", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CrearStock();

            var tarea = new TareasLargas(PanelMedio, ProgressBar, InsertarArticuloStock, () => Util.Util.LimpiarForm(TLPForm, TxtNombre));
            tarea.Iniciar();
        }

        /// <summary>
        /// Inserta un nuevo artículo y su stock en la base de datos.
        /// </summary>
        public async Task InsertarArticuloStock()
        {
            // TODO: Implementar la lógica para insertar ArticulosGral en la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para ArticulosGral
            MessageBox.Show("Funcionalidad pendiente de implementación", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            /*
            var ultimoCodigoResult = await _articulosService.GetMaxCodArt();
            int codigo = ultimoCodigoResult.IsSuccess ? ultimoCodigoResult.Value : 100000;
            string nuevoCodigo = (codigo + 1).ToString();

            _articuloSeleccionado.Cod_Articulo = nuevoCodigo;
            _stockSeleccionado.Cod_Articulo = nuevoCodigo;

            var insercionResult = await _articuloStockService.Add(_articuloSeleccionado, _stockSeleccionado);

            if (!insercionResult.IsSuccess)
                MessageBox.Show(insercionResult.Error, "Error en la inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Ingreso correcto", "Artículo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }

        #endregion Otros Metodos
    }
}