using System.ComponentModel.DataAnnotations;

namespace API_Padaria.Models;

/// <summary>
/// Classe que representa um objeto do tipo Doce
/// </summary>
    public class Doce 
    {
        /// <summary>
        /// Obtém ou define o nome de um doce
        /// </summary>
        [Key]
        public string? NomeDoce { get; set; }
        /// <summary>
        /// Obtém ou define o preço de um doce
        /// </summary>
        public string? PreçoDoce { get; set; }
    }