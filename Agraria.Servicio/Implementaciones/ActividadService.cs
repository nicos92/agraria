using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agraria.Servicio.Implementaciones
{
    public class ActividadService(IActividadRepository repo) : IActividadService
    {
        private readonly IActividadRepository _repo = repo;

        public async Task<Result<Actividad>> Add(Actividad actividad)
        {
            return await _repo.Add(actividad);
        }

        public Result<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<Result<List<Actividad>>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Result<Actividad> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public async Task<Result<Actividad>> Update(Actividad actividad)
        {
            return await _repo.Update(actividad);
        }

        public async Task<Result<List<Actividad>>> GetAllByEntorno(int idEntorno)
        {
            return await _repo.GetAllByEntorno(idEntorno);
        }

        public async Task<Result<List<Actividad>>> GetAllByTipoEntorno(int idTipoEntorno)
        {
            return await _repo.GetAllByTipoEntorno(idTipoEntorno);
        }

        public async Task<Result<List<Actividad>>> GetByFechaRango(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _repo.GetByFechaRango(fechaInicio, fechaFin);
        }

        public async Task<Result<List<ActividadesCurso>>> GetTopDiez()
        {
            return await _repo.GetTopDiez();
        }
    }
}