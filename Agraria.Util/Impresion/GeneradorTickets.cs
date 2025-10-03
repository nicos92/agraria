using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Agraria.Utilidades.Impresion
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class GeneradorTickets
    {
        private readonly string plantillaHtml;

        public GeneradorTickets(string rutaPlantilla)
        {
            // Carga la plantilla HTML desde el archivo en el constructor
            try
            {
                plantillaHtml = File.ReadAllText(rutaPlantilla);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer la plantilla HTML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                plantillaHtml = string.Empty; // Asegura que la plantilla no sea nula
            }
        }

        public string GenerarHtmlTicket(string montoTotal, string motivo, string numeroOperacion, List<ProductoVenta> productos, string fechaOperacion, string titulo)
        {
            if (string.IsNullOrEmpty(plantillaHtml))
            {
                return "Error: La plantilla HTML no se pudo cargar.";
            }

            // 1. Reemplazar los valores simples
            string htmlProcesado = plantillaHtml;
            htmlProcesado = htmlProcesado.Replace("{{titulo_operacion}}", titulo);
            htmlProcesado = htmlProcesado.Replace("{{fecha_hora}}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            htmlProcesado = htmlProcesado.Replace("{{monto_total}}", montoTotal);
            htmlProcesado = htmlProcesado.Replace("{{motivo}}", motivo);
            htmlProcesado = htmlProcesado.Replace("{{numero_operacion}}", numeroOperacion);
            htmlProcesado = htmlProcesado.Replace("{{fecha_operacion}}", fechaOperacion);

            // 2. Construir las filas de la tabla para los productos
            var filasHtml = new StringBuilder();
            foreach (var producto in productos)
            {
                filasHtml.Append("<tr style=' padding: 2px 0px;  margin-top: 4px;'>");
                filasHtml.Append($"<td style='font-size: 14px; padding: 2px 0px;   margin-top:4px; text-align: left;' data-label='Producto'>{producto.Nombre}</td>");
                filasHtml.Append($"<td style='font-size: 14px; padding: 2px 0px;  margin-top:4px; text-align: right;' data-label='Cantidad'>{producto.Cantidad}</td>");
                filasHtml.Append($"<td style='font-size: 14px; padding: 2px 0px;  margin-top:4px; text-align: right;' data-label='Precio'>${producto.Precio:N2}</td>");
                filasHtml.Append($"<td style='font-size: 14px; padding: 2px 0px;  margin-top:4px; text-align: right;' data-label='Subtotal'>${producto.Subtotal:N2}</td>");
                filasHtml.Append($"<td style='font-size: 14px; padding: 2px 0px;  margin-top:4px; text-align: right;' data-label='IVA'>${producto.IVA:N2}</td>");
                filasHtml.Append($"<td style='font-size: 14px; padding: 2px 0px;  margin-top:4px; text-align: right;' data-label='Descuento'>${producto.Descuento:N2}</td>");
                filasHtml.Append($"<td style='font-size: 14px; padding: 2px 0px;  margin-top:4px; text-align: right;' data-label='Total'>${producto.Total:N2}</td>");
                filasHtml.Append("</tr>");
            }

            // 3. Reemplazar el marcador de la tabla con las filas generadas
            htmlProcesado = htmlProcesado.Replace("{{tabla_items}}", filasHtml.ToString());

            return htmlProcesado;
        }
    }
}