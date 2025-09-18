using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using System.Threading.Tasks;

namespace Agraria.Servicio.Implementaciones
{
    public class PreguntasSeguridadService(IPreguntasSeguridadRepository repo) : IPreguntasSeguridadService
    {
        private readonly IPreguntasSeguridadRepository _repo = repo;

        public async Task<Result<List<PreguntasSeguridad>>> GetAll() => await _repo.GetAll();
        public async Task<Result<PreguntasSeguridad>> GetById(int id) => await _repo.GetById(id);
        public Result<PreguntasSeguridad> Add(PreguntasSeguridad pregunta) => _repo.Add(pregunta);
        public Result<PreguntasSeguridad> Update(PreguntasSeguridad pregunta) => _repo.Update(pregunta);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}