using System.Collections.Generic;
using Agraria.Modelo.Entidades;
using Agraria.Utilidades;
using System.Threading.Tasks;
using Agraria.Modelo.Records;

namespace Agraria.Contrato.Servicios
{
    public interface IActividadService
    {
        Task<Result<List<Actividad>>> GetAll();
        Task<Result<List<ActividadesCurso>>> GetTopDiez();
        Task<Result<List<ActividadConNombres>>> GetAllConNombres();

        Result<Actividad> GetById(int id);
        Task<Result<Actividad>> Add(Actividad actividad);
        Task<Result<Actividad>> Update(Actividad actividad);
        Result<bool> Delete(int id);
        Task<Result<List<Actividad>>> GetAllByEntorno(int idEntorno);
        Task<Result<List<Actividad>>> GetAllByTipoEntorno(int idTipoEntorno);
        Task<Result<List<Actividad>>> GetByFechaRango(DateTime fechaInicio, DateTime fechaFin);
    }
}