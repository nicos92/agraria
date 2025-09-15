using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Servicios
{
    public interface ISubcategoriaService
    {
        Task<Result<List<Subcategoria>>> GetAll();
        Task<Result<List<Subcategoria>>> GetAllxCategoria(int id);
        Result<Subcategoria> GetById(int id);
        Result<Subcategoria> Add(Subcategoria subcategoria);
        Result<Subcategoria> Update(Subcategoria subcategoria);
        Result<bool> Delete(int id);
    }
}
