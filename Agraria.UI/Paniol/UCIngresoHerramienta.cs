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
using Agraria.Util.Validaciones;

namespace Agraria.UI.Paniol
{
	public partial class UCIngresoHerramienta : UserControl
	{
		private readonly IHerramientasService _herramientasService;
		private readonly ValidadorTextBox _vTxtNombre;
		private readonly ValidadorTextBox _vTxtCantidad;
		private readonly ValidadorTextBox _vTxtDescripcion;

		public UCIngresoHerramienta(IHerramientasService herramientasService)
		{
			InitializeComponent();
			_herramientasService = herramientasService;

			_vTxtNombre = new ValidadorNombre(TxtNombre, new ErrorProvider()) { MensajeError = "EL nombre no puede esta vacio" };
			_vTxtCantidad = new ValidadorEntero(TxtCantidad, new ErrorProvider()) { MensajeError = "La cantidad debe ser un numero mayor o igual a 0" };
			_vTxtDescripcion = new ValidadorDireccion(TxtDescripcion, new ErrorProvider()) { MensajeError = "La descripcion no puede estar vacia" };
		}



		private void BtnIngresar_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult dialogResult = MessageBox.Show("¿estas Seguro que queres ingresar la nueva herramienta?", "Ingreso a pañol", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
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

		private void TxtNombre_TextChanged(object sender, EventArgs e)
		{
			BtnIngresar.Enabled = ValidadorMultiple.ValidacionMultiple(_vTxtNombre, _vTxtCantidad, _vTxtDescripcion);
		}
	}
}
