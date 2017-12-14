using Budget.Infrastructure.Data.Interface;
using Budget.Services.Interfaces;
using System.Collections.Generic;

namespace Budget.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Domain.Entities.Usuario ObterPorId(string id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Domain.Entities.Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }

        public void DesativarLock(string id)
        {
            _usuarioRepository.DesativarLock(id);
        }
    }
}
