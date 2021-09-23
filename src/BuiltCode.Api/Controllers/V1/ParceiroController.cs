using BuiltCode.Application.AppServices.ParceiroAppService;
using BuiltCode.Application.Dto.ParceiroViewModel;
using BuiltCode.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BuiltCode.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/parceiro")]
    public class ParceiroController : ControllerBase
    {
        private readonly IParceiroAppService _parceiroAppService;
        public ParceiroController(IParceiroAppService parceiroAppService, INotificador notificador) : base(notificador)
        {
            _parceiroAppService = parceiroAppService;
        }


        [HttpGet("listar-parceiros")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _parceiroAppService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpPost("cadastrar-parceiro")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cadastrar(ParceiroRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _parceiroAppService.Cadastrar(viewModel);

            return CustomResponse(result);
        }

        [HttpPatch("alterar-chave/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AlterarChave(Guid id)
        {
            if (id == Guid.Empty)
            {
                NotificarErro("Id do parceiro deve ser preenchido!");
                return CustomResponse();
            };

            var result = await _parceiroAppService.AlterarApiKey(id);

            return CustomResponse(result);
        }
    }
}
