using Coti.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Entities
{
    public class Funcionario
    {
        public Funcionario()
        {
            Dependente = new List<Dependente>();
        }

        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public TipoFuncionario TipoFuncionario { get; set; }

        #region EF Relation
        public IList<Dependente> Dependente { get; set; }
        #endregion
    }
}
