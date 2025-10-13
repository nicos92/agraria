using System;

namespace Agraria.Modelo.Records
{
    public record EntornoFormativoConNombres(
        int Id_Entorno_Formativo,
        string Nombre_Entorno,
        string Nombre_Usuario,
        string Apellido_Usuario,
        string Curso_anio,
        string Curso_Division,
        string Curso_Grupo,
        string Observaciones,
        bool Activo
    );
}