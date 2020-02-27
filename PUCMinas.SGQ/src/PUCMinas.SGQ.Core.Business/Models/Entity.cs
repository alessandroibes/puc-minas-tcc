using System;

namespace PUCMinas.SGQ.Core.Business.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        private DateTime? _dataCriacao;
        public DateTime? DataCriacao
        {
            get { return _dataCriacao; }
            set { _dataCriacao = (value == null ? DateTime.UtcNow : value); }
        }

        public DateTime? DataUltimaAtualizacao { get; set; }
    }
}
