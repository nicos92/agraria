using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Servicios
{
    public interface ITipoEntornosService
    {
        Task<Result<List<TipoEntorno>>> GetAll();
        Result<TipoEntorno> GetById(int id);
        Result<TipoEntorno> Add(TipoEntorno categoria);
        Result<TipoEntorno> Update(TipoEntorno categoria);
        Result<bool> Delete(int id);
    }
}
