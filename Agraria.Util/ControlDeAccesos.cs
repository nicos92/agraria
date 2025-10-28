using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Modelo;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Enums;
using Org.BouncyCastle.Asn1.X509;

namespace Agraria.Utilidades
{
    public static class ControlDeAccesos
    {
		
		public static bool PuedeVer(Roles[] tiposusuario)
		{
			// Obtiene el tipo de usuario actual
			int tipoUsuario = SessionManager.Instance.Usuario.Id_Tipo;

			
			return tiposusuario.Any( t => (int) t == tipoUsuario);
		}
	}
}
