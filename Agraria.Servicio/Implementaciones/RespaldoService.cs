using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;

namespace Agraria.Servicio.Implementaciones
{
	public class RespaldoService(IRespaldoRepositorio _respaldoRepositorio) : IRespaldoService
	{
		public bool CrearRespaldo(string rutaDestino)
		{
			return _respaldoRepositorio.CrearRespaldo(rutaDestino);
		}

		public async Task<bool> CrearRespaldoAsync(string rutaDestino, IProgress<int> progress = null)
		{
			return await _respaldoRepositorio.CrearRespaldoAsync(rutaDestino, progress);
		}

		public async Task<string> CrearRespaldoSeguroAsync(string rutaDestino = null, IProgress<int> progress = null)
		{
			return await _respaldoRepositorio.CrearRespaldoSeguroAsync(rutaDestino, progress);
		}

		public string GenerarNombreRespaldo(string rutaCarpeta, string prefijo = "Agraria_Backup")
		{
			return _respaldoRepositorio.GenerarNombreRespaldo(rutaCarpeta, prefijo);
		}

		public List<(string NombreLogico, string TipoArchivo, string NombreFisico)> ObtenerArchivosRespaldo(string rutaRespaldo)
		{
			return _respaldoRepositorio.ObtenerArchivosRespaldo(rutaRespaldo);
		}

		public string ObtenerInfoRespaldo(string rutaRespaldo)
		{
			return _respaldoRepositorio.ObtenerInfoRespaldo(rutaRespaldo);
		}

		public async Task<bool> RestaurarOCrearBaseDatosAsync(string rutaRespaldo, string nombreBaseDatos = null, IProgress<string> progress = null)
		{
			return await _respaldoRepositorio.RestaurarOCrearBaseDatosAsync(rutaRespaldo, nombreBaseDatos, progress);
		}

		public bool RestaurarRespaldo(string rutaRespaldo, bool forzarReemplazo = false)
		{
			return _respaldoRepositorio.RestaurarRespaldo(rutaRespaldo, forzarReemplazo);
		}

		public async Task<bool> RestaurarRespaldoAsync(string rutaRespaldo, bool forzarReemplazo = false, IProgress<string> progress = null)
		{
			return await _respaldoRepositorio.RestaurarRespaldoAsync(rutaRespaldo, forzarReemplazo, progress);
		}

		public bool VerificarRespaldo(string rutaRespaldo)
		{
			return _respaldoRepositorio.VerificarRespaldo(rutaRespaldo);
		}
	}
}
