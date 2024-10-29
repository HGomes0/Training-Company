using System.Text.Json;

namespace GestaoFormacao.Helpers
{
    public static class FeriadoHelper
    {
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public static Dictionary<int, FeriadoModel[]> Feriados = new Dictionary<int, FeriadoModel[]>();

        public static bool IsFeriado(DateTime date)
        {
            try
            {
                CheckAno(date.Year);
                return Feriados[date.Year].Any(f => f.Date == date);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static void CheckAno(int ano)
        {
            if (!Feriados.ContainsKey(ano))
            {
                var feriados = GetFeriados(ano);
                Feriados.Add(ano, feriados);
            }
        }

        public static FeriadoModel[] GetFeriados(int ano)
        {
            var url = $"https://date.nager.at/api/v3/publicholidays/{ano}/PT";
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var feriados = JsonSerializer.Deserialize<FeriadoModel[]>(content, options);
            return feriados;
        }
    }

    public class FeriadoModel
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Date} - {Name}";
        }
    }
}