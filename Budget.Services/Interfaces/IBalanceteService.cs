using Budget.Domain.Interfaces;
using System.Collections.Generic;

namespace Budget.Domain.Services.Interfaces
{
    public interface IBalanceteService
    {
        decimal Total(IEnumerable<IOrcamento> orcamentos);
        decimal Saldo(IEnumerable<IOrcamento> orcamentos);
    }
}
