using System.ComponentModel.DataAnnotations;

namespace Meditours.Models
{
    public class Paquetes
    {
        [Key]
        public int PkPaquete { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Urlimg { get; set; }
    }
}
