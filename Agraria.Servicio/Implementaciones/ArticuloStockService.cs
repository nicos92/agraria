using Agraria.Contrato.Repositorios;
using Agraria.Contrato.Servicios;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Servicio.Implementaciones
{
    public class ArticuloStockService(IArticuloStockRepository _repo) : IArticuloStockService
    {
        public async Task<Result<bool>> Add(Articulos articulo, Stock stock)
        {
            return await _repo.Add(articulo, stock);
        }

        public async Task<Result<bool>> Delete(Articulos articulo, Stock stock)
        {
            return await _repo.Delete(articulo,stock);
        }

        public async Task<Result<(List<Articulos> articulos, List<Stock> stock)>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Result<List<ArticuloStock>>> GetAllArticuloStock()
        {
            return await _repo.GetAllArticuloStock();
        }

        public async Task<Result<bool>> Update(Articulos articulos, Stock stock)
        {
            return await _repo.Update(articulos, stock);
        }
    }
}
