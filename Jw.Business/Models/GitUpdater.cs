using Jw.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Models
{
    public class GitUpdater : IGitUpdater
    {
        public async Task<bool> RunProcess()
        {
            Console.WriteLine("RunProcess");
            //_ = Fetch();
            if (HasChanges())
            {
                NotifyChanges();
            }
            return await Task.FromResult(true);
        }
        public void Fetch()
        {
            Console.WriteLine("Fetching");
        }

        public bool HasChanges()
        {
            Console.WriteLine("HasChanges");
            return false;
        }

        public void NotifyChanges()
        {
            Console.WriteLine("NotifyChanges");
        }

    }
}
