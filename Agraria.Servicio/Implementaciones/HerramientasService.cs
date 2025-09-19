using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class HerramientasService : IHerramientasService
    {
        private readonly IHerramientasRepository _repo;

        public HerramientasService(IHerramientasRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<Herramientas>>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Result<Herramientas> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Result<Herramientas> Add(Herramientas herramienta)
        {
            return _repo.Add(herramienta);
        }

        public async Task<Result<Herramientas>> Update(Herramientas herramienta)
        {
            return await _repo.Update(herramienta);
        }

        public Result<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }
    }
}