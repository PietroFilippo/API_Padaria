///CHATGPT
using System.ComponentModel.DataAnnotations;

namespace API_Padaria.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nome { get; set; }

        public string? Endereco { get; set; }

        public string? Telefone { get; set; }

    }
}