using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Data.Contract
{
    public interface IDataFactory
    {
        IProcessRepository GetProcessRepository();
        ITenantProcessRepository GetTenantProcessRepository();
        IUserRepository GetUserRepository();
    }
}
