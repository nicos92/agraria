using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agraria.Util.Validaciones
{
	[SupportedOSPlatform("windows")]
	public static class ValidadorMultiple
	{
		public static bool ValidacionMultiple(params ValidadorTextBox[] validaciones)
		{

			return validaciones.All(a => a.Validar());

		}
	}
}
