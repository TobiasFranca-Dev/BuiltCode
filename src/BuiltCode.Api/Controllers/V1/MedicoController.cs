using BuiltCode.Application.AppServices.MedicoAppService;
using BuiltCode.Application.Attributes;
using BuiltCode.Application.Dto.MedicoViewModel;
using BuiltCode.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BuiltCode.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/medico")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoAppService _medicoAppService;

        public MedicoController(IMedicoAppService medicoAppService, INotificador notificador) : base(notificador)
        {
            _medicoAppService = medicoAppService;
        }

        [HttpGet("listar-medicos")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _medicoAppService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpPost("cadastrar-medico")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> CadastrarMedico(MedicoRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _medicoAppService.Cadastrar(viewModel);

            return CustomResponse(result);
        }

        [HttpPut("editar-medico/{id}")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> EditarMedico(Guid id, MedicoRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _medicoAppService.Atualizar(id, viewModel);

            return CustomResponse(result);
        }

        [HttpDelete("excluir-medico/{id}")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> ExcluirMedico(Guid id)
        {
            if (id == Guid.Empty)
            {
                NotificarErro("Id deve ser informado!");
            }

            await _medicoAppService.Excluir(id);

            return CustomResponse();
        }


        [ApiKey]
        [HttpGet("listar-medicos-parceiro")]
        public async Task<IActionResult> ObterTodosParceiro([FromQuery] string ufCrm)
        {
            if (string.IsNullOrEmpty(ufCrm))
            {
                return CustomResponse(await _medicoAppService.ObterTodos());
            }

            if(ufCrm.Length > 2)
            {
                NotificarErro("ufCrm deve possuir 2 caracteres!");
                return CustomResponse();
            }

            var result = await _medicoAppService.ObterPorUfCrm(ufCrm);

            return CustomResponse(result);
        }
    }
}
