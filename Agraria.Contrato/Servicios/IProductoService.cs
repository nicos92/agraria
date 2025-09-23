using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Servicios
{
    public interface IProductoService
    {
        Task<Result<List<Productos>>> GetAll();
        Result<Productos> GetById(int id);
        Result<Productos> Add(Productos articulo);
        Task<Result<Productos>> Update(Productos articulo);
        Result<bool> Delete(int id);
        Task<Result<int>> GetMaxCodArt();
    }
}
