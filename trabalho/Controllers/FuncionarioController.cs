using Microsoft.AspNetCore.Mvc;
using API_Padaria.Models;
using API_Padaria.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLitePCL;

namespace API_Padaria.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private PadariaDbContext _context;
    public FuncionarioController(PadariaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
    {
        if (_context.Funcionarios is null)
            return NotFound();
        return await _context.Funcionarios.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Funcionario>> Buscar([FromRoute] int id)
    {
        if (_context.Funcionarios is null)
            return NotFound();
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario is null)
            return NotFound();
        return funcionario;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Funcionario funcionario)
    {
        await _context.AddAsync(funcionario);
        await _context.SaveChangesAsync();
        return Created("", funcionario);
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        if (funcionario == null)
        {
            return BadRequest("Dados inseridos do funcionario s�o inv�lidos.");
        }
        if (_context.Funcionarios == null)
        {
            return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
        }
        var funcionarioExistente = await _context.Funcionarios.FindAsync(funcionario.Id);

        if (funcionarioExistente == null)
        {
            return NotFound("Funcionario n�o foi encontrado.");
        }

        funcionarioExistente.Cargo = funcionario.Cargo;

        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
        return Ok();
    }
    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        if (_context.Funcionarios == null)
        {
            return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
        }
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario == null)
        {
            return NotFound("N�o foi poss�vel encontraro funcion�rio.");
        }
        _context.Funcionarios.Remove(funcionario);
        await _context.SaveChangesAsync();
        return Ok("Funcion�rio exlu�do com sucesso.");
    }
}
