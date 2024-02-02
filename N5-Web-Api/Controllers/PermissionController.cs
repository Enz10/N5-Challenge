using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5_Web_Api.Controllers.Dtos.Permissions;
using N5_Web_Api.Controllers.Dtos;
using System.Net.Mime;
using _Web_Api.Controllers.Dtos;
using Application.Features.Permissions.Queries;
using Domain.Permissions.Entities;
using Common.Utils;
using Application.Features.Permissions.Commands;

namespace N5_Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PermissionController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PermissionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PermissionDto>> RequestPermission([FromBody] CreateRequestPermissionRequest request, CancellationToken cancellationToken)
        {
            RequestPermission.Command command = mapper.Map<RequestPermission.Command>(request);

            Permission result = await mediator.Send(command, cancellationToken);

            Uri uri = new Uri($"permissions/{result.Id}", UriKind.Relative);

            return Created(uri, mapper.Map<PermissionDto>(result));
        }

        [HttpPut]
        [ProducesResponseType(typeof(PermissionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<PermissionDto>> ModifyPermission([FromQuery] int id, [FromBody] UpdatePermissionRequest request, CancellationToken cancellationToken)
        {
            ModifyPermission.Command command = mapper.Map<ModifyPermission.Command>(request);

            command.Id = id;

            await mediator.Send(command, cancellationToken);

            Permission result = await mediator.Send(command, cancellationToken);

            return Ok(mapper.Map<PermissionDto>(result));
        }

        [HttpGet]
        [ProducesResponseType(typeof(PermissionDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<ListResult<PermissionDto>>> GetPermissions([FromQuery] Query queryParameters, CancellationToken cancellationToken)
        {
            GetPermissions.Query query = mapper.Map<GetPermissions.Query>(queryParameters);

            CollectionResult<Permission> result = await mediator.Send(query, cancellationToken);

            return Ok(mapper.Map<ListResult<PermissionDto>>(result));
        }

        [ApiController]
        public class ErrorController : ControllerBase
        {
            [Route("/Error")]
            public IActionResult Error()
            {
                return Problem();
            }
        }
    }
}