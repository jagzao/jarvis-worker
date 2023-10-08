using Jw.Business.Contracts;
using Jw.Common.Helper;
using Jw.Common.Models;
using Jw.Data.Contract;

namespace Jw.Business.Models
{
    public class TenantProcessManager : ITenantProcessManager
    {
        private readonly IDataFactory dataFactory;
        public TenantProcessManager(IDataFactory _dataFactory)
        {
            dataFactory = _dataFactory;
        }

        public List<DtTenantProcess> Get()
        {
            return dataFactory.GetTenantProcessRepository().Get();
        }

        public List<ProcessWorker> GetByTime()
        {
            var result = new List<ProcessWorker>();
            var list = dataFactory.GetTenantProcessRepository().GetByTime();
            foreach (var t in list)
            {
                var pw = t.ParseObject<ProcessWorker>();
                result.Add(pw);
            }
            return result;
        }

        public void UpdateTenantProcess(ProcessWorker tenantProcess)
        {
            dataFactory.GetTenantProcessRepository().UpdateTenantProcess(tenantProcess);
        }
    }
}
