using AspNetCorePostgreSQL.API.Data.IRepository;
using AspNetCorePostgreSQL.API.Data.Repository;
using AspNetCorePostgreSQL.API.Models;

namespace AspNetCorePostgreSQL.API.BusinessRules
{
    public class UsuariosRulesQuery : IUsuariosRepositoryQuery
    {
        private readonly IUsuariosRepositoryQuery usuariosRepository;

        public UsuariosRulesQuery(IUsuariosRepositoryQuery UsuariosRepository)
        {
            usuariosRepository = UsuariosRepository;
        }

        public Task<List<Usuario>> BuscaTodosUsuarios()
        {
            return usuariosRepository.BuscaTodosUsuarios();
        }

        public Task<List<Usuario>> BuscaUsuarioPorId(int id)
        {
            return usuariosRepository.BuscaUsuarioPorId(id);
        }
    }
}
