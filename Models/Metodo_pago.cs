using System.ComponentModel.DataAnnotations;

namespace Meditours.Models
{
    public class Metodo_pago
    {
        [Key]
        public int PkMetodo { get; set; }
        public string Nombre { get; set; }
    }
}
