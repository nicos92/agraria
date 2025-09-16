using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.UI.Actividad;
using Agraria.Util;
using Microsoft.Extensions.DependencyInjection;

namespace Agraria.UI
{
    public partial class FormPrincipal : Form
    {
        private IServiceProvider _serviceProvider;

        private Button _btnActivo;

        /// <summary>
        /// Inicializa una nueva instancia del formulario principal.
        /// </summary>
        /// <param name="serviceProvider">El proveedor de servicios para la inyección de dependencias.</param>
        public FormPrincipal(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            _btnActivo = BtnActividad;
        }

        /// <summary>
        /// Maneja el evento de clic de los botones del menú para abrir el formulario correspondiente.
        /// </summary>
        /// <param name="sender">El objeto que originó el evento (se espera que sea un botón).</param>
        /// <param name="e">Los datos del evento.</param>
        private void BtnActividad_Click(object sender, EventArgs e)
        {
            // Usamos el operador 'is' con patrón para verificar si el 'sender' es un botón
            if (sender is Button btn)
            {
                // El 'campo' _btnActivo debe ser 'null' en la primera ejecución
                // Esto previene que intente cambiar el color de un botón que no existe
                if (_btnActivo != null)
                {
                    ResetearEstiloBoton(_btnActivo);
                }

                // Aplicar el estilo al botón que se acaba de presionar
                AplicarEstiloActivo(btn);

                // Actualizar la referencia del botón activo
                _btnActivo = btn;

                // Comprobar si el 'Tag' del botón es del tipo 'Type'
                if (btn.Tag is Type tipoForm)
                {
                    // Seleccionar y mostrar el formulario
                    SeleccionarForm(tipoForm);

                    // Actualizar el título de la ventana de forma segura
                    this.Text = $"Escuela Agraria - {btn.Text}";
                }
            }
        }

        /// <summary>
        /// Restablece el estilo visual de un botón a su estado predeterminado.
        /// </summary>
        /// <param name="btn">El botón cuyo estilo se va a restablecer.</param>
        private static void ResetearEstiloBoton(Button btn)
        {
            btn.BackColor = AppColorPalette.Light.Primary;
            btn.ForeColor = AppColorPalette.Light.OnPrimary;
            btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        /// <summary>
        /// Aplica el estilo visual de "activo" a un botón.
        /// </summary>
        /// <param name="btn">El botón al que se le aplicará el estilo.</param>
        private static void AplicarEstiloActivo(Button btn)
        {
            btn.BackColor = AppColorPalette.Light.OnPrimaryContainer;
            btn.ForeColor = AppColorPalette.Light.PrimaryContainer;
            btn.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }


        /// <summary>
        /// Gestiona la visualización de formularios secundarios dentro del contenedor MDI.
        /// Si un formulario del tipo especificado ya existe, lo muestra. De lo contrario, crea una nueva instancia.
        /// </summary>
        /// <param name="tipoForm">El tipo (Type) del formulario que se debe mostrar.</param>
        private void SeleccionarForm(Type tipoForm)
        {
            // 1. Validar el tipo de formulario antes de cualquier operación
            if (tipoForm == null || !typeof(Form).IsAssignableFrom(tipoForm))
            {
                // Puedes agregar un log aquí o simplemente salir
                return;
            }

            // 2. Optimizar el cierre de formularios
            // Utilizar una versión moderna del bucle para mejor legibilidad
            foreach (var childForm in MdiChildren)
            {
                // 3. Ocultar en lugar de cerrar para reutilizar formularios
                if (childForm.GetType() == tipoForm)
                {
                    // Si el formulario ya está abierto, solo lo mostramos y terminamos
                    childForm.Show();
                    return;
                }
                else
                {
                    // Ocultamos los demás
                    childForm.Hide();
                }
            }
            // 4. Crear el formulario si no estaba abierto
            // Usar 'var' para inferencia de tipo hace el código más limpio

            // 5. Configurar el nuevo formulario
            if (_serviceProvider.GetRequiredService(tipoForm) is Form form)
            {
                form.MdiParent = this;
                form.FormBorderStyle = FormBorderStyle.None; // Asegura que no se muestre la barra de títulos del formulario
                form.Dock = DockStyle.Fill; // Establece el formulario en lleno
                form.Show();
            }


        }

        /// <summary>
        /// Maneja el evento de carga del formulario principal.
        /// </summary>
        /// <param name="sender">El objeto que originó el evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ConfigBtnsMenu();
            BtnActividad_Click(_btnActivo, e);
        }

        /// <summary>
        /// Configura la propiedad 'Tag' de cada botón del menú con el tipo de formulario que debe abrir.
        /// </summary>
        private void ConfigBtnsMenu()
        {
            BtnActividad.Tag = typeof(Actividad.FormActividad);
            BtnAnimal.Tag = typeof(Articulos.FormArticulos);
            BtnVegetal.Tag = typeof(HojadeVida.FormHojadeVida);
            BtnIndustrial.Tag = typeof(Inventario.FormInventario);
            BtnVenta.Tag = typeof(Venta.FormVenta);
            BtnReporte.Tag = typeof(Reporte.FormReporte);
            BtnUsuarios.Tag = typeof(Usuarios.FormUsuarios);
            BtnProveedores.Tag = typeof(Proveedores.FormProveedores);
        }
    }
}
