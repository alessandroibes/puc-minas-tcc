using FluentValidation;

namespace PUCMinas.SGQ.Incidentes.Business.Models.Validations
{
    public class CausaValidation : AbstractValidator<Causa>
    {
        public CausaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(10, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
