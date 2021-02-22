using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Entities
{
    public class Dependente
    {
        public int IdDependente { get; set; }
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        #region EF Relation
        public Funcionario Funcionario { get; set; }
        #endregion
    }
}
