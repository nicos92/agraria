using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util.Validaciones;
using Agraria.Utilidades;

namespace Agraria.UI.Proveedores
{
	public partial class UCConsultaProveedor : UserControl
	{

		private readonly IProveedoresService _proveedoresService;
		private Modelo.Entidades.Proveedores _proveedorSeleccionado;
		private List<Modelo.Entidades.Proveedores> _todosLosProveedores;
		private int indiceSeleccionado;

		private readonly ValidadorTextBox _vTxtCuit;
		private readonly ValidadorTextBox _vTxtProveedor;
		private readonly ValidadorTextBox _vTxtNombre;
		private readonly ValidadorTextBox _vTxtTel;
		private readonly ValidadorTextBox _vTxtEmail;
		private readonly ErrorProvider _epCuit;
		private readonly ErrorProvider _epProveedor;
		private readonly ErrorProvider _epNombre;
		private readonly ErrorProvider _epTel;
		private readonly ErrorProvider _epEmail;
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UCConsultaProveedor"/>.
		/// </summary>
		/// <param name="proveedoresService">El servicio de proveedores.</param>
		public UCConsultaProveedor(IProveedoresService proveedoresService)
		{
			_proveedoresService = proveedoresService;
			indiceSeleccionado = 0;
			_proveedorSeleccionado = new Modelo.Entidades.Proveedores();
			InitializeComponent();
			_epCuit = new ErrorProvider();
			_vTxtCuit = new ValidadorCUIT(TxtCuit, _epCuit)
			{
				MensajeError = "El CUIT ingresado no es válido.\nIngrese 11 digitos (12345678901).\nSino tiene CUIT ingrese cero (0)"
			};

			_epProveedor = new ErrorProvider();
			_vTxtProveedor = new ValidadorDireccion(TxtProveedor, _epProveedor)
			{
				MensajeError = "El nombre del proveedor no puede estar vacío."
			};

			_epNombre = new ErrorProvider();
			_vTxtNombre = new ValidadorNombre(TxtNombre, _epNombre)
			{
				MensajeError = "El nombre no puede estar vacío."
			};

			_epTel = new ErrorProvider();
			_vTxtTel = new ValidadorEntero(TxtTel, _epTel)
			{
				MensajeError = "El teléfono ingresado no es válido.\nSino tiene telefono ingrese cero (0)"
			};

			_epEmail = new ErrorProvider();
			_vTxtEmail = new ValidadorEmail(TxtEmail, _epEmail)
			{
				MensajeError = "El email ingresado no es válido."
			};
		}



		/// <summary>
		/// Maneja el evento de carga del control de usuario.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private async void UCConsultaProveedor_Load(object sender, EventArgs e)
		{
			await CargarProveedores();
			ConfigBtns();
			Utilidades.Util.BloquearBtns(ListBProveedores, TLPForm);
			Utilidades.Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores");


			TxtCuit.Focus();

		}

		/// <summary>
		/// Carga la lista de proveedores en el DataGridView.
		/// </summary>
		private async Task CargarProveedores()
		{
			var datos = await _proveedoresService.GetAll();

			if (datos.IsSuccess)
			{
				_todosLosProveedores = datos.Value.OrderBy(p => p.Proveedor).ToList();

				ListBProveedores.AutoGenerateColumns = false;
				ListBProveedores.DataSource = _todosLosProveedores;

			}
			else
			{
				MessageBox.Show(datos.Error, "Error en UI", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}





		/// <summary>
		/// Maneja el evento de clic en el botón Guardar.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private async void BtnGuardar_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea guardar los cambios?", "Confirmación de guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return; // Salir si el usuario no confirma
			}
			CrearProveedor();
			await GuardarProveedor();

		}

