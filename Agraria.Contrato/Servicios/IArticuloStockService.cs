using Agraria.Modelo.Entidades;
using Agraria.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Contrato.Servicios
{
    public interface IArticuloStockService
    {
        Task<Result<(List<Articulos> articulos, List<Stock> stock)>> GetAll();

        Task<Result<List<ArticuloStock>>> GetAllArticuloStock();
        Task<Result<bool>> Add(Articulos articulo, Stock stock);

        Task<Result<bool>> Update(Articulos articulos, Stock stock);

        Task<Result<bool>> Delete(Articulos articulo, Stock stock);
    }
}
