using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Database.Models
{
    public class Log
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLog { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Path { get; set; }
        public int? IdProcess { get; set; }
    }
}
