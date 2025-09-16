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

namespace Agraria.UI.HojadeVida
{
    public partial class UCIngresoHojadeVida : UserControl
    {
        #region Atributos y Propiedades

        //private readonly IHojadeVidaService _hojadeVidaService;

        private readonly Modelo.Entidades.HojadeVida _hojaVidaSeleccionada;

        private readonly ValidadorTextBox _vTxtCodigo;
        private readonly ValidadorTextBox _vTxtPeso;
        private readonly ValidadorTextBox _vTxtEstadoSalud;

        private readonly ErrorProvider _epTxtCodigo;
        private readonly ErrorProvider _epTxtPeso;
        private readonly ErrorProvider _epTxtEstadoSalud;
        private readonly CultureInfo cultureArg = new("es-AR");

        #endregion Atributos y Propiedades

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCIngresoHojadeVida"/>.
        /// </summary>
        public UCIngresoHojadeVida()
        {
            //_hojadeVidaService = hojadeVidaService;

            InitializeComponent();

            _hojaVidaSeleccionada = new Modelo.Entidades.HojadeVida();

            _epTxtCodigo = new ErrorProvider();
            _vTxtCodigo = new ValidadorEntero(TxtCodigo, _epTxtCodigo) { MensajeError = "El código debe ser un número válido" };

            _epTxtPeso = new ErrorProvider();
            _vTxtPeso = new ValidadorNumeroDecimal(TxtPeso, _epTxtPeso) { MensajeError = "El peso debe ser un número válido" };

            _epTxtEstadoSalud = new ErrorProvider();
            _vTxtEstadoSalud = new ValidadorDireccion(TxtEstadoSalud, _epTxtEstadoSalud) { MensajeError = "El estado de salud no puede estar vacío" };
        }

        #region Eventos

        /// <summary>
        /// Controla el evento TextChanged de los cuadros de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {
            ValidadorMultiple.ValidacionMultiple([BtnIngresar], _vTxtCodigo, _vTxtPeso, _vTxtEstadoSalud);
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Crea una nueva hoja de vida a partir de los datos introducidos por el usuario.
        /// </summary>
        /// <returns>Verdadero si la hoja de vida se creó correctamente, falso en caso contrario.</returns>
        private bool CrearHojadeVida()
        {
            _hojaVidaSeleccionada.Codigo = Convert.ToInt32(TxtCodigo.Text);
            _hojaVidaSeleccionada.TipoAnimal = (TipoAnimal)CMBTipoAnimal.SelectedItem;
            _hojaVidaSeleccionada.Sexo = (Sexo)CMBSexo.SelectedItem;
            _hojaVidaSeleccionada.FechaNacimiento = DTPFechaNacimiento.Value;
            _hojaVidaSeleccionada.Peso = Convert.ToDecimal(TxtPeso.Text);
            _hojaVidaSeleccionada.EstadoSalud = TxtEstadoSalud.Text;
            _hojaVidaSeleccionada.Observaciones = TxtObservaciones.Text;

            return true;
        }

        /// <summary>
        /// Maneja el evento Load del UserControl.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">El <see cref="EventArgs"/> instancia que contiene los datos del evento.</param>
        private void UCIngresoHojadeVida_Load(object sender, EventArgs e)
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
        /// Carga los datos en los ComboBoxes.
        /// </summary>
        private void CargarCMB()
        {
            // Cargar tipos de animal
            CMBTipoAnimal.DataSource = Enum.GetValues(typeof(TipoAnimal)).Cast<TipoAnimal>().ToList();

            // Cargar sexos
            CMBSexo.DataSource = Enum.GetValues(typeof(Sexo)).Cast<Sexo>().ToList();
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
            if (!CrearHojadeVida())
            {
                MessageBox.Show("Hoja de vida no creada", "Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tarea = new TareasLargas(PanelMedio, ProgressBar, InsertarHojadeVida, () => Util.Util.LimpiarForm(TLPForm, TxtCodigo));
            tarea.Iniciar();
        }

        /// <summary>
        /// Inserta una nueva hoja de vida en la base de datos.
        /// </summary>
        public async Task InsertarHojadeVida()
        {
            // TODO: Implementar la lógica para insertar HojadeVida en la base de datos
            // Esta implementación es un placeholder ya que no hay un servicio específico para HojadeVida
            MessageBox.Show("Funcionalidad pendiente de implementación", "Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*
            var insercionResult = await _hojadeVidaService.Add(_hojaVidaSeleccionada);

            if (!insercionResult.IsSuccess)
                MessageBox.Show(insercionResult.Error, "Error en la inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Ingreso correcto", "Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }

        #endregion Otros Metodos
    }
}