using Microsoft.Extensions.DependencyInjection;
using Agraria.UI.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.HojadeVida
{
    public partial class FormHojadeVida : Form
    {
        private Button _btnActual;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormHojadeVida"/>.
        /// </summary>
        /// <param name="serviceProvider">El proveedor de servicios para la inyección de dependencias.</param>
        public FormHojadeVida(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            _btnActual = BtnOpcionIngresar; // Inicializar con el botón de Ingresar

        }

        /// <summary>
        /// Selecciona y muestra un control de usuario en el panel principal.
        /// </summary>
        /// <param name="tipoForm">El tipo de control de usuario a mostrar.</param>
        private void SeleccionarUC(Type tipoForm)
        {
            if (tipoForm == null || !typeof(UserControl).IsAssignableFrom(tipoForm))
            {
                return;
            }

            // Ocultar todos los UserControl existentes
            foreach (Control control in PanelMedio.Controls)
            {
                if (control is UserControl uc)
                {
                    uc.Visible = false;
                }
            }

            // Buscar si el UserControl ya existe en el panel
            UserControl? ucExistente = PanelMedio.Controls.OfType<UserControl>().FirstOrDefault(uc => uc.GetType() == tipoForm);

            if (ucExistente != null)
            {
                // Si el UserControl ya existe, simplemente lo hacemos visible
                ucExistente.Visible = true;
                ucExistente.BringToFront(); // Opcional: Asegura que esté al frente
            }
            else
            {
                // Si no existe, lo creamos, lo agregamos y lo hacemos visible
                UserControl nuevoUC = (UserControl)_serviceProvider.GetRequiredService(tipoForm);
                nuevoUC.Dock = DockStyle.Fill;
                PanelMedio.Controls.Add(nuevoUC);
                nuevoUC.BringToFront(); // Opcional: Asegura que esté al frente
            }
        }

        /// <summary>
        /// Configura los tags de los botones de opción.
        /// </summary>
        private void ConFigBtns()
        {
            BtnOpcionIngresar.Tag = typeof(UCIngresoHojadeVida);
            BtnOpcionEditar.Tag = typeof(UCConsultaHojadeVida);
        }

        /// <summary>
        /// Valida el tag de un botón y muestra el control de usuario correspondiente.
        /// </summary>
        /// <param name="btn">El botón a validar.</param>
        private void ValidarTag(Button btn)
        {
            if (btn.Tag is Type type)
            {
                SeleccionarUC(type);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón de opción de ingresar.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnOpcionIngresar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (_btnActual.Tag == btn.Tag)
            {
                return;
            }

            Utilidades.Util.CambioColorBtnsUC(_btnActual, btn);


            ValidarTag(btn);
            _btnActual = btn;
        }

        /// <summary>
        /// Maneja el evento de carga del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormHojadeVida_Load(object sender, EventArgs e)
        {
            ConFigBtns();

            ValidarTag(_btnActual);
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormHojadeVida_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}