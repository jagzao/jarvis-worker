using Jw.Common.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Common.Helper
{
    public class ProcessMethods
    {
        public async Task<DtResult> RunProcessFfmpeg(string processPath, string arguments, DtNoteTranscribe dtNote, IProgress<int> progress)
        {
            var result = new DtResult { Success = true };
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = processPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = new Process { StartInfo = processInfo })
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrWhiteSpace(e.Data) && int.TryParse(e.Data, out int progressValue))
                        {
                            progress.Report(progressValue); // Reportar el progreso
                        }
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        Console.WriteLine($"Error en la salida de FFmpeg: {e.Data}");
                    };

                    process.Start();
                    //process.WaitForExit();
                    process.BeginOutputReadLine(); // Iniciar la lectura de la salida estándar
                    process.BeginErrorReadLine();  // Iniciar la lectura de la salida de error

                    await Task.Run(() => process.WaitForExit()); // Esperar de forma asincrónica


                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine($"Comando ejecutado correctamente de {dtNote.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"Error al extraer el audio de {dtNote.Name}");
                        result.Success = false;
                        result.Message = "Error en la conversión.";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion: {ex}");
            }
            return result;
        }
        public async Task<DtResult> RunProcessWhisper(string processPath, string arguments, DtNoteTranscribe dtNote, IProgress<int> progress)
        {
            var result = new DtResult { Success = true };
            try
            {
                var processInfo = new ProcessStartInfo
                {
                    FileName = processPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                using (Process process = new Process { StartInfo = processInfo })
                {
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrWhiteSpace(e.Data) && int.TryParse(e.Data, out int progressValue))
                        {
                            progress.Report(progressValue); // Reportar el progreso
                        }
                    };

                    process.ErrorDataReceived += (sender, e) =>
                    {
                        Console.WriteLine($"Error en la salida de FFmpeg: {e.Data}");
                    };

                    process.Start();
                    process.BeginOutputReadLine(); // Iniciar la lectura de la salida estándar
                    process.BeginErrorReadLine();  // Iniciar la lectura de la salida de error

                    await Task.Run(() => process.WaitForExit());

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine($"Comando ejecutado correctamente de {dtNote.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"Error al extraer el audio de {dtNote.Name}");
                        result.Success = false;
                        result.Message = "Error en la conversión.";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepcion: {ex}");
            }
            return result;
        }
    }
}
