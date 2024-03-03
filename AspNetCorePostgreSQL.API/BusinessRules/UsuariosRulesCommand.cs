using AspNetCorePostgreSQL.API.Data.IRepository;
using AspNetCorePostgreSQL.API.Data.Repository;
using AspNetCorePostgreSQL.API.Models;

namespace AspNetCorePostgreSQL.API.BusinessRules
{
    public class UsuariosRulesCommand : IUsuariosRepositoryCommand
    {
        private readonly IUsuariosRepositoryCommand usuariosRepository;

        public UsuariosRulesCommand(IUsuariosRepositoryCommand UsuariosRepository)
        {
            usuariosRepository = UsuariosRepository;
        }
        public Task<bool> DeletaUsuarioPorId(int id)
        {
            return usuariosRepository.DeletaUsuarioPorId(id);
        }

        public Task<bool> InsereUsuario(Usuario user)
        {
            /* Validar CPF */
            if (!user.Cpf.ToString("00000000000").validarCPF()) { throw new Exception("Invalid CPF"); }

            /* Validar email */
            if (!user.Email.validarEmail()) { throw new Exception("Invalid Email"); }

            return usuariosRepository.InsereUsuario(user);
        }
        public Task<bool> AtualizaUsuarioPorId(Usuario user)
        {
            /* Validar CPF */
            if (!user.Cpf.ToString("00000000000").validarCPF()) { throw new Exception("Invalid CPF"); }

            /* Validar email */
            if (!user.Email.validarEmail()) { throw new Exception("Invalid Email"); }

            return usuariosRepository.AtualizaUsuarioPorId(user);
        }
    }
}
