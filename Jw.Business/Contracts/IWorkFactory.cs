using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Contracts
{
    public interface IWorkFactory
    {
        IGitUpdater CreateGitUpdater();
        INotesTranscribe CreateNotesTranscribe();
        INotionToDo CreateNotionToDo();
        INotionAlerts CreateNotionAlerts();
    }
}
