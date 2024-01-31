using Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Permission
{
    public class PermissionsRepository : IPermissionsRepository
    {
        private readonly SecurityContext databaseContext;

        public PermissionsRepository(SecurityContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
