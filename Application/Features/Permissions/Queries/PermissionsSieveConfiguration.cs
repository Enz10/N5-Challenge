using Domain.Permissions.Entities;
using Sieve.Services;

namespace Application.Features.Permissions.Queries;

public static class PermissionsSieveConfiguration
{
    public static void ConfigureFilters(SievePropertyMapper mapper)
    {
        mapper.Property<Permission>(p => p.Id)
              .CanSort()
              .CanFilter();

        mapper.Property<Permission>(p => p.EmployeeName)
              .CanSort()
              .CanFilter();

        mapper.Property<Permission>(p => p.EmployeeSurname)
              .CanSort()
              .CanFilter();

        mapper.Property<Permission>(p => p.PermissionDate)
              .CanSort()
              .CanFilter();
    }
}
