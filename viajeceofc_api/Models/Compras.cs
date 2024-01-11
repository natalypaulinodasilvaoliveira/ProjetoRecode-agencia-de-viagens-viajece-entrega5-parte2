using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

    namespace viajeceofc_api.Models
{
        public class Compras
        {
            [Key]
            public int Id { get; set; }
            public string Codigo_Reserva { get; set; }
            public double Valor_Total { get; set; }
            public int ViajanteId { get; set; }
            public Viajantes Viajante { get; set; }
            public int DestinoId { get; set; }
            public Destinos Destino { get; set; }
        }
    }
