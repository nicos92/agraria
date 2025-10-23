using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;


namespace Agraria.UI.Acerca
{
	public partial class FormAcercaDe : Form
	{
		public FormAcercaDe()
		{
			InitializeComponent();
		}

		private void FormAcercaDe_Load(object sender, EventArgs e)
		{

			// ... dentro de un método en tu Formulario, por ejemplo, el Form_Load

			// 1. Obtener la información del Assembly
			Assembly assembly = Assembly.GetExecutingAssembly();
			AssemblyName assemblyName = assembly.GetName();

			string version = assemblyName.Version.ToString();
			// Usar Path.GetFileName() para obtener solo el nombre del ejecutable
			string fechaCompilacion = File.GetLastWriteTime(assembly.Location).ToString("yyyy-MM-dd HH:mm:ss");

			// 2. Obtener la información del Runtime y del SO
			string netVersion = System.Environment.Version.ToString();
			string osName = System.Environment.OSVersion.VersionString;
			string osArchitecture = System.Environment.Is64BitOperatingSystem ? "x64" : "x86";

			// 2. Obtener la información del producto
			string nombreProducto = assembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "N/A";
			string version2 = assembly.GetName().Version.ToString();
			string descripcion = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? "N/A";

			// 3. Obtener la información legal
			string copyright = assembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "N/A";
			string company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? "N/A";

			// Otra forma de obtener la versión (opcional, FileVersionInfo)
			FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
			// fvi.FileVersion; 
			// fvi.ProductVersion; 
			// fvi.CompanyName;
			// Aquí puedes asignar estos valores a los controles de tu formulario
			// Por ejemplo, un Label llamado lblVersion y otro lblSO
			LblVersion.Text = $"Versión: {version}";
			LblFecha.Text = $"Fecha: {fechaCompilacion}";
			LblNet.Text = $".NET Runtime: {netVersion}";
			LblSo.Text = $"SO: {osName} ({osArchitecture})";
			LblNombreProducto.Text = $"Producto: {nombreProducto}";

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// 1. Define la URL que quieres abrir
			string url = "https://github.com/nicos92";

			try
			{
				// Usa el comando 'start' de Windows para abrir el enlace
				Process.Start("cmd", $"/c start {url.Replace("&", "^&")}");

				// Opcional
				linkLabel1.LinkVisited = true;
			}
			catch (Exception ex)
			{
				// Manejo de errores (por si el navegador no puede abrirse)
				MessageBox.Show($"No se pudo abrir la página web: {ex.Message}",
								"Error de Navegación",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
			}
		}
	}
}
