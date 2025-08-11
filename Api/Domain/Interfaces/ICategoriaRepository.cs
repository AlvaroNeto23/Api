using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();
        void Add(Categoria categoria);
    }
}
