using AspNetCorePostgreSQL.API.Models;

namespace AspNetCorePostgreSQL.API.Data.IRepository
{
    public interface IUsuariosRepositoryQuery
    {
        public Task<List<Usuario>> BuscaTodosUsuarios();
        public Task<List<Usuario>> BuscaUsuarioPorId(int id);
    }
}

