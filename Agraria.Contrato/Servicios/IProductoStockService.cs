using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Contrato.Servicios
{
    public interface IProductoStockService
    {
        Task<Result<(List<Productos> articulos, List<Stock> stock)>> GetAll();

        Task<Result<List<ProductoStock>>> GetAllArticuloStock();
        Task<Result<bool>> Add(Productos articulo, Stock stock);

        Task<Result<bool>> Update(Productos articulos, Stock stock);

        Task<Result<bool>> Delete(Productos articulo, Stock stock);
    }
}
