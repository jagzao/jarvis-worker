//  Worker.cs
using JarvisWorker.Contract;
using Jw.Business.Contracts;
using Jw.Business.Factories;
using Jw.Common.Enums;
using Jw.Common.Helper;
using Jw.Common.Models;
using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;

namespace JarvisWorker
{
    public class Worker : BackgroundService , IWorkers
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, 
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public List<ProcessWorker> GetProcess(IServiceScope scope)
        {
            var tenantProcessManager = scope.ServiceProvider.GetRequiredService<IBsFactory>();

            var tenantProcesses = tenantProcessManager
                                    .GetDtFactory()
                                    .GetTenantProcessRepository()
                                    .GetByTime();
            return tenantProcesses;
        }
        private void UpdateTenantProcess(IServiceScope scope, ProcessWorker tenantProcess)
        {
            var bsFactory = scope.ServiceProvider.GetRequiredService<IBsFactory>();
            bsFactory.GetDtFactory().GetTenantProcessRepository().UpdateTenantProcess(tenantProcess);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker ejecutandose at: {time}", DateTimeOffset.Now);

                int maxTask = 5;
                using (var scope = _serviceProvider.CreateScope())
                {
                    var tenantProcesses = GetProcess(scope);

                    var tasksWorking = new List<Task>();
                    foreach (var tenantProcess in tenantProcesses.Take(maxTask))
                    {
                        if (!tenantProcess.IsWorking)
                            tasksWorking.Add(RunAsyncTask(tenantProcess, scope));
                    }
                    await Task.WhenAll(tasksWorking);
                }
            }
        }

        private async Task RunAsyncTask(ProcessWorker tenantProcess, IServiceScope scope)
        {
            try
            {
                var result = new TaskCompletionSource<object>();
                tenantProcess.IsWorking = true;
                UpdateTenantProcess(scope, tenantProcess);

                switch (tenantProcess.process)
                {
                    case EnumProcess.Process.NotionAlerts:
                        var alert = scope.ServiceProvider.GetRequiredService<INotionAlerts>();
                        await alert.RunProcess();
                        break;
                    case EnumProcess.Process.NotionToDo:
                        var todo = scope.ServiceProvider.GetRequiredService<INotionToDo>();
                        await todo.RunProcess();
                        break;
                    case EnumProcess.Process.GitUpdater:
                        var update = scope.ServiceProvider.GetRequiredService<IGitUpdater>();
                        await update.RunProcess();
                        break;
                    case EnumProcess.Process.NoteTranscribe:
                        var transcribe = scope.ServiceProvider.GetRequiredService<INotesTranscribe>();
                        await transcribe.RunProcess();
                        break;
                    case EnumProcess.Process.TrainTrigger:
                        break;
                    case EnumProcess.Process.DbPerformance:
                        break;
                    default:
                        break;
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing TenantProcess with ID {tenantProcess}: {ex.Message}");
            }

            tenantProcess.IsWorking = false;
            UpdateTenantProcess(scope, tenantProcess);
        }

    }
}
