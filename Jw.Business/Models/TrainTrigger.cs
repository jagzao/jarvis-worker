using Jw.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Model
{
    public class TrainTrigger : IWTrainTrigger
    {
        public void RunProcess()
        {
            if (IsTrainNeed())
            {
                LaunchVideo();
            }
        }

        public void LaunchVideo()
        {
        }

        public bool IsTrainNeed()
        {
            return false;
        }
    }
}
