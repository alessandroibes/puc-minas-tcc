using FluentValidation;

namespace PUCMinas.SGQ.Processos.Business.Models.Validations
{
    public class ParadaValidation : AbstractValidator<Parada>
    {
        public ParadaValidation()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(10, 1000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(p => p.OperadorId)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(p => p.IncidenteCadastrado)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
