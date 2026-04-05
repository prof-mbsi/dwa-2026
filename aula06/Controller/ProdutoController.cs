using Microsoft.AspNetCore.Mvc;
using AulaApi.Models;
using AulaApi.Data;

namespace AulaApi.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        /*
        private static List<Produto> produtos = new();
        private static int idProduto = 1;


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            produto.Id = idProduto++;
            produtos.Add(produto);
            return Ok(produto);
        }
        */
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Produtos.ToList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}