using FluentValidation;

namespace PUCMinas.SGQ.Processos.Business.Models.Validations
{
    public class WorkflowDefinicaoValidation : AbstractValidator<WorkflowDefinicao>
    {
        public WorkflowDefinicaoValidation()
        {
            RuleFor(w => w.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(w => w.EngenherioCriadorId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
