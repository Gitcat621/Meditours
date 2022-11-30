using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meditours.Models
{
    public class Reservas
    {
        [Key]
        public int PkReserva { get; set; }

        [ForeignKey("Usuarios")]
        public int FkUsuario { get; set; }
        public Usuarios Usuarios { get; set; }

        [ForeignKey("Itinerarios")]    
        public int FkItinerario { get; set; }
        public Itinerarios Itinerarios { get; set; }

        [ForeignKey("Destinos")]
        public int FkDestino { get; set; }
        public Destinos Destinos { get; set; }

    }
}
