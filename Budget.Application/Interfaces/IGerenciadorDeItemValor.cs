using Budget.Domain.Entities;
using System.Collections.Generic;

namespace Budget.Application.Interfaces
{
    public interface IGerenciadorDeItemValor
    {
        IEnumerable<ItemValor> Listar();
        bool Salvar(ItemValor itemValor);
        ItemValor Editar(ItemValor itemValor);
        void Excluir(ItemValor itemValor);
        ItemValor BuscarPorId(int id);
        IEnumerable<ItemValor> BuscaPorOrcamento(int orcamentoId);
    }
}
