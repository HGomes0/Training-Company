using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFormacao.Interfaces
{
    public interface IFormAdministrativoControl
    {
        string AreaFunc { get; set; }
        event EventHandler<string> SelecionarAreaFuncional;

        string ErrorGlobal { set; }
    }
}
