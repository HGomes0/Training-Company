namespace GestaoFormacao.Interfaces
{
    public interface IDashboardAdminFuncionarios
    {
        string SearchText { get; set; }
        event EventHandler<string> Search;

        string FuncaoFiltro { get; set; }
        event EventHandler<string> FuncaoFiltroChanged;

        bool AtivoChecked { get; set; }
        event EventHandler<bool> AtivoCheckedChanged;

        event EventHandler AddFuncionario;

        event EventHandler ExportarFuncionarios;

        public BindingSource BindingSourceFuncionarios { get; }
        public bool RegistoCaducadoChecked { get; set; }
    }
}
