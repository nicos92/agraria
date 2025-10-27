using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;

namespace Agraria.Utilidades
{
    public static class ControlDeAccesos
    {
		/// <summary>
		/// Determina si el rol actual tiene permiso para ver un control.
		/// </summary>
		/// <param name="minimoUsuario">El rol mínimo necesario para ver el control.</param>
		/// <returns>True si el usuario actual puede ver el control.</returns>
		public static bool PuedeVer(int[] minimoUsuario)
		{
			// Obtiene el rol del usuario actual
			int tipoUsuario = SessionManager.Instance.Usuario.Id_Tipo;

			
			return minimoUsuario.Contains(tipoUsuario);
		}
	}
}
