using Microsoft.AspNetCore.Mvc;
using API_Padaria.Models;
using API_Padaria.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLitePCL;

namespace API_Padaria.Controllers;

    /// <summary>
    /// Controller para operações que envolvem Doce
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DoceController : ControllerBase
    {
        private PadariaDbContext _context;
        /// <summary>
        /// Inicializa uma nova instância do controller DoceController
        /// </summary>
        public DoceController(PadariaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Mostra uma lista de todos os doces
        /// </summary>
        /// <returns>Uma lista de doces</returns>
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Doce>>> Listar()
        {
            if (_context is null) return NotFound();
            if (_context.Doce is null) return NotFound();
            return await _context.Doce.ToListAsync();
        }

        /// <summary>
        /// Busca um doce pelo nome
        /// </summary>
        /// <param name="nomedoce">O nome do doce que quer ser buscado</param>
        /// <returns>Retorna um doce com o nome fornecido</returns>
        [HttpGet]
        [Route("buscar/{nomedoce}")]
        public async Task<ActionResult<Doce>> Buscar(string nomedoce)
        {
            if (_context is null) return NotFound();
            if (_context.Doce is null) return NotFound();
            var doceTemp = await _context.Doce.FindAsync(nomedoce);
            if (doceTemp is null) return NotFound();
            return doceTemp;
        }

        /// <summary>
        /// Cadastra um novo doce
        /// </summary>
        /// <param name="doce">O doce que quer ser cadastrado</param>
        /// <returns>Cadastro do doce</returns>
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult> Cadastrar(Doce doce)
        {
            if (_context is null)return NotFound();
            if (_context.Doce is null) return NotFound();
            await _context.AddAsync(doce);
            await _context.SaveChangesAsync();
            return Created("", doce);
        }

        /// <summary>
        /// Atualiza um doce já existente pelo nome
        /// </summary>
        /// <param name="nomedoce">O nome do doce para ser atualizado</param>
        /// <param name="novoDoce">O novo doce com informações novas atualizadas</param>
        /// <returns>Retorna um novo doce atualizado.</returns>
        [HttpPut]
        [Route("atualizar/{nomedoce}")]
        public async Task<ActionResult> Atualizar(string nomedoce, Doce novoDoce)
        {
            if (_context is null) return NotFound();
            if (_context.Doce is null) return NotFound();
            var doceTemp = await _context.Doce.FindAsync(nomedoce);
            if (doceTemp is null) return NotFound();
            doceTemp.PreçoDoce = novoDoce.PreçoDoce;
            var novoNome = novoDoce.NomeDoce;
            var novoDoceAtualizado = new Doce
            {
                NomeDoce = novoNome,
                PreçoDoce = doceTemp.PreçoDoce
            };
            _context.Doce.Remove(doceTemp);
            _context.Doce.Add(novoDoceAtualizado);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }   