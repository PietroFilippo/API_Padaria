///CHATGPT
using System.ComponentModel.DataAnnotations;

namespace API_Padaria.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataPedido { get; set; }

        [Required]
        public string? NomePedido { get; set; }
        public string? Status { get; set; }

        public int ClienteId { get; set; }
    }
}