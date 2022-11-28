using System.ComponentModel.DataAnnotations;

namespace Meditours.Models
{
    public class Destinos
    {
        [Key]
        public int PkDestino { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public string Urlimg { get; set; }
    }
}
