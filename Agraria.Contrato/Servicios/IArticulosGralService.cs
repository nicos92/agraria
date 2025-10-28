using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agraria.Contrato.Servicios
{
    public interface IArticulosGralService
    {
        Task<Result<List<ArticulosGral>>> GetAll();
        Result<ArticulosGral> GetById(int id);
        Task<Result<ArticulosGral>> Add(ArticulosGral articulo);
        Task<Result<ArticulosGral>> Update(ArticulosGral articulo);
        Result<bool> Delete(int id);
        Task<Result<int>> GetMaxCodArt();
		Task<Result<bool>> UpdateStock(string codigo, decimal cantidad);

	}
}
