using log4net;
using log4net.Config;
using System.IO;

namespace Loggin_Reporting.Utils
{
    public class Logger
    {
        private static Logger currentInstance;
        private readonly ILog log;

        private Logger()
        {
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            ConfigureLogger();
        }

        public static Logger Instance => currentInstance ?? (currentInstance = new Logger());

        public void ConfigureLogger()
        {
            FileInfo fileInfo = new FileInfo(@"Log4net.config");
            XmlConfigurator.Configure(fileInfo);
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Warning(string message)
        {
            log.Warn(message);
        }

        public void Debug(string message)
        {
            log.Debug(message);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void Fatal(string message)
        {
            log.Fatal(message);
        }
    }
}
