using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Util
{
    /// <summary>
    /// Proporciona servicios estáticos para la gestión y visualización de ToolTips.
    /// </summary>
    public static class ServicioToolTip
    {
        /// <summary>
        /// Muestra un ToolTip temporal para el control especificado con el texto dado.
        /// El ToolTip se libera automáticamente después de ser mostrado.
        /// </summary>
        /// <param name="control">La instancia del control al que se adjuntará el ToolTip.</param>
        /// <param name="texto">El contenido del mensaje del ToolTip.</param>
        public static void Mostrar(Control control, string texto)
        {
            if (control == null)
            {
                throw new ArgumentNullException(nameof(control), "El control no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException("El texto del ToolTip no puede ser nulo o vacío.", nameof(texto));
            }

            // Crear una nueva instancia de ToolTip
            var infoAyuda = new ToolTip();
            // Establecer el texto del ToolTip
            infoAyuda.SetToolTip(control, texto);

            // Propiedades opcionales para personalizar la visualización
            infoAyuda.InitialDelay = 0; // Mostrar inmediatamente
            infoAyuda.AutoPopDelay = 5000; // Desaparecer después de 5 segundos
            infoAyuda.IsBalloon = true; // Estilo de globo más moderno
            infoAyuda.Active = true; // Activar el ToolTip
            // Mostrar el ToolTip
            //infoAyuda.Show(texto, control);
        }
    }
}
