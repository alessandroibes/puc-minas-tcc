using System;
using System.ComponentModel.DataAnnotations;

namespace PUCMinas.SGQ.Processos.WebAPI.ViewModel
{
    public class PassoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid WorflowId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Iniciado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Finalizado { get; set; }
    }
}
