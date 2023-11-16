using System.ComponentModel.DataAnnotations;

namespace API_Padaria.Models;

public class Bebida
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string? NomeBebida { get; set; }
    [Required]
    public string? PrecoBebida { get; set; }
}