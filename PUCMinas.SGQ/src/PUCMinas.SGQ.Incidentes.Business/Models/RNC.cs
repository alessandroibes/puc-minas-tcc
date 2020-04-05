using PUCMinas.SGQ.Core.Business.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PUCMinas.SGQ.Incidentes.Business.Models
{
    public class RNC : Entity
    {
        public Guid GravidadeId { get; set; }
        public Guid CausaId { get; set; }
        public Guid? AcaoId { get; set; }

        public string Ocorrencia { get; set; }
        public string Descricao { get; set; }
        public Guid GerenteCriador { get; set; }        
        public ClassificacaoRNC Classificacao { get; set; }
        public Guid? EngenheiroResponsavel { get; set; }
        public StatusRNC Status { get; set; }
        [ForeignKey("GravidadeId")]
        public Gravidade Gravidade { get; set; }
        [ForeignKey("CausaId")]
        public Causa Causa { get; set; }
        [ForeignKey("AcaoId")]
        public Acao Acao { get; set; }
        public DateTime Prazo { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public DateTime DataResolucao { get; set; }
        public DateTime DataFechamento { get; set; }        
    }
}
