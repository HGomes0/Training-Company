using System.ComponentModel;

namespace GestaoFormacao.Models.Constants
{
    public static class RoleUtilizador
    {
        public const string Funcionario = "Funcionario";
        public const string Aluno = "Aluno";

        public static bool IsValid(string role)
        {
            return role switch
            {
                Funcionario => true,
                Aluno => true,
                _ => false
            };
        }

        public static List<string> GetAll()
        {
            return new List<string>
            {
                Funcionario,
                Aluno
            };
        }
    }
}