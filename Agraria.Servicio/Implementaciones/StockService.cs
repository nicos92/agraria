using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Contrato.Servicios;
using Agraria.Contrato.Repositorios;
using Agraria.Utilidades;

namespace Agraria.Servicio.Implementaciones
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _repo;

        public StockService(IStockRepository repo)
        {
            _repo = repo;
        }

        public async Task<Result<List<Stock>>> GetAll() => await _repo.GetAll();
        public Result<Stock> GetById(int id) => _repo.GetById(id);
        public Result<Stock> Add(Stock stock) => _repo.Add(stock);
        public Result<Stock> Update(Stock stock) => _repo.Update(stock);
        public Result<bool> Delete(int id) => _repo.Delete(id);
    }
}
