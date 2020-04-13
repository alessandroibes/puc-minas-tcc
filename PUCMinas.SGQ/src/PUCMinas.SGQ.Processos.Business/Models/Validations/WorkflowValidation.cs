using FluentValidation;

namespace PUCMinas.SGQ.Processos.Business.Models.Validations
{
    public class WorkflowValidation : AbstractValidator<Workflow>
    {
        public WorkflowValidation()
        {
            RuleFor(w => w.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
