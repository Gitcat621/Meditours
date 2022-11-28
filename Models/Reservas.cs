using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meditours.Models
{
    public class Reservas
    {
        [Key]
        public int PkReserva { get; set; }
        public int HraSalida { get; set; }

        [ForeignKey("Usuarios")]
        public int FkUsuario { get; set; }
        public Usuarios Usuarios { get; set; }
        [ForeignKey("Destinos")]
        public int FkDestino { get; set; }
        public Destinos Destinos { get; set; }

        [ForeignKey("Camionetas")]
        public int FkCamioneta { get; set; }
        public Camionetas Camionetas { get; set; }
        public string Dia { get; set; }

    }
}
