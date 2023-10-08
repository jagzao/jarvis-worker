using Jw.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Data.Contract
{
    public interface ITenantProcessRepository
    {
        List<DtTenantProcess> Get();
        List<DtTenantProcess> GetByTime();
        void UpdateTenantProcess(ProcessWorker tenantProcess);
    }
}
