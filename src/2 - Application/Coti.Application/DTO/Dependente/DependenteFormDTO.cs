using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.DTO
{
    public class DependenteFormDTO
    {
        public int IdDependente { get; set; }
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
    }
}
