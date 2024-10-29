namespace GestaoFormacao.Interfaces
{
    public interface IFormFormadorControl
    {
        string Disponibilidade { get; set; }
        string Area { get; set; }
        bool Coordenador { get; set; }

        decimal ValorHora { get; set; }
        event System.EventHandler<string> ValorHoraChanged;
        event System.EventHandler<decimal> ValidarValorHora;
        string ValorHoraError { set; }
        string ErrorGlobal { set; }
    }
}
