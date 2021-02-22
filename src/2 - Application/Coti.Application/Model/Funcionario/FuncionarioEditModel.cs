using Coti.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Coti.Application.Model
{
    public class FuncionarioEditModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoFuncionario TipoFuncionario { get; set; }
    }
}
