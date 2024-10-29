namespace GestaoFormacao.Models.Constants
{
    public static class DisponibilidadeHorario
    {
        public const string Laboral = "Laboral";
        public const string PosLaboral = "Pós-Laboral";
        public const string Ambos = "Ambos";

        public static bool IsValid(string value)
        {
            return value switch
            {
                Laboral => true,
                PosLaboral => true,
                Ambos => true,
                _ => false
            };
        }

        public static List<string> GetAll()
        {
            return new List<string>
            {
                Laboral,
                PosLaboral,
                Ambos
            };
        }
    }
}
