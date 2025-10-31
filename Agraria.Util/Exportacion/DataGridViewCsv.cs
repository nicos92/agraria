using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Agraria.Utilidades.Exportacion
{
	public static class DataGridViewCsv
	{
		/// <summary>
		/// Exporta un DataGridView a archivo CSV con opciones personalizables
		/// </summary>
		/// <param name="dgv">DataGridView a exportar</param>
		/// <param name="filePath">Ruta completa del archivo CSV</param>
		/// <param name="incluirEncabezados">Incluir nombres de columnas como primera fila</param>
		/// <param name="separador">Carácter separador (por defecto ',')</param>
		/// <param name="encoding">Codificación del archivo (por defecto UTF8)</param>
		public static void ExportarACSV(DataGridView dgv, string filePath,
			bool incluirEncabezados = true, char separador = ';', Encoding encoding = null)
		{
			ArgumentNullException.ThrowIfNull(dgv);

			if (string.IsNullOrWhiteSpace(filePath))
				throw new ArgumentException("La ruta del archivo no puede estar vacía", nameof(filePath));

			encoding ??= Encoding.UTF8;

			try
			{
				using StreamWriter sw = new(filePath, false, encoding);
				// Escribir encabezados
				if (incluirEncabezados)
				{
					StringBuilder sbEncabezados = new();

					for (int i = 0; i < dgv.Columns.Count; i++)
					{
						if (!dgv.Columns[i].Visible)
							continue;

						sbEncabezados.Append(EscaparCampoCSV(dgv.Columns[i].HeaderText, separador));

						if (i < dgv.Columns.Count - 1)
							sbEncabezados.Append(separador);
					}

					sw.WriteLine(sbEncabezados.ToString());
				}

				// Escribir filas
				foreach (DataGridViewRow fila in dgv.Rows)
				{
					if (fila.IsNewRow)
						continue;

					StringBuilder sbFila = new();

					for (int i = 0; i < dgv.Columns.Count; i++)
					{
						if (!dgv.Columns[i].Visible)
							continue;

						object valor = fila.Cells[i].Value;
						string valorTexto = valor != null ? valor.ToString() : string.Empty;

						sbFila.Append(EscaparCampoCSV(valorTexto, separador));

						if (i < dgv.Columns.Count - 1)
							sbFila.Append(separador);
					}

					sw.WriteLine(sbFila.ToString());
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al exportar a CSV: {ex.Message}", ex);
			}
		}

		/// <summary>
		/// Exporta con diálogo SaveFileDialog para que el usuario elija la ubicación
		/// </summary>
		public static bool ExportarACSVConDialogo(DataGridView dgv, string reporte, bool incluirEncabezados = true)
		{
			using SaveFileDialog sfd = new();
			sfd.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
			sfd.DefaultExt = "csv";
			sfd.FileName = $"{reporte}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

			if (sfd.ShowDialog() == DialogResult.OK)
			{
				try
				{
					ExportarACSV(dgv, sfd.FileName, incluirEncabezados);
					MessageBox.Show("Exportación completada exitosamente",
						"Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return true;
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error al exportar: {ex.Message}",
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// Escapa correctamente los campos para formato CSV
		/// </summary>
		private static string EscaparCampoCSV(string campo, char separador)
		{
			if (string.IsNullOrEmpty(campo))
				return string.Empty;

			// Si contiene el separador, comillas o saltos de línea, debe envolverse en comillas
			if (campo.Contains(separador) || campo.Contains('"') ||
				campo.Contains('\r') || campo.Contains('\n'))
			{
				// Duplicar comillas internas
				campo = campo.Replace("\"", "\"\"");
				// Envolver en comillas
				return $"\"{campo}\"";
			}

			return campo;
		}

		/// <summary>
		/// Exporta solo las filas seleccionadas del DataGridView
		/// </summary>
		public static void ExportarFilasSeleccionadas(DataGridView dgv, string filePath,
			bool incluirEncabezados = true, char separador = ',')
		{
			if (dgv.SelectedRows.Count == 0)
				throw new InvalidOperationException("No hay filas seleccionadas para exportar");

			try
			{
				using StreamWriter sw = new(filePath, false, Encoding.UTF8);
				// Escribir encabezados
				if (incluirEncabezados)
				{
					StringBuilder sbEncabezados = new ();

					for (int i = 0; i < dgv.Columns.Count; i++)
					{
						if (!dgv.Columns[i].Visible)
							continue;

						sbEncabezados.Append(EscaparCampoCSV(dgv.Columns[i].HeaderText, separador));

						if (i < dgv.Columns.Count - 1)
							sbEncabezados.Append(separador);
					}

					sw.WriteLine(sbEncabezados.ToString());
				}

				// Escribir solo filas seleccionadas
				foreach (DataGridViewRow fila in dgv.SelectedRows)
				{
					if (fila.IsNewRow)
						continue;

					StringBuilder sbFila = new();

					for (int i = 0; i < dgv.Columns.Count; i++)
					{
						if (!dgv.Columns[i].Visible)
							continue;

						object valor = fila.Cells[i].Value;
						string valorTexto = valor != null ? valor.ToString() : string.Empty;

						sbFila.Append(EscaparCampoCSV(valorTexto, separador));

						if (i < dgv.Columns.Count - 1)
							sbFila.Append(separador);
					}

					sw.WriteLine(sbFila.ToString());
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Error al exportar filas seleccionadas: {ex.Message}", ex);
			}
		}
	}
}

// EJEMPLO DE USO:
/*
// Opción 1: Exportar directamente a una ruta
DataGridViewExporter.ExportarACSV(dataGridView1, @"C:\temp\datos.csv");

// Opción 2: Con diálogo para elegir ubicación
DataGridViewExporter.ExportarACSVConDialogo(dataGridView1);

// Opción 3: Con separador personalizado (punto y coma para Excel en español)
DataGridViewExporter.ExportarACSV(dataGridView1, @"C:\temp\datos.csv", true, ';');

// Opción 4: Exportar solo filas seleccionadas
DataGridViewExporter.ExportarFilasSeleccionadas(dataGridView1, @"C:\temp\seleccion.csv");

// Opción 5: Sin encabezados
DataGridViewExporter.ExportarACSV(dataGridView1, @"C:\temp\datos.csv", false);
*/
