using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_sistema.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private DataContext dc;

        public ProdutoController(DataContext context) {
            dc = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> cadastrar([FromBody] Produto p) {
            dc.produto.Add(p);
            await dc.SaveChangesAsync();

            return Created("produto", p);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> excluir(int id)
        {
            var produto = await dc.produto.FindAsync(id);
        
            dc.produto.Remove(produto);
            await dc.SaveChangesAsync();
        
            return NoContent();
        }

        [HttpGet("api")]
        public async Task<ActionResult> listar() {
            var dados = await dc.produto.ToListAsync();
            return Ok(dados);
        }
    }
}