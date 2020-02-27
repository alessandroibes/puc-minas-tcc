using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Core.Business.Models;
using System;

namespace PUCMinas.SGQ.Incidentes.Business.Models
{
    public class RNC : Entity
    {
        public Guid NumeroProcesso { get; set; }
        public string Ocorrencia { get; set; }
        public string Descricao { get; set; }
        public IUser Criador { get; set; }        
        public TipoRNC Tipo { get; set; }
        public IUser Responsavel { get; set; }
        public StatusRNC Status { get; set; }
        public Guid GravidadeId { get; set; }
        public Guid CausaId { get; set; }
        public Guid AcaoId { get; set; }
        public DateTime Prazo { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public DateTime DataResolucao { get; set; }
        public DateTime DataFechamento { get; set; }

        /* EF Relations */
        public Gravidade Gravidade { get; set; }
        public Causa Causa { get; set; }
        public Acao Acao { get; set; }
    }
}
