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
    public class FornecedorController : ControllerBase
    {
        private PadariaDbContext _context;
        public FornecedorController(PadariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> Listar()
        {
            if (_context.Fornecedores is null)
                return NotFound();
            return await _context.Fornecedores.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Fornecedor>> Buscar([FromRoute] int id)
        {
            if (_context.Fornecedores is null)
                return NotFound();
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor is null)
                return NotFound();
            return fornecedor;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Fornecedor fornecedor)
        {
            await _context.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
            return Created("", fornecedor);
        }

        [HttpPut()]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Fornecedor fornecedor)
        {

            if (fornecedor == null)
            {
                return BadRequest("Dados inseridos do fornecedor s�o inv�lidos.");
            }
            if (_context.Fornecedores == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            var fornecedorExistente = await _context.Fornecedores.FindAsync(fornecedor.Id);

            if (fornecedorExistente == null)
            {
                return NotFound("Fornecedor n�o foi encontrado.");
            }

            fornecedorExistente.TipoDeCarga = fornecedor.TipoDeCarga;

            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            if (_context.Fornecedores == null)
            {
                return BadRequest("Dados inseridos da avalia��o s�o inv�lidos.");
            }
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound("N�o foi poss�vel encontrar o fornecedor.");
            }
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return Ok("Fornecedor exclu�do com sucesso.");
        }
    }
