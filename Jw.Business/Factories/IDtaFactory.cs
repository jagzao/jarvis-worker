using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jw.Business.Contracts;

namespace Jw.Business.Factories
{
    /// <summary>
    /// Expone cada clase/tabla en DB | c/u expone sus props CRUDS a la tabla correspondiente
    /// </summary>
    public interface IDtaFactory
    {
        ITenantProcessManager GetTenantProcessRepository();
        ITenantManager GetTenantRepository();
        IUserManager GetUserRepository();
    }
}
