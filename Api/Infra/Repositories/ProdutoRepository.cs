using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly List<Produto> _produtos = new();

        public IEnumerable<Produto> GetByCategoria(Guid categoriaId, int page, int size)
        {
            return _produtos
                .Where(p => p.CategoriaId == categoriaId)
                .Skip((page - 1) * size)
                .Take(size);
        }

        public void Add(Produto produto)
        {
            _produtos.Add(produto);
        }

        public bool ExistsByNameInCategory(Guid categoriaId, string nome)
        {
            return _produtos.Any(p =>
                p.CategoriaId == categoriaId &&
                p.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }
}
