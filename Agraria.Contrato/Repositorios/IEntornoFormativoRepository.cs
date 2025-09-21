using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agraria.Contrato.Repositorios
{
    public interface IEntornoFormativoRepository
    {
        Task<Result<List<EntornoFormativo>>> GetAll();
        Result<EntornoFormativo> GetById(int id);
        Result<EntornoFormativo> Add(EntornoFormativo entornoFormativo);
        Task<Result<EntornoFormativo>> Update(EntornoFormativo entornoFormativo);
        Result<bool> Delete(int id);
    }
}
