using BuiltCode.Application.AppServices.PacienteAppService;
using BuiltCode.Application.Dto.PacienteViewModel;
using BuiltCode.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BuiltCode.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/paciente")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteAppService _pacienteAppService;
        public PacienteController(IPacienteAppService pacienteAppService, INotificador notificador) : base(notificador)
        {
            _pacienteAppService = pacienteAppService;
        }

        [HttpGet("listar-pacientes")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _pacienteAppService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpPost("cadastrar-paciente")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> CadastrarMedico(PacienteRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _pacienteAppService.Cadastrar(viewModel);

            return CustomResponse(result);
        }

        [HttpPut("editar-paciente/{id}")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> EditarMedico(Guid id, PacienteRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _pacienteAppService.Atualizar(id, viewModel);

            return CustomResponse(result);
        }

        [HttpDelete("excluir-paciente/{id}")]
        [Authorize(Roles = "Admin,Atendente")]
        public async Task<IActionResult> ExcluirMedico(Guid id)
        {
            if (id == Guid.Empty)
            {
                NotificarErro("Id deve ser informado!");
            }

            await _pacienteAppService.Excluir(id);

            return CustomResponse();
        }
    }
}
