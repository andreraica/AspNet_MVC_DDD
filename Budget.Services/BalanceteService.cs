using Budget.Domain.Interfaces;
using Budget.Domain.Services.Interfaces;
using System.Collections.Generic;

namespace Budget.Domain.Services
{
    public class BalanceteService : IBalanceteService
    {
        IBalancete _balancete;

        public BalanceteService(IBalancete balancete)
        {
            _balancete = balancete;
        }

        public decimal Saldo(IEnumerable<IOrcamento> orcamentos)
        {
            return _balancete.Saldo(orcamentos);
        }

        public decimal Total(IEnumerable<IOrcamento> orcamentos)
        {
            return _balancete.Total(orcamentos);
        }
    }
}
