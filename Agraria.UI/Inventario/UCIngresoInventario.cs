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
        public UCIngresoInventario( )
        {
           

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
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Crea un nuevo artículo a partir de los datos introducidos por el usuario.
        /// </summary>
        /// <returns>Verdadero si el artículo se creó correctamente, falso en caso contrario.</returns>
        private bool CrearArticulo()
        {
            

           return true;
        }


        /// <summary>
        /// Maneja el evento Load del UserControl.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void UCIngresoInventario_Load(object sender, EventArgs e)
        {
            
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
            
        }

        /// <summary>
        /// Inserta un nuevo artículo en la base de datos.
        /// </summary>
        public async Task InsertarArticuloStock()
        {
            
        }

        #endregion Otros Metodos
    }
}