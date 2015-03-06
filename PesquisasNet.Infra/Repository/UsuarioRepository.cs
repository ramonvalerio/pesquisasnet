using System.Linq;
using PesquisasNet.Domain.Modelo;
using PesquisasNet.Domain.Interfaces.Repositories;

namespace PesquisasNet.Infra.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario ObterPorNome(string nome)
        {
            return base.context.ListAll<Usuario>().Where(x => x.Nome == nome).SingleOrDefault();
        }
    }
}
