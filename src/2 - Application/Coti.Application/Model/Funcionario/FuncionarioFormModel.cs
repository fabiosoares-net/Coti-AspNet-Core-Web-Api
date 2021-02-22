using Coti.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Coti.Application.Model
{
    public class FuncionarioFormModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TipoFuncionario TipoFuncionario { get; set; }
    }
}
