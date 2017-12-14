using Budget.Domain.Entities;
using Budget.Infrastructure.Data.Interface.Common;
using System;
using System.Collections.Generic;

namespace Budget.Infrastructure.Data.Interface
{
    public interface IItemSubValorRepository : IRepository<ItemSubValor>, IDisposable
    {
        IEnumerable<ItemSubValor> GetByValor(int valorId);
    }
}
