using API_Padaria.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Padaria.Data;
public class PadariaDbContext : DbContext
{
    public DbSet<Bebida>? Bebida { get; set; }
    public DbSet<Avaliacao>? Avaliacoes { get; set; }

    public DbSet<Funcionario>? Funcionarios { get; set; }
    public DbSet<Fornecedor>? Fornecedores { get; set; }
    /// <summary>
    /// Obtém ou define um conjunto de entidades para Salgado na base de dados.
    /// </summary>
    public DbSet<Salgado>? Salgado { get; set;}
    /// <summary>
    /// Obtém ou define um conjunto de entidades para Doce na base de dados.
    /// </summary>
    public DbSet<Doce>? Doce { get; set;}
     
    //Chatgpt começo
    public DbSet<Cliente>? Clientes { get; set; }
    public DbSet<Pedido>? Pedidos { get; set; }
    //Chatgpt fim
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    optionsBuilder.UseSqlite("DataSource=padaria.db;Cache=Shared");
    }
    
}

