using Jw.Common.Enums;

namespace Jw.Common.Models
{
    public class ProcessWorker
    {
        //public ProcessWorker(EnumProcess.Process process)
        //{
        //    Name = process.ToString();
        //}
        public string Name { get; set; }
        public DtTenantProcess tenantProcess { get; set; }
        public bool IsWorking { get; set; } = false;
        public TimeSpan Elapsed { get; set; } = TimeSpan.Zero;
        public EnumProcess.Process process { get; set; }
    }
}
