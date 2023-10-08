using Jw.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Data.Contract
{
    public interface IProcessRepository
    {
        List<Process> Get();
        List<Process> Get(int IdProcess);
        bool Create(Process process);
        bool Update(Process process);
        bool Delete(int IdProcess);
    }
}
