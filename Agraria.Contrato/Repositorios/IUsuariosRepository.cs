using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;

namespace Agraria.Contrato.Repositorios
{
    public interface IUsuariosRepository
    {
        Task<Result<List<Usuarios>>> GetAll();
        Task<Result<Usuarios>> GetById(int id);
        Result<Usuarios> Add(Usuarios usuario);
        Result<Usuarios> Update(Usuarios usuario);
        Result<bool> Delete(int id);
    }
}
