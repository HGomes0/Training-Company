using GestaoFormacao.Models;

namespace GestaoFormacao.Interfaces
{
    public interface IDashboardAdminHome
    {

        string Datatexto { set; }
        uint TotalFuncionarios { get; set; }
        uint TotalFormadores { get; set; }
        uint TotalFormacoes { get; set; }
        uint TotalCustos { get; set; }

        public event EventHandler<uint> CardUserClick;

        void SetAvisos(List<KeyValuePair<FuncionarioModel, string>> list);

        event EventHandler DataProximoClick;
        event EventHandler DataAnteriorClick;
    }
}
