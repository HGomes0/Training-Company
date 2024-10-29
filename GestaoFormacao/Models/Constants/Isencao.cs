using System.ComponentModel;

namespace GestaoFormacao.Models.Constants
{
    public static class Isencao
    {
        public const string IsencaoTotal = "Isençao Total";
        public const string IsencaoParcial = "Isençao Parcial";
        public const string SemIsencao = "Sem Isençao";

        public static bool IsValid(string isencao)
        {
            return isencao switch
            {
                IsencaoTotal => true,
                IsencaoParcial => true,
                SemIsencao => true,
                _ => false
            };
        }

        public static List<string> GetAll()
        {
            return new List<string>
            {
                IsencaoTotal,
                IsencaoParcial,
                SemIsencao
            };
        }
    }
}