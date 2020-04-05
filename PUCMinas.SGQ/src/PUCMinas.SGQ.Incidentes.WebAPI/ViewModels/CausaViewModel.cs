using System;
using System.ComponentModel.DataAnnotations;

namespace PUCMinas.SGQ.Incidentes.WebAPI.ViewModels
{
    public class CausaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }
    }
}
