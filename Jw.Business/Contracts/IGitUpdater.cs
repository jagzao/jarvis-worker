using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Contracts
{
    public interface IGitUpdater
    {
        Task<bool> RunProcess();
        void Fetch();
        bool HasChanges();
        void NotifyChanges();
    }
}
