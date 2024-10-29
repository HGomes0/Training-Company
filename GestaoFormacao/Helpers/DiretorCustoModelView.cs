using GestaoFormacao.Models;

namespace GestaoFormacao.Helpers
{
    public class DiretorCustoModelView
    {
        public DiretorCustoModelView(DiretorModel diretor)
        {
            Nome = diretor.Nome;
            AreaDiretoria = diretor.AreaDiretoria;
            BonusMensal = diretor.BonusMensal;
        }
        public string Nome { get; set; }
        public string AreaDiretoria { get; set; }
        public decimal BonusMensal { get; set; }
    }
}
