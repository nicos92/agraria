using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IArticulosGralRepository
    {
        Task<Result<List<ArticulosGral>>> GetAll();
        Result<ArticulosGral> GetById(int id);
        Task<Result<ArticulosGral>> Add(ArticulosGral articulo);
        Task<Result<ArticulosGral>> Update(ArticulosGral articulo);
        Result<bool> Delete(int id);
        Task<Result<int>> GetMaxCodArt();
		Task<Result<bool>> UpdateStock(string id, decimal cantidad);
	}
}
