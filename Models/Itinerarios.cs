using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meditours.Models
{
    public class Itinerarios
    {
        [Key]
        public int PkItinerario { get; set; }
        public int HraSalida { get; set; }
        public int Capacidad { get; set; }
        public int Precio { get; set; }

        [ForeignKey("Camionetas")]
        public int FkCamioneta { get; set; }
        public Camionetas Camionetas { get; set; }
    }
}
