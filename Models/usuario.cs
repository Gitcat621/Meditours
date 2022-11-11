using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meditours.Models
{
    public class usuario
    {
        [Key]
        public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string User { get; set; }
        public string password { get; set; }
        
        [ForeignKey("Roles")]
        public int FkRol { get; set; }
        public Roles Roles { get; set; }
    }
}
