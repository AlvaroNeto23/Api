using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetByCategoria(Guid categoriaId, int page, int size);
        void Add(Produto produto);
        bool ExistsByNameInCategory(Guid categoriaId, string nome);
    }
}
