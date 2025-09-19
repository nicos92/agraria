using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;

namespace Agraria.Contrato.Repositorios
{
    public interface IUsuariosTipoRepository
    {
        Task<Result<List<UsuariosTipo>>> GetAll();
        Result<UsuariosTipo> GetById(int id);
        Result<UsuariosTipo> Add(UsuariosTipo tipo);
        Result<UsuariosTipo> Update(UsuariosTipo tipo);
        Result<bool> Delete(int id);
    }
}
