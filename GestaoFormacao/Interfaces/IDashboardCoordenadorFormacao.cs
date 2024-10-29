namespace GestaoFormacao.Interfaces
{
    public interface IDashboardCoordenadorFormacao
    {
        public BindingSource BindingSourceFormacoes { get; }

        public string SearchText { get; set; }
        public event EventHandler<string> SearchTextFormacaoChanged;

        public bool AtivoChecked { get; set; }
        public event EventHandler<bool> AtivoCheckedChanged;

        public event EventHandler AdicionarFormacao;

    }
}
