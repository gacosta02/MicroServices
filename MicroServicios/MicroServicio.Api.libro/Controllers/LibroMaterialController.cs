
using System.Threading.Tasks;
using MediatR;
using MicroServicio.Api.libro.Apps;
using Microsoft.AspNetCore.Mvc;

namespace MicroServicio.Api.libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data) 
        {
            return await _mediator.Send(data);
        }
    }
}
