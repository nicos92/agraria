using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Contrato.Repositorios
{
    public interface IRespaldoRepositorio
    {
		bool CrearRespaldo(string rutaDestino);
		Task<bool> CrearRespaldoAsync(string rutaDestino, IProgress<int> progress = null);
		string GenerarNombreRespaldo(string rutaCarpeta, string prefijo = "Agraria_Backup");
		bool RestaurarRespaldo(string rutaRespaldo, bool forzarReemplazo = false);
		bool VerificarRespaldo(string rutaRespaldo);
		Task<string> CrearRespaldoSeguroAsync(string rutaDestino = null, IProgress<int> progress = null);

		string ObtenerInfoRespaldo(string rutaRespaldo);
		Task<bool> RestaurarRespaldoAsync(string rutaRespaldo, bool forzarReemplazo = false, IProgress<string> progress = null);
		Task<bool> RestaurarOCrearBaseDatosAsync(string rutaRespaldo, string nombreBaseDatos = null, IProgress<string> progress = null);
		List<(string NombreLogico, string TipoArchivo, string NombreFisico)> ObtenerArchivosRespaldo(string rutaRespaldo);
	}
}
