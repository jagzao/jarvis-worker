using Microsoft.Extensions.Logging;

namespace Jw.Data.Model
{
    public class DatabaseLoggerProvider : ILoggerProvider
    {
        private readonly string _connectionString;

        public DatabaseLoggerProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new DatabaseLogger(_connectionString);
        }

        public void Dispose()
        {
        }
    }

}
