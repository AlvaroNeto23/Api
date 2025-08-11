using Api.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepo;

        public ProdutosController(IProdutoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }

        [HttpGet]
        public IActionResult GetByCategoria(Guid categoriaId, int page = 1, int size = 10)
        {
            return Ok(_produtoRepo.GetByCategoria(categoriaId, page, size));
        }

        [HttpPost]
        public IActionResult Create(ProdutoCreateDto dto)
        {
            if (_produtoRepo.ExistsByNameInCategory(dto.CategoriaId, dto.Nome))
                return BadRequest("Já existe um produto com este nome nesta categoria.");

            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                PrecoUnitario = dto.PrecoUnitario,
                CategoriaId = dto.CategoriaId
            };

            _produtoRepo.Add(produto);
            return CreatedAtAction(nameof(GetByCategoria), new { categoriaId = dto.CategoriaId }, produto);
        }
    }
}
