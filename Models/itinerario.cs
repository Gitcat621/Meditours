using System.ComponentModel.DataAnnotations;

namespace Meditours.Models
{
    public class itinerario
    {
        [Key]
        public int PkItinerario { get; set; }
        public string lugar { get; set; }
        public int tiempo { get; set;}
        public string precio { get; set; }
    }
}
