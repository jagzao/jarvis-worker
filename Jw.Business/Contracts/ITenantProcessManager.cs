using Jw.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Contracts
{
    /// <summary>
    /// Expone los metodos a la BD para la clase/tabla
    /// </summary>
    public interface ITenantProcessManager
    {
        List<DtTenantProcess> Get();
        List<ProcessWorker> GetByTime();
        void UpdateTenantProcess(ProcessWorker tenantProcess);
    }
}
