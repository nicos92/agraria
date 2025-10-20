using System.Collections.Generic;
using Agraria.Contrato.Repositorios;
using Agraria.Modelo.Entidades;
using Agraria.Modelo.Records;
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
        Task<Result<List<ProductosMasVendidos>>> GetArticulosMasVendidos(int v);
    }
}
