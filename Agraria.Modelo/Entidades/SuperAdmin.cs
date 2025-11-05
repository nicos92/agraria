using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Modelo.Enums;

namespace Agraria.Modelo.Entidades
{
    public class SuperAdmin : Usuarios
    {
		public string? DNI { get; set; } = "38041304";
		public string? Nombre { get; set; } = "Super";
		public string? Apellido { get; set; } = "Admin";
		public int Id_Tipo { get; set; } = (int) Roles.SuperAdmin;
		public string? Contra { get; set; } = "@Superadmin2025";

		
	}
}
