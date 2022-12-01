using Microsoft.OData.Edm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meditours.Models
{
    public class Itinerarios
    {
        [Key]
        public int PkItinerario { get; set; }
        public string Dia { get; set; }
        public DateTime HraSalida { get; set; }
        public int Capacidad { get; set; }

        [ForeignKey("Camionetas")]
        public int FkCamioneta { get; set; }
        public Camionetas Camionetas { get; set; }

        [ForeignKey("Destinos")]
        public int FkDestino { get; set; }
        public Destinos Destinos { get; set; }

        [ForeignKey("Paquetes")]
        public int FkPaquete { get; set; }
        public Paquetes Paquetes { get; set; }
    }
}