		/// <summary>
		/// Guarda los cambios del proveedor seleccionado.
		/// </summary>
		private async Task GuardarProveedor()
		{
			if (_proveedorSeleccionado != null && !string.IsNullOrEmpty(_proveedorSeleccionado.CUIT))
			{



				Result<Modelo.Entidades.Proveedores> resultado = _proveedoresService.Update(_proveedorSeleccionado);

				if (resultado.IsSuccess)
				{
					MessageBox.Show("Proveedor actualizado correctamente.\n" + resultado.Value.ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
					string valor = _proveedorSeleccionado.CUIT;
					await CargarProveedores();

					Utilidades.Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores");
					Utilidades.Util.SeleccionarFilaDGV(ListBProveedores, valor, ListBProveedores.Columns[0].HeaderText, ref indiceSeleccionado);
					CargarSeleccionado();



				}
				else
				{
					MessageBox.Show(resultado.Error, "Error al actualizar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		/// Carga los datos del proveedor seleccionado en los controles del formulario.
		/// </summary>
		private void CargarSeleccionado()
		{
			if (ListBProveedores.Rows[indiceSeleccionado].DataBoundItem is Modelo.Entidades.Proveedores proveedor)
			{
				_proveedorSeleccionado = proveedor;
				TxtCuit.Text = _proveedorSeleccionado.CUIT ?? string.Empty;
				TxtProveedor.Text = _proveedorSeleccionado.Proveedor ?? string.Empty;
				TxtNombre.Text = _proveedorSeleccionado.Nombre ?? string.Empty;
				TxtTel.Text = _proveedorSeleccionado.Tel ?? string.Empty;
				TxtEmail.Text = _proveedorSeleccionado.Email ?? string.Empty;
				TxtObservacion.Text = _proveedorSeleccionado.Observacion ?? string.Empty;
			}
			else
			{
				TxtCuit.Clear();
				TxtProveedor.Clear();
				TxtNombre.Clear();
				TxtTel.Clear();
				TxtEmail.Clear();
			}
		}

		/// <summary>
		/// Crea un objeto de proveedor a partir de los datos del formulario.
		/// </summary>
		private void CrearProveedor()
		{


			_proveedorSeleccionado.CUIT = TxtCuit.Text;
			_proveedorSeleccionado.Proveedor = TxtProveedor.Text;
			_proveedorSeleccionado.Nombre = TxtNombre.Text;
			_proveedorSeleccionado.Tel = TxtTel.Text;
			_proveedorSeleccionado.Email = TxtEmail.Text;
			_proveedorSeleccionado.Observacion = TxtObservacion.Text;

		}



		/// <summary>
		/// Maneja el evento de clic en el botón Eliminar.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private async void BtnEliminar_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?", "Confirmación de eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult != DialogResult.Yes)
			{
				return; // Salir si el usuario no confirma
			}
			CrearProveedor();
			await EliminarProveedor();
		}

		/// <summary>
		/// Elimina el proveedor seleccionado.
		/// </summary>
		private async Task EliminarProveedor()
		{

			var resultado = _proveedoresService.Delete(_proveedorSeleccionado.Id_Proveedor);
			if (resultado.IsSuccess)
			{
				MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

				await CargarProveedores();
				if (Utilidades.Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores"))
				{
					Utilidades.Util.LimpiarForm(TLPForm, TxtCuit);
					Utilidades.Util.BloquearBtns(ListBProveedores, TLPForm);
				}



			}
			else
			{
				MessageBox.Show(resultado.Error, "Error al eliminar proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		/// <summary>
		/// Maneja el evento de cambio de texto en el cuadro de texto de CUIT.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void TxtCuit_TextChanged(object sender, EventArgs e)
		{
			BtnGuardar.Enabled = ValidadorMultiple.ValidacionMultiple(_vTxtCuit, _vTxtProveedor, _vTxtNombre, _vTxtTel, _vTxtEmail);
		}

		/// <summary>
		/// Maneja el evento de cambio de selección en la lista de proveedores.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void ListBProveedores_SelectionChanged(object sender, EventArgs e)
		{
			indiceSeleccionado = ListBProveedores.CurrentRow?.Index ?? -1;
			CargarSeleccionado();
		}

		/// <summary>
		/// Maneja el evento de cambio de estado de habilitación del botón Guardar.
		/// </summary>
		/// <param name="sender">El objeto que generó el evento.</param>
		/// <param name="e">Los datos del evento.</param>
		private void BtnGuardar_EnabledChanged(object sender, EventArgs e)
		{
			if (sender is Button btn && btn.Tag is Color color)
			{

				btn.BackColor = btn.Enabled ? color : AppColorsBlue.Secondary;

			}
		}

		/// <summary>
		/// Configura los botones del formulario.
		/// </summary>
		private void ConfigBtns()
		{
			BtnGuardar.Tag = AppColorsBlue.Tertiary;
			BtnEliminar.Tag = AppColorsBlue.Error;
		}

		/// <summary>
		/// Handles the Click event of the BtnAplicarFiltro control to apply filters to the provider list.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void BtnAplicarFiltro_Click(object sender, EventArgs e)
		{
			FiltrarProveedores();
		}

		/// <summary>
		/// Handles the Click event of the BtnLimpiarFiltro control to clear all filters.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void BtnLimpiarFiltro_Click(object sender, EventArgs e)
		{
			LimpiarFiltros();
		}

		/// <summary>
		/// Filters the providers based on the values in the filter controls.
		/// </summary>
		private void FiltrarProveedores()
		{
			if (_todosLosProveedores == null) return;

			var proveedoresFiltrados = _todosLosProveedores.AsEnumerable();

			// Filter by CUIT
			if (!string.IsNullOrWhiteSpace(TxtFiltroCUIT.Text))
			{
				proveedoresFiltrados = proveedoresFiltrados.Where(p => p.CUIT != null && p.CUIT.Contains(TxtFiltroCUIT.Text, StringComparison.OrdinalIgnoreCase));
			}

			// Filter by Proveedor
			if (!string.IsNullOrWhiteSpace(TxtFiltroProveedor.Text))
			{
				proveedoresFiltrados = proveedoresFiltrados.Where(p => p.Proveedor != null && p.Proveedor.Contains(TxtFiltroProveedor.Text, StringComparison.OrdinalIgnoreCase));
			}

			// Filter by Name
			if (!string.IsNullOrWhiteSpace(TxtFiltroNombre.Text))
			{
				proveedoresFiltrados = proveedoresFiltrados.Where(p => p.Nombre != null && p.Nombre.Contains(TxtFiltroNombre.Text, StringComparison.OrdinalIgnoreCase));
			}

			// Filter by Phone
			if (!string.IsNullOrWhiteSpace(TxtFiltroTelefono.Text))
			{
				proveedoresFiltrados = proveedoresFiltrados.Where(p => p.Tel != null && p.Tel.Contains(TxtFiltroTelefono.Text, StringComparison.OrdinalIgnoreCase));
			}

			// Update the DataGridView with filtered results
			ListBProveedores.DataSource = proveedoresFiltrados.ToList();
			Utilidades.Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores");
		}

		/// <summary>
		/// Clears all filter controls and shows all providers.
		/// </summary>
		private void LimpiarFiltros()
		{
			TxtFiltroCUIT.Clear();
			TxtFiltroProveedor.Clear();
			TxtFiltroNombre.Clear();
			TxtFiltroTelefono.Clear();

			// Show all providers after clearing filters
			ListBProveedores.DataSource = _todosLosProveedores;
			Utilidades.Util.CalcularDGVVacio(ListBProveedores, LblLista, "Proveedores");
		}
	}
}
