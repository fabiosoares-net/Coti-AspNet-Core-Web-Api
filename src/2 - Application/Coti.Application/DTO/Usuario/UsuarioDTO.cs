using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.DTO
{
    public class UsuarioDTO
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataHoraCadastro { get; set; }
    }
}
