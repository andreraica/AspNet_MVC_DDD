using Budget.Domain.Entities.Enum;
using Budget.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Domain.Entities
{
    public class Balancete : IBalancete
    {
        public decimal Total(IEnumerable<IOrcamento> orcamentos)
        {
            return orcamentos.Sum(x => x.Valores.Sum(y=>y.SubValores.Sum(z => z.Valor)));
        }

        public decimal Saldo(IEnumerable<IOrcamento> orcamentos)
        {
            return 
                Total(orcamentos.Where(x => x.TipoOrcamento == ETipoOrcamento.Receita)) 
                - 
                Total(orcamentos.Where(x => x.TipoOrcamento == ETipoOrcamento.Despesa));
        }
    }
}
