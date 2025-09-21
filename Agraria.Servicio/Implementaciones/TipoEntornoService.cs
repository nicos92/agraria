using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class TipoEntornoService(ITipoEntornoRepository repo) : ITipoEntornosService
    {
        private readonly ITipoEntornoRepository _repo = repo;

        public async Task<Result<List<TipoEntorno>>> GetAll() => await _repo.GetAll();
        public Result<TipoEntorno> GetById(int id) => _repo.GetById(id);
        public Result<TipoEntorno> Add(TipoEntorno categoria) => _repo.Add(categoria);
        public Result<TipoEntorno> Update(TipoEntorno categoria) => _repo.Update(categoria);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
