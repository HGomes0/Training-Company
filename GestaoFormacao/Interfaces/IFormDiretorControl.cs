namespace GestaoFormacao.Interfaces
{
    public interface IFormDiretorControl
    {
        decimal BonusMensal { get; set; }
        event EventHandler<string> BonusMensalChanged;
        event EventHandler<decimal> ValidarBonusMensal;
        string BonusMensalError { set; }

        string TipoIsencao { get; set; }
        bool CarroEmpresa { get; set; }
        string AreaDirecao { get; set; }

        string ErrorGlobal { set; }
    }
}
