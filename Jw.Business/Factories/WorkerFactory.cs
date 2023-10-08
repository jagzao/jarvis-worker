using Jw.Business.Contracts;
using Jw.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Factories
{
    public class WorkFactory : IWorkFactory
    {
        public IGitUpdater CreateGitUpdater()
        {
            return new GitUpdater();
        }

        public INotesTranscribe CreateNotesTranscribe()
        {
            return new NotesTranscribe();
        }

        public INotionToDo CreateNotionToDo()
        {
            return new NotionToDo();
        }

        public INotionAlerts CreateNotionAlerts()
        {
            return new NotionAlerts();
        }
    }
}
