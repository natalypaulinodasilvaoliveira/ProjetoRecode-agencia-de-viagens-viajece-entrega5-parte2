using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

    namespace viajeceofc_api.Models
{
        public class Destinos
        {
            [Key]
            public int Id { get; set; }
            public string Data_Entrada { get; set; }
            public string Data_Saida { get; set; }
            public double Valor_Compra { get; set; }
            [JsonIgnore]
            public List<Compras> Compras { get; set; }
        }
    }
