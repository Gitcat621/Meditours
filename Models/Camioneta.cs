using System.ComponentModel.DataAnnotations;

namespace Meditours.Models
{
    public class Camioneta
    {
        [Key]
        public int PkCamioneta { get; set; }
        public string Modelo { get; set; }
        public int Precio { get; set; }
        public int CantidadMax { get; set; }
    }
}
