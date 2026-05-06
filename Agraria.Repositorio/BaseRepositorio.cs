using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agraria.Repositorio
{
	[SupportedOSPlatform("windows")]
	public abstract class BaseRepositorio
	{
		private readonly string cadenaConexion;

		protected BaseRepositorio()
		{
			// CONEXION PARA T440 - Producción
			cadenaConexion = "Server=NicoS92T440;Database=Agraria;Trusted_Connection=True;TrustServerCertificate=True;";
		}

		/// <summary>
		/// Constructor para tests de integración con cadena de conexión personalizada.
		/// </summary>
		protected BaseRepositorio(string cadenaConexionPersonalizada)
		{
			cadenaConexion = cadenaConexionPersonalizada;
		}

		protected SqlConnection Conexion()
		{
			return new SqlConnection(cadenaConexion);
		}

		protected static SqlConnection ConexionRestaurarDB()
		{
			return new SqlConnection("Server=NicoS92T440;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");
		}

	}
}
