﻿using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PUCMinas.SGQ.Incidentes.WebAPI.ViewModels
{
    public class RNCViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Ocorrencia { get; set; }

        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid GerenteCriador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ClassificacaoRNC Classificacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid EngenheiroResponsavel { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid GestorAvaliador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public StatusRNC Status { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public GravidadeViewModel Gravidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public CausaViewModel Causa { get; set; }

        public AcaoViewModel Acao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime Prazo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataOcorrencia { get; set; }

        public DateTime DataResolucao { get; set; }
        public DateTime DataFechamento { get; set; }
    }
}
