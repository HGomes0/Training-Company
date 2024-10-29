using GestaoFormacao.Models;

namespace GestaoFormacao.Interfaces
{
    internal interface IFormFormacao
    {
        string Nome { get; set; }
        string NomeLabel { set; }

        string Grupo { get; set; }
        string GrupoLabel { set; }
        string Horario { get; set; }
        DateTime DataInicio { get; set; }
        DateTime DataFim { get; set; }
        List<FormadorModel> Formadores { get; set; }
        string DatasLabel { set; }
        uint NumeroFormador { get; set; }

        void Mostrar();
        void Fechar();
        void ResetLabels();
        event EventHandler Guardar;
    }
}
