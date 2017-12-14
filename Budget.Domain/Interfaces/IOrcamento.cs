using Budget.Domain.Entities;
using Budget.Domain.Entities.Enum;
using System.Collections.Generic;

namespace Budget.Domain.Interfaces
{
    public interface IOrcamento : IBase
    {
        string Descricao { get; set; }
        ETipoPessoa TipoPessoa { get; set; }
        ETipoPagamento TipoPagamento { get; set; }
        ETipoOrcamento TipoOrcamento { get; set; }
        bool Fixa { get; set; }
        decimal? TaxaPorcentagem { get; set; }

        IEnumerable<ItemValor> Valores { get; set; }

        int DiaVencimentoMedio(Orcamento orcamento);
        int QuantidadeParcelas(Orcamento orcamento);
        int QuantidadeParcelasRestantes(Orcamento orcamento);
        decimal TotalValorRestante(Orcamento orcamento);
    }
}
