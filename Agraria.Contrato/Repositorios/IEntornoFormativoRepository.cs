using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using Agraria.Modelo.Records;

namespace Agraria.Contrato.Repositorios
{
    public interface IEntornoFormativoRepository
    {
        Task<Result<List<EntornoFormativo>>> GetAll();
        Task<Result<List<EntornoFormativo>>> GetAllByIdEntorno(int idEntorno);
        Task<Result<List<EntornoFormativoConNombres>>> GetAllConNombres();
        Result<EntornoFormativo> GetById(int id);
        Result<EntornoFormativo> Add(EntornoFormativo entornoFormativo);
        Task<Result<EntornoFormativo>> Update(EntornoFormativo entornoFormativo);
        Result<bool> Delete(int id);
    }
}
