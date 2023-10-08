using Jw.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Models
{
    public class NotionAlerts : INotionAlerts
    {
        public async Task<bool> RunProcess()
        {
            ConnectService();
            ReadData();
            WriteData();
            SendNotification();
            UpdateNotification();
            return await Task.FromResult(true);
        }

        public void ConnectService()
        {
        }

        public void ReadData()
        {
        }

        public void WriteData()
        {
        }
        public void SendNotification()
        {
        }

        public void UpdateNotification()
        {
        }

    }
}
