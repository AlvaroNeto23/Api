using Api.Dtos;
using FluentValidation;

namespace Api.Validators
{
    public class CategoriaCreateValidator : AbstractValidator<CategoriaCreateDto>
    {
        public CategoriaCreateValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(50);
        }
    }
}
