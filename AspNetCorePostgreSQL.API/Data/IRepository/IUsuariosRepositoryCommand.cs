using AspNetCorePostgreSQL.API.Models;

namespace AspNetCorePostgreSQL.API.Data.IRepository
{
    public interface IUsuariosRepositoryCommand
    {
        public Task<bool> DeletaUsuarioPorId(int id);
        public Task<bool> InsereUsuario(Usuario user);
        public Task<bool> AtualizaUsuarioPorId(Usuario user);
    }
}