using Domain.PermissionTypes;

namespace Infrastructure.PermissionTypes
{
    public class PermissionsTypesRepository : IPermissionTypesRepository
    {
        private readonly SecurityContext databaseContext;

        public PermissionsTypesRepository(SecurityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
