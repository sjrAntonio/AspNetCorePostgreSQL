using System.Text.RegularExpressions;

namespace AspNetCorePostgreSQL.API.Data.Repository
{
    public static class StringExtensions
    {
        private static int CalcularDigitoCPF(string cpf)
        {
            int soma = 0, peso = cpf.Length + 1;

            foreach (var ch in cpf)
            {
                if (!int.TryParse(ch.ToString(), out int num))
                    return 0;

                soma += num * peso--;
            }

            int resto = soma % 11;
            return resto < 2 ? 0 : 11 - resto;
        }

        public static string clearString(this string value)
        {
            value = value.Replace("\t", "");
            value = value.Replace("\n", "");
            value = Regex.Replace(value, @"\s+", " ");

            value = value.Trim();

            return value;
        }

        public static bool validarCPF(this string cpf)
        {
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !long.TryParse(cpf, out _)) { return false; }

            var regex = new Regex(@"^(\d)\1{10}$");

            if (regex.IsMatch(cpf)) { return false; }
                

            var tempCpf = cpf.Substring(0, 9);
            tempCpf += CalcularDigitoCPF(tempCpf);
            tempCpf += CalcularDigitoCPF(tempCpf);

            return cpf.Equals(tempCpf);
        }

        public static bool validarEmail(this string email)
        {
            var regex = new Regex(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");

            return regex.IsMatch(email);
        }
    }
}
