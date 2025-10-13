using System;

namespace Agraria.Modelo.Records
{
    public record UsuarioConTipo(
        string DNI,
        string Nombre,
        string Apellido,
        string Tel,
        string Mail,
        string Nombre_Tipo
    );
}