using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;

namespace Agraria.Servicio.Implementaciones
{
    public class ArticulosGralService : IArticulosGralService
    {
        private readonly IArticulosGralRepository _repo;

        public ArticulosGralService(IArticulosGralRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<ArticulosGral>>> GetAll()
        {
            return await _repo.GetAll();
        }

        public Result<ArticulosGral> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public Result<ArticulosGral> Add(ArticulosGral articulo)
        {
            return _repo.Add(articulo);
        }

        public async Task<Result<ArticulosGral>> Update(ArticulosGral articulo)
        {
            return await _repo.Update(articulo);
        }

        public Result<bool> Delete(int id)
        {
            return _repo.Delete(id);
        }

        public async Task<Result<int>> GetMaxCodArt()
        {
            return await _repo.GetMaxCodArt();
        }
    }
}