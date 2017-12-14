using System.Collections.Generic;

namespace Budget.Domain.Interfaces
{
    public interface IBalancete
    {
        decimal Total(IEnumerable<IOrcamento> orcamentos);
        decimal Saldo(IEnumerable<IOrcamento> orcamentos);
    }
}
