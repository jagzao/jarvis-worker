using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Contracts
{
    public interface INotionAlerts
    {
        Task<bool> RunProcess();

        void ConnectService();
        void ReadData();
        void WriteData();
        void UpdateNotification();
        void SendNotification();
    }
}
