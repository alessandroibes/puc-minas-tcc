﻿using PUCMinas.SGQ.Core.Business.Interfaces;
using PUCMinas.SGQ.Incidentes.Business.Models;
using System;
using System.Threading.Tasks;

namespace PUCMinas.SGQ.Incidentes.Business.Interfaces
{
    public interface IAcaoRepository : IRepository<Acao>
    {
        Task<Acao> ObterAcaoComRNCs(Guid id);
    }
}
