using System.ComponentModel;

namespace GestaoFormacao.Models.Constants
{

    public static class FuncaoFuncionario
    {
        public const string Formador = "Formador";
        public const string Coordenador = "Coordenador";
        public const string Administrativo = "Administrativo";
        public const string Diretor = "Diretor";

        public static bool IsValid(string funcao)
        {
            return funcao switch
            {
                Formador => true,
                Coordenador => true,
                Administrativo => true,
                Diretor => true,
                _ => false
            };
        }

        public static List<string> GetAll()
        {
            return new List<string>
                {
                    Formador,
                    Coordenador,
                    Administrativo,
                    Diretor
                };
        }
    }
}