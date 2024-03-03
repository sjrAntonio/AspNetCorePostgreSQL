namespace AspNetCorePostgreSQL.API.Extensoes
{
    public static class IntegerExtensions
    {
        public static bool IsNullOrZero(this int? value)
        {
            return value == null || value == 0;
        }
    }
}
