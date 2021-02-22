using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.DTO
{
    public class AppUserDTO
    {
        public UsuarioDTO Usuario { get; set; }
        public AccessTokenDTO AccessToken { get; set; }
    }
}
