using Domain.PermissionAsignments;

namespace Infrastructure.PermissionAsignments
{
    public class PermissionAsignmentsRepository : IPermissionAsignmentsRepository
    {
        private readonly SecurityContext databaseContext;

        public PermissionAsignmentsRepository(SecurityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
