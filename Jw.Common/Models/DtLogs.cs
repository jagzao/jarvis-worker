using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Common.Models
{
    public class DtLogs
    {
        public int Id { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        public int IdLog { get; set; }
        public string Path { get; set; }

        public int? IdProcess { get; set; }
    }
}
