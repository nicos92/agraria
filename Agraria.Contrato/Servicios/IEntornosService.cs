using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Servicios
{
    public interface IEntornosService
    {
        Task<Result<List<Entornos>>> GetAll();
        Result<Entornos> GetById(int id);
        Result<Entornos> Add(Entornos categoria);
        Result<Entornos> Update(Entornos categoria);
        Result<bool> Delete(int id);
    }
}
