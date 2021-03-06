﻿using PUCMinas.SGQ.Core.Data.Repository;
using PUCMinas.SGQ.Processos.Business.Interfaces;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.Data.Context;

namespace PUCMinas.SGQ.Processos.Data.Repository
{
    public class PassoRepository : Repository<Passo>, IPassoRepository
    {
        public PassoRepository(ProcessosDbContext context) : base(context)
        {
        }
    }
}
