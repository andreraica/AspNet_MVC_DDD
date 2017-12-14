using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface.Common;
using System;

namespace Budget.Infrastructure.Data.Interface
{
    public interface IOrcamentoRepository : IRepository<Orcamento>, IDisposable
    {
    }
}
