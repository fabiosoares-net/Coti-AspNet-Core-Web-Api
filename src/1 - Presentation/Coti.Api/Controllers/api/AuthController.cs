using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coti.Api.Security;
using Coti.Application.DTO;
using Coti.Application.Interface;
using Coti.Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Coti.Api.Controllers.api
{
    [Route("auth")]
    public class AuthController : BaseController
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;
        private readonly JwtToken jwtToken;

        public AuthController(IUsuarioApplicationService usuarioApplicationService, JwtToken jwtToken)
        {
            this.usuarioApplicationService = usuarioApplicationService;
            this.jwtToken = jwtToken;
        }

        [HttpPost("acesso")]
        public IActionResult Post(UsuarioAcessoModel itm)
        {
            try
            {
                var usuarioDTO = usuarioApplicationService.GetAccess(itm);

                if (usuarioDTO == null)
                {
                    throw new Exception("Acesso Negado. Usuário não encontrado.");
                }

                var appUser = new AppUserDTO()
                {
                    Usuario = usuarioDTO,
                    AccessToken = new AccessTokenDTO()
                    {
                        BearerToken = jwtToken.GenerateToken(usuarioDTO.Email),
                        Expiration = DateTime.Now.AddDays(1)
                    }
                };
                
                return StatusCode(200, appUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
