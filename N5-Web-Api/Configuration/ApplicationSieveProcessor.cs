using Application.Features.Permissions.Queries;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace N5_Web_Api.Configuration;

public class ApplicationSieveProcessor : SieveProcessor
{
    public ApplicationSieveProcessor(
        IOptions<SieveOptions> options)
    : base(options)
    {
    }

    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        PermissionsSieveConfiguration.ConfigureFilters(mapper);

        return mapper;
    }
}
