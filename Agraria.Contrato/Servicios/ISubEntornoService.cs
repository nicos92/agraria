using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Servicios
{
    public interface ISubEntornoService
    {
        Task<Result<List<SubEntornos>>> GetAll();
        Task<Result<List<SubEntornos>>> GetAllxEntorno(int id);
        Result<SubEntornos> GetById(int id);
        Result<SubEntornos> Add(SubEntornos subcategoria);
        Result<SubEntornos> Update(SubEntornos subcategoria);
        Result<bool> Delete(int id);
    }
}
