using Jw.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Data.Contract
{
    public class ProcessRepository : IProcessRepository
    {
        public List<Process> Processs { get; set; } = new List<Process>();

        public bool Create(Process process)
        {
            return false;
        }

        public bool Delete(int IdProcess)
        {
            return false;
        }

        public List<Process> Get() 
        {
            return Processs; 
        }
        public List<Process> Get(int IdProcess)
        {
            return Processs;
        }

        public bool Update(Process process)
        {
            return false;
        }
    }
}
