using System.ComponentModel.DataAnnotations;

public class Avaliacao
{
    public int Id { get; set; }

    [Required]
    public int Nota { get; set; }

    [StringLength(500)]
    public string? Comentario { get; set; }
}
