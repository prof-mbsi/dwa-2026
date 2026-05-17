using Microsoft.AspNetCore.Mvc;
using BackendApi.Models;
using BackendApi.Data;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
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
            Console.WriteLine(produto.Nome);
            _context.Produtos.Add(produto);

            _context.SaveChanges();

            return Ok(produto);
        }
    }
}