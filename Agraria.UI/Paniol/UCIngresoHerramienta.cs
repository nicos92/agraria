using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Serilog;

namespace Agraria.UI.Paniol
{
    public partial class UCIngresoHerramienta : UserControl
    {
        private readonly IHerramientasService _herramientasService;
        
        public UCIngresoHerramienta(IHerramientasService herramientasService)
        {
            InitializeComponent();
            _herramientasService = herramientasService;
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            TxtNombre.TextChanged += ValidarCampos;
            TxtCantidad.TextChanged += ValidarCampos;
            BtnIngresar.Click += BtnIngresar_Click;
        }

        private void ValidarCampos(object sender, EventArgs e)
        {
            bool nombreValido = !string.IsNullOrWhiteSpace(TxtNombre.Text);
            bool cantidadValida = int.TryParse(TxtCantidad.Text, out int cantidad) && cantidad >= 0;

            BtnIngresar.Enabled = nombreValido && cantidadValida;
        }

        private async void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressBar.Visible = true;
                BtnIngresar.Enabled = false;

                var herramienta = new Herramientas
                {
                    Nombre = TxtNombre.Text.Trim(),
                    Descripcion = TxtDescripcion.Text.Trim(),
                    Cantidad = int.Parse(TxtCantidad.Text)
                };

                var resultado = _herramientasService.Add(herramienta);

                if (resultado.IsSuccess)
                {
                    MessageBox.Show("Herramienta ingresada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show($"Error al ingresar la herramienta: {resultado.Error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.Error("Error al ingresar herramienta: {Error}", resultado.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Error inesperado al ingresar herramienta");
            }
            finally
            {
                ProgressBar.Visible = false;
                BtnIngresar.Enabled = true;
            }
        }

        private void LimpiarCampos()
        {
            TxtNombre.Clear();
            TxtDescripcion.Clear();
            TxtCantidad.Clear();
        }
    }
}
