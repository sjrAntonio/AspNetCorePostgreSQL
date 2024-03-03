using AspNetCorePostgreSQL.API.BusinessRules;
using AspNetCorePostgreSQL.API.Data;
using AspNetCorePostgreSQL.API.Data.IRepository;
using AspNetCorePostgreSQL.API.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace AspNetCorePostgreSQL.TEST.Data
{
    public class UnitTestDatabaseQuery
    {
        public IConfiguration Configuration { get; }
        private readonly UsuariosRulesQuery usuariosRules;
        private readonly DataContext context;
        private readonly string connectionString = "Server=127.0.0.1;User Id=postgres;Password=123;Database=TESTE_ASPNET;";

        public UnitTestDatabaseQuery()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connectionString)
                .Options;

            context = new DataContext(options);

            var serviceProvider = new ServiceCollection()
                .AddSingleton(context)
                .AddTransient<IUsuariosRepositoryQuery, UsuariosRepositoryQuery>()
                .AddTransient<UsuariosRulesQuery>()
                .BuildServiceProvider();

            usuariosRules = serviceProvider.GetService<UsuariosRulesQuery>();
        }

        [Fact]
        public async Task BuscaTodosUsuarios_Test()
        {
            var resultado = await usuariosRules.BuscaTodosUsuarios();

            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public async Task BuscaUsuarioPorId_Test(int Id)
        {
            var resultado = await usuariosRules.BuscaUsuarioPorId(Id);

            Assert.NotNull(resultado);
            Assert.NotEmpty(resultado);
        }
    }
}
