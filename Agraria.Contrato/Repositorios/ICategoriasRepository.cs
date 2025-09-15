using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Repositorios
{
    public interface ICategoriasRepository
    {
        Task<Result<List<Categorias>>> GetAll();
        Result<Categorias> GetById(int id);
        Result<Categorias> Add(Categorias categoria);
        Result<Categorias> Update(Categorias categoria);
        Result<bool> Delete(int id);
    }
}
