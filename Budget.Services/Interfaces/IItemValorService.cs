
using Budget.Domain.Entities;
using Budget.Domain.Services.Interfaces.Common;
using System.Collections.Generic;

namespace Budget.Domain.Services.Interfaces
{
    public interface IItemValorService : IService<ItemValor>
    {
        IEnumerable<ItemValor> GetByOrcamento(int orcamentoId);
    }
}
