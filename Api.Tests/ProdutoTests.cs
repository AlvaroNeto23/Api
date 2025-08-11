using Domain.Entities;
using Infra.Repositories;
using Xunit;

public class ProdutoTests
{
    [Fact]
    public void Nao_Deve_Adicionar_Produto_Duplicado_Na_Mesma_Categoria()
    {
        var repo = new ProdutoRepository();
        var categoriaId = Guid.NewGuid();

        repo.Add(new Produto { Id = Guid.NewGuid(), Nome = "Produto A", CategoriaId = categoriaId });

        Assert.True(repo.ExistsByNameInCategory(categoriaId, "produto a"));
    }

    [Fact]
    public void Deve_Falhar_Se_Preco_Negativo()
    {
        var dto = new Api.Dtos.ProdutoCreateDto
        {
            Nome = "Produto Teste",
            PrecoUnitario = -5,
            CategoriaId = Guid.NewGuid()
        };

        var validator = new Api.Validators.ProdutoCreateValidator();
        var result = validator.Validate(dto);

        Assert.False(result.IsValid);
    }

    [Fact]
    public void Deve_Paginar_Resultados()
    {
        var repo = new ProdutoRepository();
        var categoriaId = Guid.NewGuid();

        for (int i = 1; i <= 15; i++)
            repo.Add(new Produto { Id = Guid.NewGuid(), Nome = $"Prod {i}", CategoriaId = categoriaId });

        var page = repo.GetByCategoria(categoriaId, 2, 5);

        Assert.Equal(5, page.Count());
        Assert.Equal("Prod 6", page.First().Nome);
    }
}
