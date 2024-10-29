using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFormacao.Interfaces
{
    public interface IFormFuncionarioControl
    {
        DateTime DataInicioContrato { get; set; }
        event EventHandler DataInicioContratoChanged;
        DateTime DataFimContrato { get; set; }
        event EventHandler DataFimContratoChanged;
        string DataContratoError { set; }
        DateTime DataRegistoCriminal { get; set; }  
        string DataRegistoCriminalError { set; }
        event EventHandler DataRegistoCriminalChanged;
        string Funcao { get; set; }
        string ErrorGlobal { set; }
    }
}
