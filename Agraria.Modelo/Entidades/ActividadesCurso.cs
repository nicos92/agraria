using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public record ActividadesCurso
    (
        int Id_Actividad,
        string? Curso_anio,
        string? Curso_Division,
        string? Curso_Grupo,
        DateTime Fecha_Actividad,
        string? Descripcion_Actividad
        );

}
