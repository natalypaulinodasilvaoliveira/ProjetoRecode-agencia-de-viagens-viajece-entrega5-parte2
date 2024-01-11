using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace viajeceofc_api.Models
{
    public class Viajantes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [JsonIgnore]
        public List<Compras> Compras { get; set; }
    }
}
