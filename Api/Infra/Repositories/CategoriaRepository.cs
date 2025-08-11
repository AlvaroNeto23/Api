using Domain.Entities;
using Domain.Interfaces;

namespace Api.Infra.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly List<Categoria> _categorias = new();

        public IEnumerable<Categoria> GetAll() => _categorias;

        public void Add(Categoria categoria)
        {
            _categorias.Add(categoria);
        }
    }
}
