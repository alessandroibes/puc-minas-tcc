using FluentValidation;

namespace PUCMinas.SGQ.Incidentes.Business.Models.Validations
{
    public class RNCValidation : AbstractValidator<RNC>
    {
        public RNCValidation()
        {
            RuleFor(i => i.Ocorrencia)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(i => i.Descricao)
                .Length(5, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
