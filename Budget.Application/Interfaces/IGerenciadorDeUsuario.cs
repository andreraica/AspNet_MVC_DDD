using Budget.Domain.Entities;
using System.Collections.Generic;

namespace Budget.Application.Interfaces
{
    public interface IGerenciadorDeUsuario
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
