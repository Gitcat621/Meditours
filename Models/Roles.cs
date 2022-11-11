using System.ComponentModel.DataAnnotations;

namespace Meditours.Models
{
    public class Roles
    {
        [Key]
        public int PkRol { get; set; }
        public string Nombre { get; set; }
    }
}
