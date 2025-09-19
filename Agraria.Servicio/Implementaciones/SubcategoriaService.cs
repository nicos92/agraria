using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class SubcategoriaService : ISubEntornoService
    {
        private readonly ISubcategoriaRepository _repo;

        public SubcategoriaService(ISubcategoriaRepository repo)
        {
            _repo = repo;
        }

        public Task<Result<List<SubEntornos>>> GetAll() => _repo.GetAll();
        public Result<SubEntornos> GetById(int id) => _repo.GetById(id);
        public Result<SubEntornos> Add(SubEntornos subcategoria) => _repo.Add(subcategoria);
        public Result<SubEntornos> Update(SubEntornos subcategoria) => _repo.Update(subcategoria);
        public Result<bool> Delete(int id) => _repo.Delete(id);

        public async Task<Result<List<SubEntornos>>> GetAllxEntorno(int idcategoria)
        {
            return await _repo.GetAllxCategoria(idcategoria);
        }
    }
}
