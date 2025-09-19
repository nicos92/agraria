using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using System.Threading.Tasks;
using Agraria.Utilidades;

namespace Agraria.Contrato.Servicios
{
    public interface IPreguntasSeguridadService
    {
        Task<Result<List<PreguntasSeguridad>>> GetAll();
        Task<Result<PreguntasSeguridad>> GetById(int id);
        Result<PreguntasSeguridad> Add(PreguntasSeguridad pregunta);
        Result<PreguntasSeguridad> Update(PreguntasSeguridad pregunta);
        Result<bool> Delete(int id);
    }
}