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
    public class AvaliacaoController : ControllerBase
    {
        private PadariaDbContext _context;

        public AvaliacaoController(PadariaDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> Listar()
        {
            if (_context.Avaliacoes == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            var avaliacoes = await _context.Avaliacoes.ToListAsync();
            if (avaliacoes == null || avaliacoes.Count == 0)
            {
                return NotFound("N�o foi poss�vel encontrar nenhuma avalia��o.");
            }
            return Ok(avaliacoes);
        }


        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Avaliacao avaliacao)
        {
            if (avaliacao == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            await _context.AddAsync(avaliacao);
            await _context.SaveChangesAsync();
            return Created("", avaliacao);
        }



        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Avaliacao>> Buscar([FromRoute] int id)
        {   
            if (_context.Avaliacoes == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound("N�o foi poss�vel encontrar a sua avalia��o.");
            }
            return Ok(avaliacao);
        }


        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Avaliacao avaliacao)
        {
            if (avaliacao == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            if (_context.Avaliacoes == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            var avaliacaoExistente = await _context.Avaliacoes.FindAsync(avaliacao.Id);

            if (avaliacaoExistente == null)
            {
                return NotFound("Avalia��o n�o foi encontrada.");
            }

            avaliacaoExistente.Nota = avaliacao.Nota;

            _context.Avaliacoes.Update(avaliacao);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_context.Avaliacoes == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                return NotFound("N�o foi poss�vel encontrar a sua avalia��o.");
            }
            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
            return Ok("Avalia��o desejada para exclus�o, fora exclu�da com sucesso.");
        }
    }