using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class SubcategoriaService(IEntornoRepository repo) : IEntornoService
    {
        private readonly IEntornoRepository _repo = repo;

        public Task<Result<List<Entorno>>> GetAll() => _repo.GetAll();
        public Result<Entorno> GetById(int id) => _repo.GetById(id);
        public Result<Entorno> Add(Entorno subcategoria) => _repo.Add(subcategoria);
        public Result<Entorno> Update(Entorno subcategoria) => _repo.Update(subcategoria);
        public Result<bool> Delete(int id) => _repo.Delete(id);

        public async Task<Result<List<Entorno>>> GetAllxEntorno(int idcategoria)
        {
            return await _repo.GetAllxCategoria(idcategoria);
        }
    }
}
