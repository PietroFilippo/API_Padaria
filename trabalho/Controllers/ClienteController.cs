///CHATGPT
using Microsoft.AspNetCore.Mvc;
using API_Padaria.Models;
using API_Padaria.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLitePCL;

namespace API_Padaria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private PadariaDbContext _context;

        public ClienteController(PadariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            if (_context is null || _context.Clientes is null) return NotFound();
            return await _context.Clientes.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Cliente>> Buscar([FromRoute] int id)
        {
            if (_context is null || _context.Clientes is null) return NotFound();
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null)
                return NotFound();
            return cliente;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Cliente cliente)
        {
            if (_context is null || _context.Clientes is null) return NotFound();
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return Created("", cliente);
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Cliente novoCliente)
        {
            if (_context is null || _context.Clientes is null) return NotFound();

            var clienteExistente = await _context.Clientes.FindAsync(id);
            if (clienteExistente is null)
                return NotFound();

            clienteExistente.Nome = novoCliente.Nome;
            clienteExistente.Endereco = novoCliente.Endereco;
            clienteExistente.Telefone = novoCliente.Telefone;

            _context.Clientes.Update(clienteExistente);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            if (_context is null || _context.Clientes is null) return NotFound();

            var clienteExistente = await _context.Clientes.FindAsync(id);
            if (clienteExistente is null)
                return NotFound();

            _context.Clientes.Remove(clienteExistente);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}