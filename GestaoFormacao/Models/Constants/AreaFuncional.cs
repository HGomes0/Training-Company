namespace GestaoFormacao.Models.Constants
{
    public static class AreaFuncional
    {
        public const string Administrativo = "Administrativa";
        public const string Financeiro = "Financeira";
        public const string RecursosHumanos = "Recursos Humanos";
        public const string Formacao = "Formação";
        public const string Pendente = "N/A";
        public const string Geral = "Geral";

        public static bool IsValid(string areaFuncional)
        {
            return areaFuncional switch
            {
                Administrativo => true,
                Financeiro => true,
                RecursosHumanos => true,
                Formacao => true,
                Pendente => true,
                _ => false
            };
        }

        public static List<string> GetAll()
        {
            return new List<string>
                {
                    Geral,
                    Administrativo,
                    Financeiro,
                    RecursosHumanos,
                    Formacao,
                };
        }
    }
}
