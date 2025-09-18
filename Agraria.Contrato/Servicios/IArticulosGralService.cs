using Agraria.Modelo.Entidades;
using Agraria.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agraria.Contrato.Servicios
{
    public interface IArticulosGralService
    {
        Task<Result<List<ArticulosGral>>> GetAll();
        Result<ArticulosGral> GetById(int id);
        Result<ArticulosGral> Add(ArticulosGral articulo);
        Task<Result<ArticulosGral>> Update(ArticulosGral articulo);
        Result<bool> Delete(int id);
        Task<Result<int>> GetMaxCodArt();
    }
}