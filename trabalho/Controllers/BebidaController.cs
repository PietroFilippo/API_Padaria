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
    public class BebidaController : ControllerBase
    {
        private PadariaDbContext _context;
        public BebidaController(PadariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Bebida>>> Listar()
        {
            if (_context is null) return NotFound();
            if (_context.Bebida is null) return NotFound();
            return await _context.Bebida.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{nomebebida}")]
        public async Task<ActionResult<Bebida>> Buscar(string nomebebida)
        {
            if (_context is null) return NotFound();
            if (_context.Bebida is null) return NotFound();
            var bebidaTemp = await _context.Bebida.FindAsync(nomebebida);
            if (bebidaTemp is null) return NotFound();
            return bebidaTemp;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Bebida bebida)
        {
            if (_context is null) return NotFound();
            if (_context.Bebida is null) return NotFound();
            await _context.AddAsync(bebida);
            await _context.SaveChangesAsync();
            return Created("", bebida);
        }

        [HttpPut()]
        [Route("alterar/{nomebebida}")]
        public async Task<ActionResult> Alterar(string nomebebida, Bebida novaBebida)
        {
            if (_context is null) return NotFound();
            if (_context.Bebida is null) return NotFound();
            var bebidaTemp = await _context.Bebida.FindAsync(nomebebida);
            if (bebidaTemp is null) return NotFound();
            bebidaTemp.PrecoBebida = novaBebida.PrecoBebida;
            var novoNome = novaBebida.NomeBebida;
            var novaBebidaAtualizada = new Bebida
            {
                NomeBebida = novoNome,
                PrecoBebida = bebidaTemp.PrecoBebida
            };
            _context.Bebida.Remove(bebidaTemp);
            _context.Bebida.Add(novaBebidaAtualizada);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_context is null)
            {
                return NotFound("O contexto n�o est� dispon�vel.");
            }
            if (_context.Bebida is null)
            {
                return NotFound("O contexto n�o est� dispon�vel.");
            }
            var bebidaTemp = await _context.Bebida.FindAsync(id);
            if (bebidaTemp is null)
            {
                return NotFound("Bebida n�o encontrada.");
            }

            _context.Bebida.Remove(bebidaTemp);
            await _context.SaveChangesAsync();
            return Ok("Bebida exclu�da com sucesso.");
        }
    }
