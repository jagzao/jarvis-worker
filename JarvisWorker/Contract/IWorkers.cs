using Jw.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarvisWorker.Contract
{
    public interface IWorkers
    {
        List<ProcessWorker> GetProcess(IServiceScope scope);
    }
}
