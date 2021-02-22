using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coti.Application.Interface;
using Coti.Application.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Coti.Api.Controllers.api
{
    [Authorize]
    [Route("dependente")]
    public class DependenteController : BaseController
    {
        private readonly IDependenteApplicationService dependenteApplicationService;

        public DependenteController(IDependenteApplicationService dependenteApplicationService)
        {
            this.dependenteApplicationService = dependenteApplicationService;
        }

        [HttpGet("get/{idFuncionario:int}")]
        public IActionResult Get(int idFuncionario)
        {
            try
            {
                return Ok(dependenteApplicationService.ListarDepedentePorFuncionario(idFuncionario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
