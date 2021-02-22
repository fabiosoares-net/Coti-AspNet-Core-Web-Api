using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Coti.Domain.Enumerator
{
    public enum TipoFuncionario
    {
        [Description("Estagiário")]
        ESTAGIARIO = 1,
        
        [Description("CLT")]
        CLT = 2,

        [Description("Terceirizado")]
        TERCEIRIZADO = 3
    }
}
