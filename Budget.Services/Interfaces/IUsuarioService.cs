using Budget.Domain.Entities;
using System.Collections.Generic;
namespace Budget.Services.Interfaces
{
    public interface IUsuarioService
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
