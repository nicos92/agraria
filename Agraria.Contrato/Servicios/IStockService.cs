using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Servicios
{
    public interface IStockService
    {
        Task<Result<List<Stock>>> GetAll();
        Result<Stock> GetById(int id);
        Result<Stock> Add(Stock stock);
        Result<Stock> Update(Stock stock);
        Result<bool> Delete(int id);
    }
}
