using Budget.Domain.Interfaces;
using System.Collections.Generic;

namespace Budget.Domain.Services.Interfaces.Common
{
    public class OrcamentoService<T> where T : IOrcamento
    {
        public int DiaVencimentoMedio(T entity)
        {
            return entity.DiaVencimentoMedio(entity);
        }

        public int QuantidadeParcelas(T entity)
        {
            return entity.QuantidadeParcelas(entity);
        }

        public int QuantidadeParcelasRestantes(T entity)
        {
            return entity.QuantidadeParcelasRestantes(entity);
        }

        public decimal TotalValorRestante(T entity)
        {
            return entity.TotalValorRestante(entity);
        }
    }
}
