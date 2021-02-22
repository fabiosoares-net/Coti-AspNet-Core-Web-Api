using System;
using System.Collections.Generic;
using System.Text;
using Coti.Domain.Enumerator;

namespace Coti.Application.Model
{
    public class FuncionarioFilter
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public TipoFuncionario? Tipo { get; set; }
    }
}
