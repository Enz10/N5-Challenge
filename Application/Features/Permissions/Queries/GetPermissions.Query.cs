using Common.Utils;
using Domain.Permissions.Entities;
using MediatR;
using Sieve.Models;

namespace Application.Features.Permissions.Queries
{
    public sealed partial class GetPermissions
    {
        public sealed class Query : SieveModel, IRequest<CollectionResult<Permission>>
        {

        }
    }
}
