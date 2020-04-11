using FluentValidation;

namespace PUCMinas.SGQ.Processos.Business.Models.Validations
{
    public class PassoValidation : AbstractValidator<Passo>
    {
        public PassoValidation()
        {
            RuleFor(p => p.WorflowId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Iniciado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.Finalizado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }        
    }
}
