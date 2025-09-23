using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Servicio.Implementaciones
{
    public class ArticuloStockService(IArticuloStockRepository _repo) : IProductoStockService
    {
        public async Task<Result<bool>> Add(Productos articulo, Stock stock)
        {
            return await _repo.Add(articulo, stock);
        }

        public async Task<Result<bool>> Delete(Productos articulo, Stock stock)
        {
            return await _repo.Delete(articulo,stock);
        }

        public async Task<Result<(List<Productos> articulos, List<Stock> stock)>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Result<List<ProductoStock>>> GetAllArticuloStock()
        {
            return await _repo.GetAllArticuloStock();
        }

        public async Task<Result<bool>> Update(Productos articulos, Stock stock)
        {
            return await _repo.Update(articulos, stock);
        }
    }
}
