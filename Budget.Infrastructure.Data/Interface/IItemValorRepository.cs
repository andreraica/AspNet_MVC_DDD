using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface.Common;
using System;
using System.Collections.Generic;

namespace Budget.Infrastructure.Data.Interface
{
    public interface IItemValorRepository : IRepository<ItemValor>, IDisposable
    {
        IEnumerable<ItemValor> GetByOrcamento(int orcamentoId);
    }
}
