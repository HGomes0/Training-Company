namespace GestaoFormacao.Interfaces
{
    public interface IDashboardCoordenadorFormadores
    {
        string SearchText { get; set; }
        event EventHandler<string> Search;

        bool AtivoChecked { get; set; }
        event EventHandler<bool> AtivoCheckedChanged;

        public BindingSource BindingSourceFormadores { get; }
    }
}
