using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;

namespace Agraria.Servicio.Implementaciones
{
    public class CategoriasService : IEntornosService
    {
        private readonly ICategoriasRepository _repo;

        public CategoriasService(ICategoriasRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<Entornos>>> GetAll() => await _repo.GetAll();
        public Result<Entornos> GetById(int id) => _repo.GetById(id);
        public Result<Entornos> Add(Entornos categoria) => _repo.Add(categoria);
        public Result<Entornos> Update(Entornos categoria) => _repo.Update(categoria);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
