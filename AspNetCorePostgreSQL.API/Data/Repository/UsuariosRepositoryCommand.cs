using AspNetCorePostgreSQL.API.Data.IRepository;
using AspNetCorePostgreSQL.API.Extensoes;
using AspNetCorePostgreSQL.API.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AspNetCorePostgreSQL.API.Data.Repository
{
    public class UsuariosRepositoryCommand : IUsuariosRepositoryCommand
    {
        private readonly DataContext context;
        private readonly DbConnection connection;

        public UsuariosRepositoryCommand(DataContext Context)
        {
            context = Context;
            connection = context.Database.GetDbConnection();
        }
        private string sqlDeletaUsuarioPorId()
        {
            string sRetorno = @"DELETE " +
                               "FROM USUARIOS " +
                               "WHERE Id = @id";

            return sRetorno.clearString(); //evita mandar "bobagem" para o BD
        }

        private string sqlInsereUsuario()
        {
            string sRetorno = @"INSERT INTO USUARIOS (";
            sRetorno += "Id, Nome, Email, Cpf, Ativo) VALUES (";
            sRetorno += "@Id, @Nome, @Email, @Cpf, @Ativo)";

            return sRetorno.clearString();
        }

        private string sqlBuscaProximoId()
        {
            string sRetorno = @"SELECT MAX(Id) + 1 AS NEXT_ID FROM USUARIOS";

            return sRetorno.clearString();
        }

        private string sqlAtualizaUsuarioPorId()
        {
            string sRetorno = @"UPDATE USUARIOS SET " +
                                   " Nome = @Nome, " +
                                   " Email = @Email, " +
                                   " Cpf = @Cpf, " +
                                   " Ativo = @Ativo " +
                               "WHERE " +
                                   " Id = @Id";

            return sRetorno.clearString();
        }

        public async Task<bool> DeletaUsuarioPorId(int id)
        {
            string sSQL = sqlDeletaUsuarioPorId();

            int iRowsAffected = await connection.ExecuteAsync(sSQL, new { @id = id });

            return iRowsAffected > 0;
        }

        public async Task<bool> InsereUsuario(Usuario user)
        {
            string sSQL = sqlInsereUsuario();

            if (user.Id.IsNullOrZero())
            {
                string sSQL1 = sqlBuscaProximoId();

                user.Id = await connection.QuerySingleOrDefaultAsync<int>(sSQL1);
            }


            int iRowsAffected = await connection.ExecuteAsync(sSQL, new
            {
                @id = user.Id,
                @Nome = user.Nome,
                @Email = user.Email,
                @Cpf = user.Cpf,
                @Ativo = user.Ativo
            });

            return iRowsAffected > 0;
        }
        public async Task<bool> AtualizaUsuarioPorId(Usuario user)
        {
            string sSQL = sqlAtualizaUsuarioPorId();

            int iRowsAffected = await connection.ExecuteAsync(sSQL, new
            {
                @id = user.Id,
                @Nome = user.Nome,
                @Email = user.Email,
                @Cpf = user.Cpf,
                @Ativo = user.Ativo
            });

            return iRowsAffected > 0;
        }

    }
}
