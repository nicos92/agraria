using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Servicios
{
    public interface IEntornoService
    {
        Task<Result<List<Entorno>>> GetAll();
        Task<Result<List<Entorno>>> GetAllxEntorno(int id);
        Result<Entorno> GetById(int id);
        Result<Entorno> Add(Entorno subcategoria);
        Result<Entorno> Update(Entorno subcategoria);
        Result<bool> Delete(int id);
    }
}
