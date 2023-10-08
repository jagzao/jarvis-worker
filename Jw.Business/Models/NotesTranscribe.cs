using Jw.Business.Contracts;
using Jw.Common.Helper;
using Jw.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Jw.Business.Models
{
    public class NotesTranscribe : INotesTranscribe
    {
        List<DtNoteTranscribe> lstNotes = new List<DtNoteTranscribe>();
        string webAudio = "C:\\Users\\JAGZA\\Desktop\\Anotes\\webAudio";
        string mp3Audio = "C:\\Users\\JAGZA\\Desktop\\Anotes\\audioMp3";
        
        string ffmpegPath = "C:\\ffmpeg\\bin\\ffmpeg.exe";
        string ffVideoAudio = "-vn -acodec copy";
        string ffMp4ToMp3 = "-vn -c:a libmp3lame";
        string ffVideoToV264 = "-c:v libx264 -crf 23 - c:a copy";

        // Add Logs
        // Add status to   => Process
        // Add timeout end => Process
        public async Task<bool> RunProcess()
        {
            ReadFolder();
            //SelectFileName();
            foreach (var note in lstNotes)
            {
                try
                {
                    var resultWebm = FfmpegProcess(note, webAudio, ffVideoAudio, "webm").Result;
                    var resultMp3 = FfmpegProcess(note, mp3Audio, ffMp4ToMp3, "mp3").Result;

                    // Si convierte MP3 no necesito el webmAudio
                    if (resultMp3.Success)
                    {
                        FileMethods.Delete(resultWebm.Message);

                        // Mover a Backup Storage
                        string folderToMove = "C:\\Users\\JAGZA\\Desktop\\PTrecord";
                        
                        FileMethods.Move(note.Path, $"{folderToMove}\\{note.Name}.webm");
                        // Guardar newPath en DB para uso de Bitacoras

                        //ConnectToGoogleCardboard();                        

                        await OpenWistle(note, resultMp3.Message, "--fp16 false --model medium", "txt");
                        UploadMp3();
                        Process();
                        DownloadTxtFile();
                        MoveVideoTxt();
                        DeleteFilesInFolder();
                        ConnectToChatGpt();
                        SendToChatGpt();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return await Task.FromResult(true);
        }

        public void ReadFolder()
        {
            var lstFiles = FileMethods.GetFilesInFolder("C:\\Users\\JAGZA\\Desktop\\Anotes");
            var lstFilesMp3 = FileMethods.GetFilesInFolder("C:\\Users\\JAGZA\\Desktop\\Anotes\\audioMp3");
            
            lstNotes.AddRange(lstFiles.Select(s => new DtNoteTranscribe
            {
                Name = s.Item1,
                Path = s.Item2
            }));
            lstNotes.AddRange(lstFilesMp3.Select(s => new DtNoteTranscribe
            {
                Name = s.Item1,
                Path = s.Item2,
                type = "mp3"
            }));
        }

        public async Task<DtResult> FfmpegProcess(DtNoteTranscribe dtNote, string filePath, string command, string type)
        {
            string newPath = $"{filePath}\\{dtNote.Name}.{type}";
            var result = new DtResult { Success = true };
            try
            {
                //ffmpeg          - i Ivode.webm -vn -acodec copy               audio.webm
                //ffmpeg          - i audio.webm -vn -c:a libmp3lame            audio.mp3
                //ffmpeg          - i Haibal.mp4 -c:v libx264 -crf 23 - c:a copy output.mp4

                if (File.Exists(newPath))
                    return new DtResult { Success=true, Message= newPath };

                IProgress<int> progress = new Progress<int>(percent => Console.WriteLine($"Progreso: {percent}%"));

                string arguments = $"-i \"{dtNote.Path}\" {command} \"{newPath}\"";
                var methods = new ProcessMethods();
                result = await methods.RunProcessFfmpeg(ffmpegPath, arguments, dtNote, progress);
                result.Message = newPath;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        //  https://colab.research.google.com/drive/1WLYoBvA3YNKQ0X2lC9udUOmjK7rZgAwr?usp=sharing#scrollTo=-1pP466t8kpv
        //public void ConnectToGoogleCardboard()
        //{
        //}

        public async Task<DtResult> OpenWistle(DtNoteTranscribe dtNote, string filePath, string command, string type)
        {
            string newPath = ""; // $"{filePath}\\{dtNote.Name}.{type}";
            var result = new DtResult { Success = true };

            IProgress<int> progress = new Progress<int>(percent => Console.WriteLine($"Progreso: {percent}%"));
            
            string arguments = $"whisper \"{dtNote.Path}\" {command}";
            var methods = new ProcessMethods();
            result = await methods.RunProcessWhisper("whisper", arguments, dtNote, progress);
            result.Message = newPath;

            return result;
        }

        public void UploadMp3()
        {
        }

        public void Process()
        {
        }

        public void DownloadTxtFile()
        {
        }

        public void MoveVideoTxt()
        {
        }

        public void DeleteFilesInFolder()
        {
        }

        public void ConnectToChatGpt()
        {
        }
        public void SendToChatGpt()
        {
            string prompt = "Añade a tu base de conocimiento el siguiente texto: ";
        }

        public string TxtTranscribe()
        {
            return "";
        }

    }
}
