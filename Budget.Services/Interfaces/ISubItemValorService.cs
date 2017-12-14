
using Budget.Domain.Entities;
using Budget.Domain.Services.Interfaces.Common;
using System.Collections.Generic;

namespace Budget.Domain.Services.Interfaces
{
    public interface IItemSubValorService : IService<ItemSubValor>
    {
        IEnumerable<ItemSubValor> GetByValor(int valorId);
    }
}
