using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PUCMinas.SGQ.Processos.WebAPI.ViewModel
{
    public class WorkflowDefinicaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public Guid EngenherioCriadorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IEnumerable<PassoDefinicaoViewModel> PassosDefinicao { get; set; }
    }
}
