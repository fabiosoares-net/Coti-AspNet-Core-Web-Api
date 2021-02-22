using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coti.Application.Interface;
using Coti.Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Coti.Api.Controllers.api
{
    [Route("usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;

        public UsuarioController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost("post")]
        public IActionResult Post(UsuarioFormModel itm)
        {
            try
            {
                var usuarioDTO = usuarioApplicationService.Post(itm);

                return StatusCode(201, new
                {
                    Message = "Usuário cadastrado com sucesso.",
                    Usuario = usuarioDTO
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message}); 
            }
        }
    }
}
