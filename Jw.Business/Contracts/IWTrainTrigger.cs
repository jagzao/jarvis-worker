using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Contracts
{
    /// <summary>
    /// Lanzador de ejercicios cada cierto tiempo para descansar, a modo Pomodoro
    /// Ej: Cada 40 minutos, abrir video de 1 ejercicio aleatorio, con contador de unos segundos
    /// </summary>
    internal interface IWTrainTrigger
    {
        void RunProcess();
        bool IsTrainNeed();
        void LaunchVideo();
    }
}
