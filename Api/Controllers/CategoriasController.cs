using Api.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepo;

        public CategoriasController(ICategoriaRepository categoriaRepo)
        {
            _categoriaRepo = categoriaRepo;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_categoriaRepo.GetAll());

        [HttpPost]
        public IActionResult Create(CategoriaCreateDto dto)
        {
            var categoria = new Categoria
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome
            };

            _categoriaRepo.Add(categoria);
            return CreatedAtAction(nameof(GetAll), categoria);
        }
    }
}
