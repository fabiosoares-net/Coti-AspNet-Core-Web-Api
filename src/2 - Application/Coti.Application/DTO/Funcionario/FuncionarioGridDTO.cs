using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.DTO
{
    public class FuncionarioGridDTO
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public decimal Salario { get; set; }
        public string DataAdmissao { get; set; }
        public string TipoFuncionario { get; set; }
    }
}
