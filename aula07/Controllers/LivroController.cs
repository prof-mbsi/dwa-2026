using Microsoft.AspNetCore.Mvc;
using AulaApi.Models;
using AulaApi.Repositories;

namespace AulaApi.Controllers
{
    [ApiController]
    [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repo;

        public LivroController(ILivroRepository repo)
        {
            _repo = repo;
        }

        // GET ALL
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        // GET BY ID (Exercício 1)
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _repo.GetById(id);

            if (livro == null)
                return NotFound("Livro não encontrado");

            return Ok(livro);
        }

        // POST
        [HttpPost]
        public IActionResult Post(Livro livro)
        {
            try
            {
                _repo.Add(livro);
                return Ok(livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT (Exercício 4)
        [HttpPut("{id}")]
        public IActionResult Put(int id, Livro livro)
        {
            livro.Id = id;
            _repo.Update(livro);

            return Ok("Atualizado com sucesso");
        }

        // DELETE (Exercício 2)
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok("Removido com sucesso");
        }
    }
}