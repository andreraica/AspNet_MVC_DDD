using Budget.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Budget.Infrastructure.Data.Interface
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
