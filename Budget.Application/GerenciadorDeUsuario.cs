using Budget.Application.Interfaces;
using Budget.Domain.Entities;
using Budget.Services.Interfaces;
using System.Collections.Generic;

namespace Budget.Application
{
    public class GerenciadorDeUsuario : IGerenciadorDeUsuario
    {
        private readonly IUsuarioService _usuarioService;

        public GerenciadorDeUsuario(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Budget.Domain.Entities.Usuario ObterPorId(string id)
        {
            return _usuarioService.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioService.ObterTodos();
        }

        public void DesativarLock(string id)
        {
            _usuarioService.DesativarLock(id);
        }
    }
}
