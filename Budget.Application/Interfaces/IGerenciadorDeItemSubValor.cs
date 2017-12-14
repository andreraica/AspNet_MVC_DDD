using Budget.Domain.Entities;
using System.Collections.Generic;

namespace Budget.Application.Interfaces
{
    public interface IGerenciadorDeItemSubValor
    {
        IEnumerable<ItemSubValor> Listar();
        bool Salvar(ItemSubValor itemValor);
        ItemSubValor Editar(ItemSubValor itemValor);
        void Excluir(ItemSubValor itemValor);
        ItemSubValor BuscarPorId(int id);

        IEnumerable<ItemSubValor> BuscaPorValor(int valorId);
    }
}
