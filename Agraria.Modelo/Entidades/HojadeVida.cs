
using Agraria.Modelo.Enums;

namespace Agraria.Modelo.Entidades
{
    public class HojadeVida
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public TipoAnimal TipoAnimal { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Peso { get; set; }
        public string? EstadoSalud { get; set; }
        public string? Observaciones { get; set; }
        public bool Activo { get; set; }
    }
}