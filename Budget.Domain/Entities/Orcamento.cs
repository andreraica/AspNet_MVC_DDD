using Budget.Domain.Entities.Enum;
using Budget.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget.Domain.Entities
{
    public class Orcamento : IOrcamento
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public ETipoPessoa TipoPessoa { get; set; }
        public ETipoPagamento TipoPagamento { get; set; }
        public ETipoOrcamento TipoOrcamento { get; set; }
        
        /// <summary>
        /// Indica se a conta não é em parcelas e sim sempre, exemplo: convenio medico
        /// </summary>
        public bool Fixa { get; set; }

        /// <summary>
        /// Possível tava de recebimento: exemplo: Imposto Simples Nacional 6%
        /// </summary>
        public decimal? TaxaPorcentagem { get; set; }

        public virtual IEnumerable<ItemValor> Valores { get; set; }

        public int DiaVencimentoMedio(Orcamento orcamento)
        {
            return orcamento.Valores.Sum(x => x.Vencimento.Day) / orcamento.Valores.Count();
        }

        private IEnumerable<ItemValor> ValoresValidos(Orcamento orcamento)
        {
            return orcamento.Valores.Where(x => x.SubValores.Any(z => z.Valor > 0));
        }

        private IEnumerable<ItemValor> ParcelasValidas(Orcamento orcamento)
        {
            return ValoresValidos(orcamento).Where(x => x.Vencimento > DateTime.Now);
        }

        public int QuantidadeParcelas(Orcamento orcamento)
        {
            return ValoresValidos(orcamento).Count();
        }

        public int QuantidadeParcelasRestantes(Orcamento orcamento)
        {
            return ParcelasValidas(orcamento).Count();
        }

        public decimal TotalValorRestante(Orcamento orcamento)
        {
            return ParcelasValidas(orcamento).Sum(y => y.SubValores.Sum(z => z.Valor));
        }
    }
}
