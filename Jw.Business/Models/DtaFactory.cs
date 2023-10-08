using Jw.Business.Contracts;
using Jw.Business.Factories;

namespace Jw.Business.Models
{
    public class DtaFactory : IDtaFactory
    {
        ITenantProcessManager tenantProcessManager;
        ITenantManager tenantManager;
        IUserManager userManager;
        public DtaFactory(
            ITenantProcessManager tenantProcessManager, 
            ITenantManager tenantManager, 
            IUserManager userManager)
        {
            this.tenantProcessManager = tenantProcessManager;
            this.tenantManager = tenantManager;
            this.userManager = userManager;

        }
        public ITenantProcessManager GetTenantProcessRepository()
        {
            return tenantProcessManager;
        }

        public ITenantManager GetTenantRepository()
        {
            return tenantManager;
        }

        public IUserManager GetUserRepository()
        {
            return userManager;
        }
    }
}
