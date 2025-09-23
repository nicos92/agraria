using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IArticulosRepository
    {
        Task<Result<List<Productos>>> GetAll();
        Result<Productos> GetById(int id);
        Result<Productos> Add(Productos producto);
        Task<Result<Productos>> Update(Productos producto);
        Result<bool> Delete(int id);
        Task<Result<int>> GetMaxCodArt();
    }
}
