using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface ISubcategoriaRepository
    {
        Task<Result<List<SubEntornos>>> GetAll();
        Task<Result<List<SubEntornos>>> GetAllxCategoria(int id);
        Result<SubEntornos> GetById(int id);
        Result<SubEntornos> Add(SubEntornos subcategoria);
        Result<SubEntornos> Update(SubEntornos subcategoria);
        Result<bool> Delete(int id);
    }
}
