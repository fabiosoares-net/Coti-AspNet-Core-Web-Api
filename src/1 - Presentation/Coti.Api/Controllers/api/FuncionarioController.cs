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
    [Route("funcionario")]
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioApplicationService funcionarioApplicationService;

        public FuncionarioController(IFuncionarioApplicationService funcionarioApplicationService)
        {
            this.funcionarioApplicationService = funcionarioApplicationService;
        }

        [HttpPost("getall")]
        public IActionResult Get(FuncionarioFilter filter)
        {
            try
            {
                return Ok(funcionarioApplicationService.Query(filter));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpGet("get/{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var funcionario = funcionarioApplicationService.Get(id);

                if (funcionario == null)
                    return NotFound("Funcionário não encontrado.");

                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPost("post")]
        public IActionResult Post(CriacaoFuncionarioFormModel itm)
        {
            try
            {
                var funcionarioFormDTO = funcionarioApplicationService.Post(itm);

                return StatusCode(201, new
                {
                    Message = "Funcionário cadastrado com sucesso.",
                    Funcionario = funcionarioFormDTO
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpPut("put")]
        public IActionResult Put(EdicaoFuncionarioFormModel itm)
        {
            try
            {
                funcionarioApplicationService.Put(itm);

                return StatusCode(200, new { Message = "Funcionário atualizado com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }

        [HttpDelete("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                funcionarioApplicationService.Delete(id);

                return StatusCode(200, new { Message = "Funcionário excluído com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message });
            }
        }
    }
}
