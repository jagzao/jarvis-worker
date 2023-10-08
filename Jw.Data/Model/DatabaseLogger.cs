using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Data.Model
{
    public class DatabaseLogger : ILogger
    {
        private readonly string _connectionString;
        public DatabaseLogger(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            // Implementa aquí la lógica para escribir el registro en la base de datos
            // Puedes usar el _connectionString para establecer la conexión a la base de datos y guardar el registro
            var message = formatter(state, exception);

            string mensaje = $"{eventId.Id} | {logLevel} - {message}";

            Console.WriteLine("_____________________________________________________________________________________________");
            Console.WriteLine(mensaje);
            Console.WriteLine("_____________________________________________________________________________________________");
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // Implementa aquí la lógica para verificar si el nivel de log está habilitado
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
