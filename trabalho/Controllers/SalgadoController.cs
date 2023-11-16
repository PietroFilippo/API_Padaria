using Microsoft.AspNetCore.Mvc;
using API_Padaria.Models;
using API_Padaria.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging.Abstractions;

namespace API_Padaria.Controllers;

    /// <summary>
    /// Controller para operações que envolvem Salgado
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SalgadoController : ControllerBase
    {
        private PadariaDbContext _context;
        /// <summary>
        /// Inicializa uma nova instância do controller SalgadoController
        /// </summary>
        public SalgadoController(PadariaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Mostra a lista de todos os salgados
        /// </summary>
        /// <returns>Uma lista de salgados</returns>
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Salgado>>> Listar()
        {
            if(_context is null) return NotFound();
            if(_context.Salgado is null) return NotFound();
            return await _context.Salgado.ToListAsync();
        }

        /// <summary>
        /// Busca um salgado pelo nome
        /// </summary>
        /// <param name="nomesalgado">O nome do salgado que quer ser buscado</param>
        /// <returns>Retorna um salgado com o nome fornecido</returns>
        [HttpGet()]
        [Route("buscar/{nomesalgado}")]
        public async Task<ActionResult<Salgado>> Buscar(string nomesalgado)
        {
            if(_context is null) return NotFound();
            if(_context.Salgado is null) return NotFound();
            var salgadoTemp = await _context.Salgado.FindAsync(nomesalgado);
            if (salgadoTemp is null) return NotFound();
            return salgadoTemp;
        }

        /// <summary>
        /// Cadastra um novo salgado
        /// </summary>
        /// <param name="salgado">O algado que quer ser cadastrado</param>
        /// <returns>Cadastro do salgado</returns>
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Salgado salgado)
        {
            if(_context is null) return NotFound();
            if(_context.Salgado is null) return NotFound();
            await _context.AddAsync(salgado);
            await _context.SaveChangesAsync();
            return Created("", salgado);
        }

        /// <summary>
        /// Atualiza um salgado já existente pelo nome
        /// </summary>
        /// <param name="nomesalgado">O nome do salgado para ser atualizado</param>
        /// <param name="novoSalgado">O novo salgado com informações novas atualizadas</param>
        /// <returns>Retorna um novo salgado atualizado.</returns>
        [HttpPut]
        [Route("atualizar/{nomesalgado}")]
        public async Task<ActionResult> Atualizar(string nomesalgado, Salgado novoSalgado)
        {
            if (_context is null) return NotFound();
            if (_context.Salgado is null) return NotFound();
            var salgadoTemp = await _context.Salgado.FindAsync(nomesalgado);
            if (salgadoTemp is null) return NotFound();
            salgadoTemp.PreçoSalgado = novoSalgado.PreçoSalgado;
            var novoNome = novoSalgado.NomeSalgado;
            var novoSalgadoAtualizado = new Salgado
            {
                NomeSalgado = novoNome,
                PreçoSalgado = salgadoTemp.PreçoSalgado
            };
            _context.Salgado.Remove(salgadoTemp);
            _context.Salgado.Add(novoSalgadoAtualizado);
            await _context.SaveChangesAsync();
            return Ok();
        }       
    }   

