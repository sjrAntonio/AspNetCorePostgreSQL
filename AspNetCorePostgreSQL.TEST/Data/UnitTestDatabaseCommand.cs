using AspNetCorePostgreSQL.API.BusinessRules;
using AspNetCorePostgreSQL.API.Data;
using AspNetCorePostgreSQL.API.Data.IRepository;
using AspNetCorePostgreSQL.API.Data.Repository;
using AspNetCorePostgreSQL.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AspNetCorePostgreSQL.TEST.Data
{
    public class UnitTestDatabaseCommand
    {
        private readonly UsuariosRulesCommand usuariosRules;
        private readonly DataContext context;
        private readonly string connectionString = "Server=127.0.0.1;User Id=postgres;Password=123;Database=TESTE_ASPNET;";

        public UnitTestDatabaseCommand()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connectionString)
                .Options;

            context = new DataContext(options);

            var serviceProvider = new ServiceCollection()
                .AddSingleton(context)
                .AddTransient<IUsuariosRepositoryCommand, UsuariosRepositoryCommand>()
                .AddTransient<UsuariosRulesCommand>()
                .BuildServiceProvider();

            usuariosRules = serviceProvider.GetService<UsuariosRulesCommand>();
        }

        [Theory]
        [InlineData(1, "Bruce Wayne", "batman@waynecorp.com", 98765432100, true)]
        [InlineData(2, "Diana de Themysira", "mulhermaravilha@gmail.com", 30416237061, true)]
        [InlineData(3, "Clark Kent", "superman@planetdaily.com", 15743642001, true)]
        [InlineData(4, "Ororo Munroe", "storm@xmen.com", 75272664060, true)]
        [InlineData(5, "Pato Donald", "pato.donald@disney.com", 42680521005, true)]
        [InlineData(6, "Barbara Gordon", "batgirl@gcpd.com", 19106929052, true)]

        public async Task InsereUsuario_Test(int Id, string Nome, string Email, long Cpf, bool Ativo)
        {
            Usuario usuario = new Usuario(Id, Nome, Email, Cpf, Ativo);

            var resultado = await usuariosRules.InsereUsuario(usuario);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(1, "Bruce Wayne", "batman@waynecorp.com", 98765432100, false)]
        [InlineData(2, "Diana de Themysira", "mulhermaravilha@gmail.com", 30416237061, false)]
        [InlineData(3, "Clark Kent", "superman@planetdaily.com", 15743642001, false)]
        [InlineData(4, "Ororo Munroe", "storm@xmen.com", 75272664060, false)]
        [InlineData(5, "Pato Donald", "pato.donald@disney.com", 42680521005, false)]
        [InlineData(6, "Barbara Gordon", "batgirl@gcpd.com", 19106929052, false)]
        public async Task AtualizaUsuarioPorId_Test(int Id, string Nome, string Email, long Cpf, bool Ativo)
        {
            Usuario usuario = new Usuario(Id, Nome, Email, Cpf, Ativo);

            var resultado = await usuariosRules.AtualizaUsuarioPorId(usuario);

            Assert.True(resultado);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task DeletaUsuarioPorId_Test(int Id)
        {
            var resultado = await usuariosRules.DeletaUsuarioPorId(Id);

            Assert.True(resultado);
        }
    }
}
