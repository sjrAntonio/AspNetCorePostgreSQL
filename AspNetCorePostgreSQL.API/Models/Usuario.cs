namespace AspNetCorePostgreSQL.API.Models
{
    public class Usuario
    {
        public Usuario() { }

        public Usuario(int? xId, string xNome, string xEmail, long xCpf, bool xAtivo)
        {
            this.Id = xId;
            this.Nome = xNome;
            this.Email = xEmail;
            this.Cpf = xCpf;
            this.Ativo = xAtivo;
        }

        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
