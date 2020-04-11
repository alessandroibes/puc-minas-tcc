using FluentValidation;

namespace PUCMinas.SGQ.Processos.Business.Models.Validations
{
    public class PassoDefinicaoValidation : AbstractValidator<PassoDefinicao>
    {
        public PassoDefinicaoValidation()
        {
            RuleFor(p => p.WorkflowDefinicaoId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Titulo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(10, 1000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
