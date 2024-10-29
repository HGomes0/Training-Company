using GestaoFormacao.Database;
using GestaoFormacao.Helpers;
using GestaoFormacao.Interfaces;
using GestaoFormacao.Models.Constants;
using MongoDB.Bson.Serialization.Attributes;

namespace GestaoFormacao.Models;

public class FormacaoModel : GFMongoEntity, IIdentificavel
{
    uint nomeroInterno;

    public string Nome { get; set; }
    public string Grupo { get; set; }
    public uint NumeroInterno { get => nomeroInterno == 0 ? nomeroInterno = GFOption.GetNextIDFormacao() : nomeroInterno; set => nomeroInterno = value; }
    public DateTime DataInicioFormacao { get; set; }
    public DateTime DataFimFormacao { get; set; }
    public string? Area { get; set; }
    public string? Horario { get; set; }
    public uint NumeroInternoFormador { get; set; }
    public string NomeFormador { get; set; }
    public decimal ValorHora { get; set; }

    [BsonIgnore]
    public decimal Custo => CalcularCusto();

    [BsonIgnore]
    public uint DiasUteis => (uint)GetDiasUteis();

    public int GetDiasUteis()
    {
        int diasUteis = 0;

        if (DataInicioFormacao == DataFimFormacao)
        {
            return (DataInicioFormacao.DayOfWeek != DayOfWeek.Saturday && DataInicioFormacao.DayOfWeek != DayOfWeek.Sunday && !FeriadoHelper.IsFeriado(DataInicioFormacao))
            ? 1 : 0;
        }

        for (DateTime date = DataInicioFormacao; date <= DataFimFormacao; date = date.AddDays(1))
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || FeriadoHelper.IsFeriado(date))
            {
                continue;
            }

            diasUteis++;
        }

        return diasUteis;
    }

    public int GetDiasUteisDeFormacaoMes(DateTime data)
    {
        int diasUteis = 0;

        data = new DateTime(data.Year, data.Month, 1);

        var forDataInicio = DataInicioFormacao > data ? DataInicioFormacao : data;
        var forDataFim = DataFimFormacao < data.AddMonths(1).AddDays(-1) ? DataFimFormacao : data.AddMonths(1).AddDays(-1);

        for (DateTime date = forDataInicio; date <= forDataFim; date = date.AddDays(1))
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || FeriadoHelper.IsFeriado(date))
            {
                continue;
            }

            diasUteis++;
        }

        return diasUteis;
    }

    public decimal CalcularCustoMensal(DateTime data)
    {
        return 6 * GetDiasUteisDeFormacaoMes(data) * ValorHora;
    }


    public decimal CalcularCusto()
    {
        int diasUteis = GetDiasUteis();
        return diasUteis * 6 * ValorHora;
    }

    public FormadorModel GetFormador()
    {
        return Empresa.FormadorController.PorNumeroInterno(NumeroInternoFormador) ?? throw new Exception("Formador não encontrado");
    }

    public void ValidarCriar()
    {
        ValidacaoHelper.ValidarStringTamanho(Nome, 3);

        DataInicioFormacao = ValidacaoHelper.ValidarDataFutura(DataInicioFormacao);
        DataFimFormacao = ValidacaoHelper.ValidarDataFutura(DataFimFormacao);

        if (ValorHora <= 0)
        {
            throw new Exception("Valor da hora inválido");
        }

        ValidacaoHelper.ValidarDataRange(DataInicioFormacao, DataFimFormacao);

        ValidacaoHelper.ValidarStringTamanho(NomeFormador, 3);

        AreaFormacao.IsValid(Area ?? "");
        DisponibilidadeHorario.IsValid(Horario ?? "");

        if (Empresa.FormadorController.PorNumeroInterno(NumeroInternoFormador) == null)
        {
            throw new Exception("Formador não encontrado");
        }
    }

    public bool ValueSearch(string value)
    {
        return Nome.ToLower().Contains(value.ToLower()) || Grupo.ToLower().Contains(value.ToLower()) || Area.ToLower().Contains(value.ToLower());
    }
}


