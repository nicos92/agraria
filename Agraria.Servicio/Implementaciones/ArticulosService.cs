using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class ArticulosService : IArticulosService
    {
        private readonly IArticulosRepository _repo;

        public ArticulosService(IArticulosRepository repo)
        {
            _repo = repo;
        }
       

        public async Task<Result<List<Productos>>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Result<Productos> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Result<Productos> Add(Productos articulo)
        {
            return _repo.Add(articulo);
        }

        public async Task<Result<Productos>> Update(Productos articulo)
        {
            return await _repo.Update(articulo);
        }

        public Result<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<Result<int>> GetMaxCodArt()
        {
            return await  _repo.GetMaxCodArt();
        }
    }
}
