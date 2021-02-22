using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.Model
{
    public class CriacaoFuncionarioFormModel
    {
        public FuncionarioFormModel Funcionario { get; set; }
        public List<DependenteFormModel> Dependente { get; set; }
    }
}
