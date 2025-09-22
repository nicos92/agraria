using Agraria.UI.Articulos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI.EntornoFormativo
{
    public partial class FormEntornoFormativo : Form
    {  // TODO: AGREGAR UN CRUD DE INVENTARIOS
        private readonly ILogger<FormEntornoFormativo> _logger;
        private Button _btnActual;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FormArticulos"/>.
        /// </summary>
        /// <param name="serviceProvider">El proveedor de servicios para la inyección de dependencias.</param>
        /// <param name="logger">El logger para registrar eventos.</param>
        public FormEntornoFormativo(IServiceProvider serviceProvider, ILogger<FormEntornoFormativo> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            InitializeComponent();
            _btnActual = BtnOpcionIngresar; // Inicializar con el botón de Ingresar

            _logger.LogInformation("FormEntornoFormativo inicializado.");
        }

        /// <summary>
        /// Selecciona y muestra un control de usuario en el panel principal.
        /// </summary>
        /// <param name="tipoForm">El tipo de control de usuario a mostrar.</param>
        private void SeleccionarUC(Type tipoForm)
        {
            if (tipoForm == null || !typeof(UserControl).IsAssignableFrom(tipoForm))
            {
                _logger.LogWarning("Tipo de formulario no válido o nulo proporcionado.");
                return;
            }

            _logger.LogInformation("Seleccionando UserControl: {TypeName}", tipoForm.Name);

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
                _logger.LogInformation("UserControl existente {TypeName} mostrado.", tipoForm.Name);
            }
            else
            {
                // Si no existe, lo creamos, lo agregamos y lo hacemos visible
                try
                {
                    UserControl nuevoUC = (UserControl)_serviceProvider.GetRequiredService(tipoForm);
                    nuevoUC.Dock = DockStyle.Fill;
                    PanelMedio.Controls.Add(nuevoUC);
                    nuevoUC.BringToFront(); // Opcional: Asegura que esté al frente
                    _logger.LogInformation("Nuevo UserControl {TypeName} creado y agregado.", tipoForm.Name);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al crear o agregar UserControl {TypeName}", tipoForm.Name);
                    throw;
                }
            }
        }

        /// <summary>
        /// Configura los tags de los botones de opción.
        /// </summary>
        private void ConFigBtns()
        {
            BtnOpcionIngresar.Tag = typeof(UCIngresoEntornoFormativo);
            BtnOpcionEditar.Tag = typeof(UCConsultaEntornoFormativo);
            BtnOpcionCategorias.Tag = typeof(UCGestionEntornos);
        }

        /// <summary>
        /// Valida el tag de un botón y muestra el control de usuario correspondiente.
        /// </summary>
        /// <param name="btn">El botón a validar.</param>
        private void ValidarTag(Button btn)
        {
            if (btn.Tag is Type type)
            {
                _logger.LogInformation("Validando tag para botón {ButtonName} con tipo {TypeName}", btn.Name, type.Name);
                SeleccionarUC(type);
            }
            else
            {
                _logger.LogWarning("Botón {ButtonName} no tiene un tag válido asignado", btn.Name);
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
            _logger.LogInformation("Botón {ButtonName} clickeado", btn.Name);
            
            if (_btnActual.Tag == btn.Tag)
            {
                _logger.LogDebug("El botón clickeado es el mismo que el actual, ignorando.");
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
        private void FormArticulos_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("FormEntornoFormativo cargado.");
            ConFigBtns();

            ValidarTag(_btnActual);
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _logger.LogInformation("FormEntornoFormativo cerrando.");
            this.Dispose();
        }
    }
}
