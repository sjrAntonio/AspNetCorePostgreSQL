using AspNetCorePostgreSQL.API.Data.IRepository;
using AspNetCorePostgreSQL.API.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AspNetCorePostgreSQL.API.Data.Repository
{
    public class UsuariosRepositoryQuery : IUsuariosRepositoryQuery
    {
        private readonly DataContext context;
        private readonly DbConnection connection;

        public UsuariosRepositoryQuery(DataContext Context)
        {
            context = Context;
            connection = context.Database.GetDbConnection();
        }

        private string sqlBuscaTodosUsuarios()
        {
            string sRetorno = @"SELECT Id, " +
                               "       Nome, " +
                               "       Email, " +
                               "       Cpf, " +
                               "       Ativo  " +
                               "FROM USUARIOS " +
                               "ORDER BY Id";

            return sRetorno.clearString(); 
        }

        private string sqlBuscaUsuarioPorId()
        {
            string sRetorno = @"SELECT Id, " +
                               "       Nome, " +
                               "       Email, " +
                               "       Cpf, " +
                               "       Ativo  " +
                               "FROM USUARIOS " +
                               "WHERE Id = @id";

            return sRetorno.clearString(); 
        }

        public async Task<List<Usuario>> BuscaTodosUsuarios()
        {
            string sSQL = sqlBuscaTodosUsuarios();

            var retorno = await connection.QueryAsync<Usuario>(sSQL);

            return retorno.ToList();
        }

        public async Task<List<Usuario>> BuscaUsuarioPorId(int id)
        {
            string sSQL = sqlBuscaUsuarioPorId();

            var retorno = await connection.QueryAsync<Usuario>(sSQL, new { @id = id });

            return retorno.ToList();
        }
    }
}
