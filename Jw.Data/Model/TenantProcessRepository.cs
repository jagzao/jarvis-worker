using Jw.Common.Models;
using Jw.Data.Contract;
using Jw.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Data.Model
{
    public class TenantProcessRepository : ITenantProcessRepository
    {
        private readonly JarvisDbContext _dbContext;
        public TenantProcessRepository(JarvisDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DtTenantProcess> Get()
        {
            var result = _dbContext.TenantProcesses
                    .Where(s => s.Active)
                    .Select(s => new DtTenantProcess
                    {
                        Id = s.Id,
                        IsRunning = s.IsRunning,
                        ProcessId = s.ProcessId,
                        TenantId = s.TenantId,
                        TimeEnd = s.TimeEnd,
                        TimeStart = s.TimeStart
                    })
                    .ToList();
            return result;
        }

        public List<DtTenantProcess> GetByTime()
        {
            var today = DateTime.Now;
            var time = today.TimeOfDay;

            var result = _dbContext.TenantProcesses
                    .Where(s => 
                        s.Active 
                        //&& time > s.TimeStart && time < s.TimeEnd
                        //&& s.Worked.Date != today
                        )
                    .Select(s => new DtTenantProcess
                    {
                        Id = s.Id,
                        IsRunning = s.IsRunning,
                        ProcessId = s.ProcessId,
                        TenantId = s.TenantId,
                        TimeEnd = s.TimeEnd,
                        TimeStart = s.TimeStart
                    })
                    .ToList();
            return result;
        }

        public void UpdateTenantProcess(ProcessWorker tenantProcess)
        {
            try
            {
                var item = _dbContext.TenantProcesses.Find(tenantProcess.tenantProcess.Id);
                item.IsRunning = tenantProcess.IsWorking;
                item.Worked = DateTime.Now;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
