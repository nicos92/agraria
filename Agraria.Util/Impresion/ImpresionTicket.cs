using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.Versioning;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.tool.xml;



namespace Agraria.Utilidades.Impresion
{
    [SupportedOSPlatform("windows")]
    public static class ImpresionTicket
    {
        public static void Imprimir(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal)
        {
            // ... (Pasos para generar htmlFinal se mantienen) ...
            string rutaPlantilla = Path.Combine(Application.StartupPath, "Impresion", "Impresion.html");
            var generador = new GeneradorTickets(rutaPlantilla);
            string htmlFinal = generador.GenerarHtmlTicket(
                montoTotal: montoTotal,
                motivo: motivo,
                numeroOperacion: numeroOperacion,
                productos: productos,
                fechaOperacion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(htmlFinal, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Crea un WebBrowser control dinámicamente y configura un tamaño.
            // Aunque no es visible, definir un tamaño ayuda a estabilizar el control.
            WebBrowser webBrowserParaImprimir = new WebBrowser
            {
                Width = 800, // Tamaño representativo de una hoja
                Height = 600
            };

            // Bandera para controlar la ejecución de la impresión
            bool impresionIniciada = false;

            // 2. Manejador del evento DocumentCompleted
            webBrowserParaImprimir.DocumentCompleted += (sender, e) =>
            {
                // Solo actúa si la impresión no ha sido iniciada.
                // También aseguramos que la URL actual sea el HTML cargado (normalmente about:blank para DocumentText).
                if (!impresionIniciada)
                {
                    // Manda a imprimir el documento.
                    webBrowserParaImprimir.Print();

                    // Establecemos la bandera en true para salir del bucle.
                    impresionIniciada = true;
                }
            };

            // 3. Carga el HTML.
            // Al usar DocumentText, la carga ocurre de inmediato en el bucle de mensajes.
            webBrowserParaImprimir.DocumentText = htmlFinal;

            // 4. 🔑 Bucle de espera crítica (con Timeout)
            int timeout = 5000; // Máximo 5 segundos de espera
            DateTime inicio = DateTime.Now;

            // El bucle de espera bloquea el hilo de la UI hasta que la impresión se inicia
            while (!impresionIniciada && (DateTime.Now - inicio).TotalMilliseconds < timeout)
            {
                // NECESARIO: Procesa todos los mensajes de la UI, lo que permite que el WebBrowser 
                // procese DocumentText y dispare DocumentCompleted.
                Application.DoEvents();

                // Pausa ligera para evitar el consumo de CPU.
                Thread.Sleep(5); // Reducido a 5ms
            }

            // 5. Verificación de TimeOut
            if (!impresionIniciada)
            {
                MessageBox.Show("Error al iniciar la impresión. Tiempo de espera agotado.", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // 6. Liberar recursos.
            webBrowserParaImprimir.Dispose();
        }

        public static void ImprimirIronPdf(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal)
        {
            // ... (Pasos para generar htmlFinal se mantienen) ...
            string rutaPlantilla = Path.Combine(Application.StartupPath, "Impresion", "Impresion.html");
            var generador = new GeneradorTickets(rutaPlantilla);
            string htmlFinal = generador.GenerarHtmlTicket(
                montoTotal: montoTotal,
                motivo: motivo,
                numeroOperacion: numeroOperacion,
                productos: productos,
                fechaOperacion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(htmlFinal, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 7. Código de impresión con IronPdf (comentado por si se desea usar en el futuro) sale que es obsoleto
            //try
            //{
            //    // Configura las opciones de impresión
            //    var renderer = new IronPdf.HtmlToPdf
            //    {
            //        PrintOptions = new IronPdf.PrintOptions
            //        {
            //            PaperSize = IronPdf.PdfPrintOptions.PdfPaperSize.Custom,
            //            PaperWidth = 80, // Ancho en mm para tickets
            //            PaperHeight = 200, // Alto en mm (ajustable según necesidad)
            //            MarginTop = 0,
            //            MarginBottom = 0,
            //            MarginLeft = 0,
            //            MarginRight = 0,
            //            FitToPaperWidth = true,
            //            FitToPaperHeight = false,
            //            ShowHeader = false,
            //            ShowFooter = false
            //        }
            //    };
            //    // Renderiza el HTML a PDF
            //    var pdfDocument = renderer.RenderHtmlAsPdf(htmlFinal);
            //    // Envía el PDF directamente a la impresora predeterminada
            //    pdfDocument.Print();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error al imprimir con IronPdf: {ex.Message}", "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            var renderer = new ChromePdfRenderer();
            var pdf = renderer.RenderHtmlAsPdf(htmlFinal);
            pdf.SaveAs("pixel-perfect.pdf");

        }

        public static void ImprimiriTextSharp(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal, string fechaOperacion)
        {
            // ... (Pasos para generar htmlFinal se mantienen) ...
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionventados.html");

            string rutaPlantillaCss = Path.Combine(Application.StartupPath, "Impresion", "Impresion.css");

            string rutaImg = Path.Combine(Application.StartupPath, "Impresion", "EAC256.png");
            var generador = new GeneradorTickets(rutaPlantillaHtml);
            string htmlFinal = generador.GenerarHtmlTicket(
                montoTotal: montoTotal,
                motivo: motivo,
                numeroOperacion: numeroOperacion,
                productos: productos,
                fechaOperacion: fechaOperacion
            );

            if (htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(htmlFinal, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SAVE FILE
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "Archivos de texto|*.pdf|Todos los archivos|*.*";
            saveFileDialog1.Title = "Guardar archivo";
            saveFileDialog1.FileName = "Remito de venta N°" + numeroOperacion;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                try
                {
                    // FIN SAVE FILE
                    using (FileStream stream = (FileStream)saveFileDialog1.OpenFile())
                    {

                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A4, 25, 25, 30, 30);

                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        using (StringReader srHtmlFinal = new StringReader(htmlFinal))
                        {

                            XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, srHtmlFinal);

                        }
                        // Creamos la imagen y le ajustamos el tamaño
                        iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImg);
                        imagen.BorderWidth = 0;
                        imagen.Alignment = Element.ALIGN_LEFT;
                        float percentage = 0.0f;
                        percentage = 80 / imagen.Width;
                        imagen.ScalePercent(percentage * 100);

                        imagen.SetAbsolutePosition(40, pdfDoc.PageSize.Height - 100); // Ajusta la posición según sea necesario



                        // Insertamos la imagen en el documento
                        pdfDoc.Add(imagen);
                        pdfDoc.Close();
                        writer.Close();
                    }
                    Console.WriteLine("PDF generation completed successfully.");
                    
                }catch(IOException ex)
                {
                    MessageBox.Show("El archivo está abierto en otro programa. Por favor, ciérrelo e intente de nuevo.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.StackTrace + " " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }


        public static void ImprimirITextSharpDos(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal)
        {
            // ... (Pasos para generar htmlFinal se mantienen) ...
            string rutaPlantilla = Path.Combine(Application.StartupPath, "Impresion", "impresionventa.html");
            var generador = new GeneradorTickets(rutaPlantilla);
            string htmlFinal = generador.GenerarHtmlTicket(
                montoTotal: montoTotal,
                motivo: motivo,
                numeroOperacion: numeroOperacion,
                productos: productos,
                fechaOperacion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(htmlFinal, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var fs = new FileStream("ticket.pdf", FileMode.Create))
            using (var doc = new iTextSharp.text.Document(PageSize.A4))
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();

                string html = File.ReadAllText("ticket.html");

                using (var sr = new StringReader(html))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);
                }

                doc.Close();
            }
        }
    }
}