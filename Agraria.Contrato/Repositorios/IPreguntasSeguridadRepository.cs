using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Util;
using System.Threading.Tasks;

namespace Agraria.Contrato.Repositorios
{
    public interface IPreguntasSeguridadRepository
    {
        Task<Result<List<PreguntasSeguridad>>> GetAll();
        Task<Result<PreguntasSeguridad>> GetById(int id);
        Result<PreguntasSeguridad> Add(PreguntasSeguridad pregunta);
        Result<PreguntasSeguridad> Update(PreguntasSeguridad pregunta);
        Result<bool> Delete(int id);
    }
}