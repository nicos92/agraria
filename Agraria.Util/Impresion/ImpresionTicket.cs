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
using Agraria.Modelo.Entidades; // Añadir esta referencia para HojadeVida
using Agraria.Utilidades;
using Agraria.Modelo.Records; // Para TareasLargas


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
			_saveFileDialog1 = new SaveFileDialog
			{
				DefaultExt = "pdf",
				Filter = "Archivos de texto|*.pdf|Todos los archivos|*.*",
				Title = "Guardar archivo"
			};
			_rutaImg = Path.Combine(Application.StartupPath, "Impresion", "EAC256.png");
            _htmlFinal = string.Empty;

        }




        public void ImprimiriTextSharp(List<ProductoVenta> productos, string numeroOperacion, string motivo, string montoTotal, string fechaOperacion, string tituloOperacion, string descuento)
        {
            // ... (Pasos para generar htmlFinal se mantienen) ...
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionventados.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
             _htmlFinal = generador.GenerarHtmlTicket(
                montoTotal: montoTotal,
                motivo: motivo,
                numeroOperacion:  numeroOperacion.Trim().PadLeft(8, '0'),
                productos: productos,
                fechaOperacion: fechaOperacion,
                titulo: tituloOperacion,
                descuento: descuento
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
                TareasLargas tareas = new();
                tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });

            }
        }

        public void ImprimirHojaVida(List<HojadeVida> hojasDeVida)
        {
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionhojavida.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
            _htmlFinal = generador.GenerarHtmlHojaVida(
                hojasDeVida: hojasDeVida,
                totalHojasDeVida: hojasDeVida.Count.ToString(),
                fechaGeneracion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión de Hoja de Vida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saveFileDialog1.FileName = "Reporte_Hojas_de_Vida_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TareasLargas tareas = new();
                tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });
            }
        }

        public void ImprimirVentasGrandes(List<HVentasConUsuario> ventasGrandes)
        {
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionventasgrandes.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
            _htmlFinal = generador.GenerarHtmlVentasGrandes(
                ventasGrandes: ventasGrandes,
                totalVentas: ventasGrandes.Count.ToString(),
                fechaGeneracion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión de Ventas Grandes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saveFileDialog1.FileName = "Reporte_Ventas_Grandes_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TareasLargas tareas = new();
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
					using FileStream stream = (FileStream)saveFileDialog1.OpenFile();

					iTextSharp.text.Document pdfDoc = new(PageSize.A4, 25, 25, 30, 30);

					PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
					pdfDoc.Open();
					// Creamos la imagen y le ajustamos el tamaño
					iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImg);
					imagen.BorderWidth = 0;
					imagen.Alignment = Element.ALIGN_LEFT;
					float percentage = 0.0f;
					percentage = 80 / imagen.Width;
					imagen.ScalePercent(percentage * 100);

					imagen.SetAbsolutePosition(40, pdfDoc.PageSize.Height - 110); // Ajusta la posición según sea necesario



					// Insertamos la imagen en el documento
					pdfDoc.Add(imagen);
					using (StringReader srHtmlFinal = new(htmlFinal))
					{

						XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, srHtmlFinal);

					}

					pdfDoc.Close();
					writer.Close();
					DialogResult dialogResult = MessageBox.Show($"¿Desea abrir el archivo PDF guardado?", "Abrir carpeta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Yes)
						AbrirCarpetaPdf(Path.GetFullPath(saveFileDialog1.FileName));
					Console.WriteLine("PDF generation completed successfully.");


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

        public void ImprimirEntornoFormativo(List<Agraria.Modelo.Records.EntornoFormativoConNombres> entornosFormativos)
        {
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionentornoformativo.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
            _htmlFinal = generador.GenerarHtmlEntornoFormativo(
                entornosFormativos: entornosFormativos,
                totalEntornosFormativos: entornosFormativos.Count.ToString(),
                fechaGeneracion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión de Entornos Formativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saveFileDialog1.FileName = "Reporte_Entornos_Formativos_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
				TareasLargas tareas = new();
				tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });
            }
        }

        public void ImprimirProductosStock(List<Agraria.Modelo.Entidades.ProductoStockConNombres> productos)
        {
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionproductosstock.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
            _htmlFinal = generador.GenerarHtmlProductosStock(
                productos: productos,
                totalProductos: productos.Count.ToString(),
                fechaGeneracion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión de Productos con Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saveFileDialog1.FileName = "Reporte_Productos_Stock_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TareasLargas tareas = new();
                tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });
            }
        }

        public void ImprimirProductosMasVendidos(List<ProductosMasVendidos> productos)
        {
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionmasvendidos.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
            _htmlFinal = generador.GenerarHtmlProductosMasVendidos(
                productos: productos,
                totalProductos: productos.Count.ToString(),
                fechaGeneracion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión de Productos Más Vendidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saveFileDialog1.FileName = "Reporte_Productos_Mas_Vendidos_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TareasLargas tareas = new ();
                tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });
            }
        }

        public void ImprimirActividades(List<Agraria.Modelo.Records.ActividadConNombres> actividades)
        {
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionactividades.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
            _htmlFinal = generador.GenerarHtmlActividades(
                actividades: actividades,
                totalActividades: actividades.Count.ToString(),
                fechaGeneracion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión de Actividades", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saveFileDialog1.FileName = "Reporte_Actividades_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TareasLargas tareas = new();
                tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });
            }
        }

        public void ImprimirUsuarios(List<Agraria.Modelo.Records.UsuarioConTipo> usuarios)
        {
            string rutaPlantillaHtml = Path.Combine(Application.StartupPath, "Impresion", "impresionusuarios.html");

            var generador = new GeneradorTickets(rutaPlantillaHtml);
            _htmlFinal = generador.GenerarHtmlUsuarios(
                usuarios: usuarios,
                totalUsuarios: usuarios.Count.ToString(),
                fechaGeneracion: DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            );

            if (_htmlFinal.StartsWith("Error:"))
            {
                MessageBox.Show(_htmlFinal, "Error de Impresión de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _saveFileDialog1.FileName = "Reporte_Usuarios_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            DialogResult result = _saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TareasLargas tareas = new();
                tareas.RecibirTarea(() =>
                {
                    GenerarPDF(_rutaImg, _htmlFinal, _saveFileDialog1);
                });
            }
        }


    }
}
