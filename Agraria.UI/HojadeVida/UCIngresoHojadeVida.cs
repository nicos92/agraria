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

namespace Agraria.UI.HojadeVida
{
    public partial class UCIngresoHojadeVida : UserControl
    {
        #region Atributos y Propiedades

        private readonly IHojadeVidaService _hojadeVidaService;

        private readonly Modelo.Entidades.HojadeVida _hojaVidaSeleccionada;

        private readonly ValidadorTextBox _vTxtNombre;
        private readonly ValidadorTextBox _vTxtPeso;
        private readonly ValidadorTextBox _vTxtEstadoSalud;

        private readonly ErrorProvider _epTxtCodigo;
        private readonly ErrorProvider _epTxtPeso;
        private readonly ErrorProvider _epTxtEstadoSalud;

        #endregion Atributos y Propiedades

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UCIngresoHojadeVida"/>.
        /// </summary>
        public UCIngresoHojadeVida(IHojadeVidaService hojadeVidaService)
        {
            _hojadeVidaService = hojadeVidaService;

            InitializeComponent();

            _hojaVidaSeleccionada = new Modelo.Entidades.HojadeVida();

            _epTxtCodigo = new ErrorProvider();
            _vTxtNombre = new ValidadorNombre(TxtNombre, _epTxtCodigo);
            _vTxtNombre.MensajeError = "El nombre debe contener solo letras y espacios, y no puede estar vacío.";

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
            ValidadorMultiple.ValidacionMultiple(BtnIngresar, _vTxtNombre, _vTxtPeso, _vTxtEstadoSalud);
        }

        #endregion Eventos

        #region Métodos Privados

        /// <summary>
        /// Crea una nueva hoja de vida a partir de los datos introducidos por el usuario.
        /// </summary>
        /// <returns>Verdadero si la hoja de vida se creó correctamente, falso en caso contrario.</returns>
        private bool CrearHojadeVida()
        {
            if (CMBTipoAnimal.SelectedValue is TipoAnimal tipoAnimal1 && CMBSexo.SelectedValue is Sexo sexo)
            {

            _hojaVidaSeleccionada.Numero = Convert.ToInt32(TxtNombre.Text);
            _hojaVidaSeleccionada.TipoAnimal = tipoAnimal1;
            _hojaVidaSeleccionada.Sexo = sexo;
            _hojaVidaSeleccionada.FechaNacimiento = DTPFechaNacimiento.Value;
            _hojaVidaSeleccionada.Peso = DecimalFormatter.ParseDecimal(TxtPeso.Text);
            _hojaVidaSeleccionada.EstadoSalud = TxtEstadoSalud.Text;
            _hojaVidaSeleccionada.Observaciones = TxtObservaciones.Text;
            _hojaVidaSeleccionada.Activo = ChkActivo.Checked;
                return true;
            }

            return false;
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
        private static async Task CargaInicial()
        {
            // No se requiere carga inicial para este caso
            await Task.CompletedTask;
        }

        /// <summary>
        /// Carga los datos en los ComboBoxes.
        /// </summary>
        private void CargarCMB()
        {
            this.Invoke(
                () =>
                {
                    // Cargar tipos de animal
                    CMBTipoAnimal.DataSource = Enum.GetValues<TipoAnimal>()
                                           .Select(e => new { Value = e, Display = e.ToString() })
                                           .ToList();
                    CMBTipoAnimal.ValueMember = "Value";
                    CMBTipoAnimal.DisplayMember = "Display";

                    // Cargar sexos
                    CMBSexo.DataSource = Enum.GetValues<Sexo>()
                                       .Select(e => new { Value = e, Display = e.ToString() })
                                       .ToList();
                    CMBSexo.ValueMember = "Value";
                    CMBSexo.DisplayMember = "Display";
                });

           
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
            DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea ingresar esta hoja de vida?", "Confirmar Ingreso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                return; // El usuario canceló la acción
            }
            if (!CrearHojadeVida())
            {
                MessageBox.Show("Hoja de vida no creada", "Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tarea = new TareasLargas(PanelMedio, ProgressBar, InsertarHojadeVida, LimpiarForm);
            tarea.Iniciar();
        }

        private void LimpiarForm()
        {
            this.Invoke(
                () =>
                {
                    Utilidades.Util.LimpiarForm(TLPForm, TxtNombre);
                });
        }

        /// <summary>
        /// Inserta una nueva hoja de vida en la base de datos.
        /// </summary>
        public async Task InsertarHojadeVida()
        {
            var insercionResult = await _hojadeVidaService.Add(_hojaVidaSeleccionada);

            if (!insercionResult.IsSuccess)
                MessageBox.Show(insercionResult.Error, "Error en la inserción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Ingreso correcto", "Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Otros Metodos
    }
}