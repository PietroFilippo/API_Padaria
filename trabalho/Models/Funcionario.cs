using System.ComponentModel.DataAnnotations;

public class Funcionario
{
    public int Id { get; set; }

    [Required]
    public int Cargo { get; set; }

    [StringLength(50)]
    public string? Salario { get; set; }
}
