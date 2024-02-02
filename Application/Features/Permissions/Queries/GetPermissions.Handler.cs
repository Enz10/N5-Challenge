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

                var processedQuery = sieveProcessor.Apply(request, query, applyFiltering: true, applySorting: true, applyPagination: true);

                var totalCount = await query.CountAsync(cancellationToken);

                var permissions = await processedQuery.ToListAsync(cancellationToken);

                return new CollectionResult<Permission>(permissions, request.PageSize ?? permissions.Count, request.Page ?? ApplicationConstant.DEFAULT_PAGE_NUMBER, totalCount);
            }
        }
    }
}
