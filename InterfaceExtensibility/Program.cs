using System;

namespace InterfaceExtensibility
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogException(Exception exception);
    }
    public class ConsoleLogger : ILogger
    {
        #region ILogger Members

        public void LogInfo(string message)
        {
            Console.WriteLine(message);

        }

        public void LogError(string message)
        {
            Console.WriteLine(message);

        }

        public void LogException(Exception exception)
        {
            Console.WriteLine(exception.Message);

        }

        #endregion
    }
    public class FileLogger : ILogger
    {
        #region ILogger Members

        public void LogInfo(string message)
        {
            throw new NotImplementedException();
        }

        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogException(Exception exception)
        {
            throw new NotImplementedException();
        }

        #endregion
    }



    public class DBMigrator
    {
        private readonly ILogger _Logger;
        public DBMigrator(ILogger logger)
        {
            _Logger = logger;
        }
        public void Migrate()
        {
            try
            {
                _Logger.LogInfo("Migration Started at {0} " + DateTime.Now);
                _Logger.LogError("Migration Finished at {0} " + DateTime.Now);

            }
            catch (Exception ex)
            {
                _Logger.LogException(ex);
                throw;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            DBMigrator _dBMigrator = new DBMigrator(new ConsoleLogger());
            _dBMigrator.Migrate();
        }
    }
}
