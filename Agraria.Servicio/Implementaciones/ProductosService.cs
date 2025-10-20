using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;
using Agraria.Modelo.Records;

namespace Agraria.Servicio.Implementaciones
{
    public class ProductosService(IProductosRepository repo) : IProductoService
    {
        private readonly IProductosRepository _repo = repo;

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

        public async Task<Result<List<ProductosMasVendidos>>> GetArticulosMasVendidos(int v)
        {
            return await _repo.GetProductosMasVendidos(v);
        }
    }
}
