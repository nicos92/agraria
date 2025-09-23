using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using System.Threading.Tasks;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IUsuariosRepository
    {
        Task<Result<List<Usuarios>>> GetAll();
        Task<Result<List<Usuarios>>> GetAllActive();
        Task<Result<Usuarios>> GetById(int id);
        Task<Result<Usuarios>> GetByDniAndPassword(string dni, string password);
        Task<Result<Usuarios>> GetByDniAndQuestionAndAnswer(string dni, int preguntaId, string respuesta);
        Result<Usuarios> Add(Usuarios usuario);
        Result<Usuarios> Update(Usuarios usuario);
        Result<bool> Delete(int id);
    }
}
