using System.ComponentModel.DataAnnotations;

namespace API_Padaria.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }

        [Required]
        public string? TipoDeCarga { get; set; }

        public bool Localizacao { get; set; }
    }
}
