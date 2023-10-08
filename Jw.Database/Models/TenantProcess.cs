using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jw.Database.Models
{
    public class TenantProcess
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Tenant")]
        public int TenantId { get; set; }

        [ForeignKey("Process")]
        public int ProcessId { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public bool IsRunning { get; set; }
        public DateTime Worked { get; set; }
        public bool Active { get; set; }

        public virtual Tenant Tenant { get; set; }
        public virtual Process Process { get; set; }
    }
}
