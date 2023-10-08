using Jw.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Business.Contracts
{
    public interface INotesTranscribe
    {
        Task<bool> RunProcess();

        string TxtTranscribe();
        void ReadFolder();

        Task<DtResult> FfmpegProcess(DtNoteTranscribe dtNote, string filePath, string command, string type);
        //void ConnectToGoogleCardboard();
        Task<DtResult> OpenWistle(DtNoteTranscribe dtNote, string filePath, string command, string type);
        //void UploadMp3();
        void Process();
        void DownloadTxtFile();
        void MoveVideoTxt();
        void DeleteFilesInFolder();
        void ConnectToChatGpt();
        void SendToChatGpt();
    }
}
