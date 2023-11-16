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
    public class PedidoController : ControllerBase
    {
        private PadariaDbContext _context;

        public PedidoController(PadariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Pedido>>> Listar()
        {
            if (_context is null || _context.Pedidos is null) return NotFound();
            return await _context.Pedidos.ToListAsync();
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Pedido>> Buscar([FromRoute] int id)
        {
            if (_context is null || _context.Pedidos is null) return NotFound();
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido is null)
                return NotFound();
            return pedido;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<IActionResult> Cadastrar(Pedido pedido)
        {
            if (_context is null || _context.Pedidos is null) return NotFound();
            
            if (string.IsNullOrEmpty(pedido.NomePedido))
            {
                return BadRequest("O campo NomePedido é obrigatório.");
            }
            
            await _context.AddAsync(pedido);
            await _context.SaveChangesAsync();
            return Created("", pedido);
        }

        [HttpPut]
        [Route("atualizar/{id}")]
        public async Task<IActionResult> Atualizar(int id, Pedido novoPedido)
        {
            if (_context is null || _context.Pedidos is null) return NotFound();

            var pedidoExistente = await _context.Pedidos.FindAsync(id);
            if (pedidoExistente is null)
                return NotFound();

            pedidoExistente.DataPedido = novoPedido.DataPedido;
            pedidoExistente.Status = novoPedido.Status;
            pedidoExistente.ClienteId = novoPedido.ClienteId;
            pedidoExistente.NomePedido = novoPedido.NomePedido; 

            _context.Pedidos.Update(pedidoExistente);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            if (_context is null || _context.Pedidos is null) return NotFound();

            var pedidoExistente = await _context.Pedidos.FindAsync(id);
            if (pedidoExistente is null)
                return NotFound();

            _context.Pedidos.Remove(pedidoExistente);
            await _context.SaveChangesAsync();

            return NoContent(); 
        }
    }
}
