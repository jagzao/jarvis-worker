using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Common.Models
{
    public class DtUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public int TenantId { get; set; }
    }
}
