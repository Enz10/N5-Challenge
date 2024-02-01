using Common.Utils;
using Domain;
using Domain.Permissions.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

namespace Application.Features.Permissions.Queries
{
    public sealed partial class GetPermissions
    {
        public sealed class Handler : IRequestHandler<GetPermissions.Query, CollectionResult<Permission>>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly ISieveProcessor sieveProcessor;

            public Handler(IUnitOfWork unitOfWork, ISieveProcessor sieveProcessor)
            {
                this.unitOfWork = unitOfWork;
                this.sieveProcessor = sieveProcessor;
            }

            public async Task<CollectionResult<Permission>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = unitOfWork.PermissionsRepository.GetAllPermissionsQuery();

                var filteredQuery = sieveProcessor.Apply(request, query, applyPagination: false);
                var totalCount = await filteredQuery.CountAsync(cancellationToken);
                var paginatedQuery = sieveProcessor.Apply(request, filteredQuery, applyFiltering: false, applySorting: false);

                var permissions = await paginatedQuery.ToListAsync(cancellationToken);

                return new CollectionResult<Permission> ( permissions, request.PageSize ?? permissions.Count, ApplicationConstant.DEFAULT_PAGE_NUMBER, totalCount );
            }
        }
    }

}
