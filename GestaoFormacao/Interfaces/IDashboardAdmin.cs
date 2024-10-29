namespace GestaoFormacao.Interfaces
{
    public interface IDashboardAdmin
    {
        event EventHandler BtnHomeClick;
        event EventHandler BtnCustosClick;
        event EventHandler BtnFuncionariosClick;

        IDashboardAdminHome DashboardAdminHome { get; }
        IDashboardAdminFuncionarios DashboardAdminFuncionarios { get; }
    }
}
