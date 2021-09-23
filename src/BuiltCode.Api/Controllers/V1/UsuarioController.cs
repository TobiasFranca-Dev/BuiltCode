using BuiltCode.Application.AppServices.UsuarioAppService;
using BuiltCode.Application.Dto.UsuariosViewModel;
using BuiltCode.Domain.Core.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BuiltCode.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService, INotificador notificador) : base(notificador)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet("listar-usuarios")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ObterTodos()
        {
            var result = await _usuarioAppService.ObterTodos();
            return CustomResponse(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _usuarioAppService.Login(viewModel);

            return CustomResponse(result);
        }

        [HttpPost("cadastrar-usuario")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Cadastrar(UsuarioRegistroViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _usuarioAppService.Adicionar(viewModel);

            return CustomResponse(result);
        }
    }
}