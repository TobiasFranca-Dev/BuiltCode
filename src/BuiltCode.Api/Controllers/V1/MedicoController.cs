using BuiltCode.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace BuiltCode.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/medico")]
    public class MedicoController : ControllerBase
    {
        public MedicoController(INotificador notificador): base(notificador)
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
