using System.ComponentModel.DataAnnotations;

namespace API_Padaria.Models;

/// <summary>
/// Classe que representa um objeto do tipo Salgado
/// </summary>
    public class Salgado
    {
        /// <summary>
        /// Obtém ou define o nome de um salgado
        /// </summary>
        [Key]
        public string? NomeSalgado { get; set; }
        /// <summary>
        /// Obtém ou define o preço de um salgado
        /// </summary>
        public string? PreçoSalgado { get; set; }
    }
