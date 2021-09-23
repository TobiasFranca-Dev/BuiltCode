using BuiltCode.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace BuiltCode.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/parceiro")]
    public class ParceiroController : ControllerBase
    {
        public ParceiroController(INotificador notificador) : base(notificador)
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
