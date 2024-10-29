namespace GestaoFormacao.Interfaces
{
    internal interface IFormLogin
    {
        public string Email { get; set; }
        public string EmailError { set; }
        public string Password { get; set; }
        public string PasswordError { set; }

        event EventHandler Login;

        void Mostrar();
        void Fechar();
    }
}
