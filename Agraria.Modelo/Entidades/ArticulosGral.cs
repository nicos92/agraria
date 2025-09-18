using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraria.Modelo.Entidades
{
    public class ArticulosGral
    {
        public int Art_Id { get; set; }
        public string? Art_Cod { get; set; }
        public string? Art_Nombre { get; set; }
        public string? Art_Uni_Med { get; set; }
        public decimal Art_Precio { get; set; }
        public string? Art_Descripcion { get; set; }
        public int Art_Stock { get; set; }
    }
}