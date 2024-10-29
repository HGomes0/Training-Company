using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFormacao.Interfaces
{
    public interface IFormUtilizadorControl
    {
        uint NumeroInterno { get; set; }
        string Role { get; set; }
        string Nome { get; set; }
        string NomeError { set; }
        event EventHandler ValidarNome;
        event EventHandler<string> TextChangeNome;
        string Email { get; set; }
        string EmailError { set; }
        event EventHandler ValidarEmail;
        event EventHandler<string> TextChangeEmail;
        string Password { get; set; }
        string PasswordError { set; }
        event EventHandler ValidarPassword;
        event EventHandler<string> TextChangePassword;
        string Nif { get; set; }
        string NifError { set; }
        event EventHandler ValidarNif;
        event EventHandler<string> TextChangeNif;
        string Contato { get; set; }
        string ContatoError { set; }
        event EventHandler ValidarContato;
        event EventHandler<string> TextChangeContato;
        string Distrito { get; set; }
        string DistritoError { set; }
        event EventHandler ValidarDistrito;
        event EventHandler<string> TextChangeDistrito;
        string Localidade { get; set; }
        string LocalidadeError { set; }
            event EventHandler ValidarLocalidade;
        event EventHandler<string> TextChangeLocalidade;
        string CodigoPostal { get; set; }
        string CodigoPostalError { set; }
        event EventHandler ValidarCodigoPostal;
        event EventHandler<string> TextChangeCodigoPostal;
        string Rua { get; set; }
        string RuaError { set; }
        event EventHandler ValidarRua;
        event EventHandler<string> TextChangeRua;
        string GlobalError { set; }
    }
}
