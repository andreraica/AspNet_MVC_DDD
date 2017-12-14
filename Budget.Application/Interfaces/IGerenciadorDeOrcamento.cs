using Budget.Domain.Entities;
using System.Collections.Generic;

namespace Budget.Application.Interfaces
{
    public interface IGerenciadorDeOrcamento
    {
        IEnumerable<Orcamento> Listar();
        bool Salvar(Orcamento orcamento);
        Orcamento Editar(Orcamento orcamento);
        void Excluir(Orcamento orcamento);
        Orcamento BuscarPorId(int id);
    }
}
