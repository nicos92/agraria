using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Agraria.Modelo.Entidades;

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

        public string GenerarHtmlTicket(string montoTotal, string motivo, string numeroOperacion, List<ProductoVenta> productos, string fechaOperacion, string titulo, string descuento)
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
            htmlProcesado = htmlProcesado.Replace("{{descuento_total}}", descuento);

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

        public string GenerarHtmlHojaVida(List<Agraria.Modelo.Entidades.HojadeVida> hojasDeVida, string totalHojasDeVida, string fechaGeneracion)
        {
            if (string.IsNullOrEmpty(plantillaHtml))
            {
                return "Error: La plantilla HTML no se pudo cargar.";
            }

            string htmlProcesado = plantillaHtml;
            htmlProcesado = htmlProcesado.Replace("{{fecha_generacion}}", fechaGeneracion);
            htmlProcesado = htmlProcesado.Replace("{{total_hojas_vida}}", totalHojasDeVida);

            var filasHtml = new StringBuilder();
            foreach (var hojaVida in hojasDeVida)
            {
                filasHtml.Append("<tr>");
                filasHtml.Append($"<td>{hojaVida.Numero}</td>");
                filasHtml.Append($"<td>{hojaVida.TipoAnimal}</td>");
                filasHtml.Append($"<td>{hojaVida.Sexo}</td>");
                filasHtml.Append($"<td>{hojaVida.FechaNacimiento.ToString("yyyy-MM-dd")}</td>");
                filasHtml.Append($"<td>{hojaVida.Peso:N2}</td>");
                filasHtml.Append($"<td>{hojaVida.EstadoSalud}</td>");
                filasHtml.Append($"<td>{(hojaVida.Activo ? "Sí" : "No")}</td>");
                filasHtml.Append("</tr>");
            }

            htmlProcesado = htmlProcesado.Replace("{{tabla_hojas_vida}}", filasHtml.ToString());

            return htmlProcesado;
        }

        public string GenerarHtmlVentasGrandes(List<Agraria.Modelo.Entidades.HVentasConUsuario> ventasGrandes, string totalVentas, string fechaGeneracion)
        {
            if (string.IsNullOrEmpty(plantillaHtml))
            {
                return "Error: La plantilla HTML no se pudo cargar.";
            }

            string htmlProcesado = plantillaHtml;
            htmlProcesado = htmlProcesado.Replace("{{fecha_generacion}}", fechaGeneracion);
            htmlProcesado = htmlProcesado.Replace("{{total_ventas}}", totalVentas);

            var filasHtml = new StringBuilder();
            foreach (var venta in ventasGrandes)
            {
                filasHtml.Append("<tr>");
                filasHtml.Append($"<td>{venta.Id_Remito.ToString().Trim().PadLeft(8, '0')}</td>");
                filasHtml.Append($"<td>{venta.NombreUsuario} {venta.ApellidoUsuario}</td>");
                filasHtml.Append($"<td>{venta.Fecha_Hora.ToString("yyyy-MM-dd HH:mm")}</td>");
                filasHtml.Append($"<td>${venta.Total:N2}</td>");
                filasHtml.Append($"<td>{venta.Descripcion}</td>");
                filasHtml.Append("</tr>");
            }

            htmlProcesado = htmlProcesado.Replace("{{tabla_ventas_grandes}}", filasHtml.ToString());

            return htmlProcesado;
        }
    }
}
