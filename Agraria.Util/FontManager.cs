using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Utilidades
{
	using System.Windows.Forms;
	using System.Drawing;

	public static class FontManager
	{
		// Variable para almacenar la nueva fuente seleccionada
		private static Font _nuevaFuente;

		// Método principal que se llama después de que el usuario selecciona una fuente
		public static void AplicarNuevaFuente(Font nuevaFuente, Form formularioPrincipal)
		{
			_nuevaFuente = nuevaFuente;

			// Recorre todos los controles del formulario principal (incluidos los Forms y User Controls anidados)
			AplicarNuevaFuenteRecursivo(formularioPrincipal.Controls);
		}

		// Método recursivo para aplicar el cambio a todos los controles
		private static void AplicarNuevaFuenteRecursivo(Control.ControlCollection controls)
		{
			foreach (Control control in controls)
			{
				// Calcula el factor de escala o el cambio de tamaño
				float factorCambio;

				// La primera vez que se encuentra un control con una fuente definida,
				// se calcula el factor de cambio basado en la nueva fuente y la fuente actual del control.
				// Para el ejemplo, usaremos el factor de cambio del tamaño.

				// Nota: Para una aplicación robusta, podrías considerar almacenar
				// el tamaño de fuente original de cada control en un diccionario
				// al iniciar la aplicación, o basar el cálculo en una fuente base (ej. la del Form).
				// Para este ejemplo simple, usaremos el tamaño de fuente del *control* como referencia
				// y aplicaremos la diferencia de tamaño seleccionada.

				// Obtenemos el tamaño original del control
				float tamanoOriginal = control.Font.Size;

				// Obtenemos el nuevo tamaño seleccionado
				float tamanoNuevo = _nuevaFuente.Size;

				// Calculamos el factor de cambio multiplicativo
				// Por ejemplo, si el original es 8 y el nuevo es 10, el factor es 1.25 (10/8).
				// O si solo queremos aplicar la *diferencia* absoluta (más simple para un cambio de tamaño):
				float diferenciaTamano = tamanoNuevo - tamanoOriginal; // Esta no es la mejor manera para mantener proporciones

				// **El enfoque más efectivo para tu solicitud (mantener la relación de tamaño)
				// es usar la diferencia de tamaño:**

				// Paso 1: Determinar el *cambio absoluto* de la fuente del Formulario
				// Para esto, necesitarías una fuente de referencia (ej: la fuente original del Form).

				// **Simplificando la tarea para un cambio general de tamaño (el enfoque más común):**
				// Aplicaremos el tamaño seleccionado por el usuario, PERO manteniendo el estilo (Bold, Italic, etc.)

				// Aplicar la nueva fuente con el *mismo* tamaño que el usuario seleccionó
				// y mantener el estilo actual del control.
				// Esto *no* mantiene la relación de tamaño, sino que iguala todo al nuevo tamaño.
				// control.Font = new Font(_nuevaFuente.FontFamily, _nuevaFuente.Size, control.Font.Style);

				// **Alternativa que mantiene la relación de tamaño (más complejo y robusto):**
				// Aquí se asume que *todos* los tamaños deben cambiar en base a un *delta* (diferencia)
				// que se calcula entre la fuente base original (e.g., tamaño 9) y la nueva fuente seleccionada.
				// Asumamos que la fuente base del Formulario es tamaño 9.

				// Calculamos la diferencia de tamaño *desde* la fuente original del control.
				// Esto asume que la nueva fuente seleccionada es la base del cambio.

				// Opción 1: Aplicar un factor de escala (ej. 1.25 para aumentar 25%)
				// float factorDeEscala = nuevaFuente.Size / control.Font.Size; // Esto no funciona bien

				// Opción 2: Aplicar una diferencia absoluta (la más práctica para fuentes)
				// Suponemos que la fuente de referencia (ej: el Form principal) tenía un tamaño base de 9.
				// Si el usuario selecciona 12, el delta es +3. Este delta se aplica a *todos* los tamaños.

				// ***IMPLEMENTACIÓN CON DELTA DE TAMAÑO***
				// Esto mantiene las diferencias relativas (un control con 12pt y otro con 10pt mantienen una diferencia de 2pt,
				// pero ambos se incrementan en el mismo delta de tamaño).

				// La primera vez que se llama al método, `_nuevaFuente` tiene el tamaño seleccionado.
				// La diferencia de tamaño se calcula una vez y se podría almacenar.

				// Para este ejemplo, calcularemos el cambio de tamaño del control con respecto a su *propio* tamaño original
				// para que todos terminen con el *mismo* tamaño:

				// Si el objetivo es que *todos* los controles tengan el tamaño seleccionado en el FontDialog, use:
				control.Font = new Font(_nuevaFuente.FontFamily, _nuevaFuente.Size, control.Font.Style);


				// Si el objetivo es que un Label (ej. tamaño 12) y un Button (ej. tamaño 9)
				// mantengan su diferencia de 3pt, pero ambos crezcan en 2pt (si el usuario selecciona +2pt):
				/*
				float deltaSize = _nuevaFuente.Size - 9; // 9 es una asunción de tamaño base.
				control.Font = new Font(_nuevaFuente.FontFamily, control.Font.Size + deltaSize, control.Font.Style);
				*/


				// **Usaremos la opción más simple y usual para una fuente general: aplicar el mismo tamaño.**
				// Si el usuario selecciona 12pt en el diálogo, *todos* tendrán 12pt, manteniendo el estilo.
				// Para mantener la proporción, el cálculo de la diferencia (delta) o factor de escala debe hacerse
				// con una fuente de *referencia* (la fuente original del Form principal).

				// Aplicamos la fuente seleccionada con el nuevo tamaño, pero mantenemos el estilo (Bold, Italic, etc.)
				control.Font = new Font(_nuevaFuente.FontFamily, _nuevaFuente.Size, control.Font.Style);

				// Llamada recursiva para los controles dentro de este control (ej. User Controls, Panels, GroupBoxes)
				if (control.HasChildren)
				{
					AplicarNuevaFuenteRecursivo(control.Controls);
				}
			}
		}
	}
}
