using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using Agraria.Modelo.Records;

namespace Agraria.Contrato.Repositorios
{
    public interface ITipoEntornoRepository
    {
        Task<Result<List<TipoEntorno>>> GetAll();
        Task<Result<List<TipoEntornoConNombre>>> GetAllConNombres();
        Result<TipoEntorno> GetById(int id);
        Result<TipoEntorno> Add(TipoEntorno categoria);
        Result<TipoEntorno> Update(TipoEntorno categoria);
        Result<bool> Delete(int id);
    }
}
