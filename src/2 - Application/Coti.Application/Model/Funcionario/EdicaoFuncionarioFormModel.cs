using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.Model
{
    public class EdicaoFuncionarioFormModel
    {
        public FuncionarioEditModel Funcionario { get; set; }
        public List<DependenteEditModel> Dependente { get; set; }
    }
}
