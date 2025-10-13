using System;

namespace Agraria.Modelo.Records
{
    public record ActividadConNombres(
        int Id_Actividad,
        string Nombre_TipoEntorno,
        string Nombre_Entorno,
        int Id_EntornoFormativo,
        DateTime Fecha_Actividad,
        string Descripcion_Actividad
    );
}