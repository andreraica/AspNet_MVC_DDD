using Budget.Domain.Entities;
using Budget.Domain.Services.Interfaces.Common;

namespace Budget.Domain.Services.Interfaces
{
    public interface IOrcamentoService : IService<Orcamento>
    {
        int DiaVencimentoMedio(Orcamento orcamento);
        int QuantidadeParcelas(Orcamento orcamento);
        int QuantidadeParcelasRestantes(Orcamento orcamento);
        decimal TotalValorRestante(Orcamento orcamento);
    }
}
