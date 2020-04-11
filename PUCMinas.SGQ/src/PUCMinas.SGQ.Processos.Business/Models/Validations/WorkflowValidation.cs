using FluentValidation;

namespace PUCMinas.SGQ.Processos.Business.Models.Validations
{
    public class WorkflowValidation : AbstractValidator<Workflow>
    {
        public WorkflowValidation()
        {
            RuleFor(p => p.Iniciado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Finalizado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
