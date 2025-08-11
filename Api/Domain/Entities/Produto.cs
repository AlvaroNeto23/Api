namespace Domain.Entities
{    
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
