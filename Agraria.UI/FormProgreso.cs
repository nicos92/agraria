using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.UI
{
    public partial class FormProgreso: Form
    {
        public FormProgreso()
        {
            InitializeComponent();
        }
		/// <summary>
		/// Actualiza el progreso de la operación
		/// </summary>
		/// <param name="porcentaje">Porcentaje completado (0-100)</param>
		public void ActualizarProgreso(int porcentaje)
		{
			if (InvokeRequired)
			{
				// Si se llama desde otro thread, invoca en el thread de UI
				Invoke(new Action<int>(ActualizarProgreso), porcentaje);
				return;
			}

			// Validar que el porcentaje esté en el rango correcto
			porcentaje = Math.Max(0, Math.Min(100, porcentaje));

			// Actualizar el ProgressBar
			progressBar.Value = porcentaje;

			// Actualizar el texto del porcentaje
			lblPorcentaje.Text = $"{porcentaje}% completado";

			// Forzar actualización visual
			this.Refresh();
			Application.DoEvents();
		}

		/// <summary>
		/// Actualiza el mensaje mostrado en el formulario
		/// </summary>
		/// <param name="mensaje">Nuevo mensaje a mostrar</param>
		public void ActualizarMensaje(string mensaje)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(ActualizarMensaje), mensaje);
				return;
			}

			lblMensaje.Text = mensaje;
			this.Refresh();
		}

		/// <summary>
		/// Establece el progreso como indeterminado (animación continua)
		/// </summary>
		public void EstablecerProgresoIndeterminado()
		{
			if (InvokeRequired)
			{
				Invoke(new Action(EstablecerProgresoIndeterminado));
				return;
			}

			progressBar.Style = ProgressBarStyle.Marquee;
			progressBar.MarqueeAnimationSpeed = 30;
		}

		/// <summary>
		/// Establece el progreso como determinado (con porcentaje)
		/// </summary>
		public void EstablecerProgresoDeterminado()
		{
			if (InvokeRequired)
			{
				Invoke(new Action(EstablecerProgresoDeterminado));
				return;
			}

			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.MarqueeAnimationSpeed = 0;
		}

		/// <summary>
		/// Completa el progreso y cierra el formulario después de un breve delay
		/// </summary>
		public async void CompletarYCerrar(int delayMilisegundos = 500)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<int>(CompletarYCerrar), delayMilisegundos);
				return;
			}

			ActualizarProgreso(100);
			ActualizarMensaje("Respaldo completado exitosamente");

			await System.Threading.Tasks.Task.Delay(delayMilisegundos);

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
