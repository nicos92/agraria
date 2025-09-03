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
        private Form _formactividad;    
        public FormPrincipal(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            _btnActivo = BtnActividad;
        }

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

        // Método para restablecer el estilo de un botón
        private void ResetearEstiloBoton(Button btn)
        {
            btn.BackColor = AppColorPalette.Light.Primary;
            btn.ForeColor = AppColorPalette.Light.OnPrimary;
            btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        // Método para aplicar el estilo de botón activo
        private void AplicarEstiloActivo(Button btn)
        {
            btn.BackColor = AppColorPalette.Light.OnPrimaryContainer;
            btn.ForeColor = AppColorPalette.Light.PrimaryContainer;
            btn.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        }


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
            // Usar 'var' para inferencia de tipo, hace el código más limpio
            var form = (Form)_serviceProvider.GetRequiredService(tipoForm);

            // 5. Configurar el nuevo formulario
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            ConfigBtnsMenu();
            BtnActividad_Click(_btnActivo, e);
        }

        private void ConfigBtnsMenu()
        {
            BtnActividad.Tag = typeof(Actividad.FormActividad);
            BtnAnimal.Tag = typeof(Animal.FormAnimal);
            BtnVegetal.Tag = typeof(Vegetal.FormVegetal);
            BtnIndustrial.Tag = typeof(Industrial.FormIndustrial);
            BtnVenta.Tag = typeof(Venta.FormVenta);
            BtnReporte.Tag = typeof(Reporte.FormReporte);
            BtnUsuarios.Tag = typeof(Usuarios.FormUsuarios);
            BtnProveedores.Tag = typeof(Proveedores.FormProveedores);
        }
    }
}
