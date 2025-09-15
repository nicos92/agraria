using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;

namespace Agraria.Servicio.Implementaciones
{
    public class SubcategoriaService : ISubcategoriaService
    {
        private readonly ISubcategoriaRepository _repo;

        public SubcategoriaService(ISubcategoriaRepository repo)
        {
            _repo = repo;
        }

        public Task<Result<List<Subcategoria>>> GetAll() => _repo.GetAll();
        public Result<Subcategoria> GetById(int id) => _repo.GetById(id);
        public Result<Subcategoria> Add(Subcategoria subcategoria) => _repo.Add(subcategoria);
        public Result<Subcategoria> Update(Subcategoria subcategoria) => _repo.Update(subcategoria);
        public Result<bool> Delete(int id) => _repo.Delete(id);

        public async Task<Result<List<Subcategoria>>> GetAllxCategoria(int idcategoria)
        {
            return await _repo.GetAllxCategoria(idcategoria);
        }
    }
}
