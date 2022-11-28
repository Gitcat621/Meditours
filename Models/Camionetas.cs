using System.ComponentModel.DataAnnotations;

namespace Meditours.Models
{
    public class Camionetas
    {
        [Key]
        public int PkCamioneta { get; set; }
        public string Modelo { get; set; }
        public int Capacidad { get; set; }
        public string Urlimg { get; set; }
    }
}
