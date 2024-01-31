using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace N5_Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public SecurityController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper;
        }


        [HttpPost("RequestPermission")]
        public bool RequestPermission()
        {
            return true;
        }
    }
}