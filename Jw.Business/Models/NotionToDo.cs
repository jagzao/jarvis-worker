using Jw.Business.Contracts;

namespace Jw.Business.Models
{
    public class NotionToDo : INotionToDo
    {
        public void ConnectService()
        {
        }

        public void ReadData()
        {
        }

        public async Task<bool> RunProcess()
        {
            return await Task.FromResult(true);
        }

        public void UpdateMicrosoftTasks()
        {
        }

        public void WriteData()
        {
        }
    }
}