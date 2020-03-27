using FluentValidation;

namespace PUCMinas.SGQ.Processos.Business.Models.Validations
{
    public class AtividadeValidation : AbstractValidator<Atividade>
    {
        public AtividadeValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(a => a.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(10, 1000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
