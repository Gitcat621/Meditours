using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meditours.Models
{
    public class Carrito
    {
        [Key]
        public int PkCarrito { get; set; }
        public string Cliente { get; set; }

        [ForeignKey("usuario")]
        public int FkUsuario { get; set; }
        public usuario usuario { get; set; }

        [ForeignKey("Camioneta")]
        public int FkCamioneta { get; set; }
        public Camioneta Camioneta { get; set; }
        public string ModeloCamioneta { get; set; }

        [ForeignKey("Metodo_pago")]
        public int FkMetodo_pago { get; set; }
        public Metodo_pago metodo_Pago { get; set; }
        public string Metodo_pago { get; set; }
        public int Precio_Final { get; set; }

    }
}
