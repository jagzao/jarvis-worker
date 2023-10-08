using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Common.Models
{
    public class DtTenantProcess
    {
        public int Id { get; set; }

        public int TenantId { get; set; }

        public int ProcessId { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public bool IsRunning { get; set; }
    }
}
