namespace GestaoFormacao.Interfaces
{
    public interface IDashboardCoordenador
    {
        IDashboardAdminHome DashboardAdminHome { get; }
        IDashboardCoordenadorFormadores DashboardCoordenadorFormadores { get; }
        IDashboardCoordenadorFormacao DashboardCoordenadorFormacao { get; }

        event EventHandler BtnHomeClick;
        event EventHandler BtnFormadoresClick;
        event EventHandler BtnFormacoesClick;

        public void MostarHome();
        public void MostarFormadores();
        public void MostarFormacoes();


    }
}
