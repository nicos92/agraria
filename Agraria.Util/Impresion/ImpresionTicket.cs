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
using BitMiracle.LibTiff.Classic;



namespace Agraria.Utilidades.Impresion
{
    [SupportedOSPlatform("windows")]
    public class ImpresionTicket
    {
        private readonly SaveFileDialog _saveFileDialog1;
        private readonly string _rutaImg;
        private string _htmlFinal;
        public ImpresionTicket() 
        {
            _saveFileDialog1 = new SaveFileDialog();
            _saveFileDialog1.DefaultExt = "pdf";
            _saveFileDialog1.Filter = "Archivos de texto|*.pdf|Todos los archivos|*.*";
            _saveFileDialog1.Title = "Guardar archivo";
            _rutaImg = Path.Combine(Application.StartupPath, "Impresion", "EAC256.png");
            _htmlFinal = string.Empty;
           
        }

       
       
       
        public void ImprimiriTextSharp(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal, string fechaOperacion, string tituloOperacion)
        {
            // ... (Pasos para generar htmlFinal se mantienen) ...
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionventados.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
             _htmlFinal = generador.GenerarHtmlTicket(
                montoTotal: montoTotal,
                motivo: motivo,
                numeroOperacion: numeroOperacion,
                productos: productos,
                fechaOperacion: fechaOperacion,
                titulo: tituloOperacion
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            _saveFileDialog1.FileName = tituloOperacion + " N°" + numeroOperacion;
             DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TareasLargas tareas = new TareasLargas();
                tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });

            }





        }

        private static void GenerarPDF(string rutaImg, string htmlFinal, SaveFileDialog saveFileDialog1)
        {
            // Aquí puedes manejar cualquier lógica adicional cuando el usuario selecciona un archivo
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
                        DialogResult dialogResult = MessageBox.Show($"¿Desea abrir el archivo PDF guardado?", "Abrir carpeta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                            AbrirCarpetaPdf(Path.GetFullPath(saveFileDialog1.FileName));
                        Console.WriteLine("PDF generation completed successfully.");
                    }


                }
                catch (IOException ex)
                {
                    MessageBox.Show("El archivo está abierto en otro programa. Por favor, ciérrelo e intente de nuevo.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.StackTrace + " " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public static void AbrirCarpetaPdf(string ruta)
        {
            try
            {
                // Abre el explorador de archivos en la ruta especificada
                System.Diagnostics.Process.Start("explorer.exe", ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la carpeta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


      
    }
}