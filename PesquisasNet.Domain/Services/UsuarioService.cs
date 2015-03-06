using PesquisasNet.Domain.Modelo;
using PesquisasNet.Domain.Interfaces.Services;
using PesquisasNet.Domain.Interfaces.Repositories;

namespace PesquisasNet.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) 
            : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario ObterPorNome(string nome)
        {
            return _usuarioRepository.ObterPorNome(nome);
        }
    }
}
