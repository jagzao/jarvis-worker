// Program.cs
using JarvisWorker;
using Jw.Business.Contracts;
using Jw.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Jw.Business.Factories;
using Jw.Business.Models;
using Jw.Data.Contract;
using Jw.Data.Model;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

//string connectionString = configuration.GetConnectionString("JarvisConnection");
//using (SqlConnection connection = new SqlConnection(connectionString))
//{
//    try
//    {
//        connection.Open();
//        Console.WriteLine("***************************************");
//        Console.WriteLine("La conexión se estableció exitosamente.");
//        Console.WriteLine("***************************************");
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Error al establecer la conexión: {ex.Message}");
//    }
//}

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<JarvisDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("JarvisConnection"));
        });

        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddProvider(new DatabaseLoggerProvider(configuration.GetConnectionString("JarvisConnection")));
        });
        
        services.AddScoped<IDtaFactory, DtaFactory>();
        services.AddScoped<IBsFactory, BsFactory>();
        services.AddScoped<ISrvFactory, SrvFactory>();

        services.AddScoped<ITenantProcessManager, TenantProcessManager>();
        services.AddScoped<ITenantManager, TenantManager>();
        services.AddScoped<IUserManager, UserManager>();
        services.AddScoped<INotionAlerts, NotionAlerts>();
        services.AddScoped<INotionToDo, NotionToDo>();
        services.AddScoped<IGitUpdater, GitUpdater>();
        services.AddScoped<INotesTranscribe, NotesTranscribe>();
        

        services.AddScoped<IDataFactory, DataFactory>();
        services.AddScoped<IProcessRepository, ProcessRepository>();
        services.AddScoped<ITenantProcessRepository, TenantProcessRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
