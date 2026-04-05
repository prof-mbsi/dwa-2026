using Microsoft.AspNetCore.Mvc;
using AulaApi.Models;

namespace AulaApi.Controllers
{
    [ApiController]
    [Route("api/pessoas")]
    public class PessoaController : ControllerBase
    {
        private static List<Pessoa> pessoas = new();


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(pessoas);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa pessoa)
        {
            pessoas.Add(pessoa);
            return Ok(pessoa);
        }
    }
}