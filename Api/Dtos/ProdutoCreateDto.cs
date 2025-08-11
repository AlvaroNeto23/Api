namespace Api.Dtos
{
    public class ProdutoCreateDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
