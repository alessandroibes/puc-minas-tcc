using FluentValidation;

namespace PUCMinas.SGQ.Incidentes.Business.Models.Validations
{
    public class AcaoValidation : AbstractValidator<Acao>
    {
        public AcaoValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
