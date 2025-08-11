using Api.Dtos;
using FluentValidation;

namespace Api.Validators
{
    public class ProdutoCreateValidator : AbstractValidator<ProdutoCreateDto>
    {
        public ProdutoCreateValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100);

            RuleFor(p => p.PrecoUnitario)
                .GreaterThanOrEqualTo(0).WithMessage("Preço não pode ser negativo.");
        }
    }
}
