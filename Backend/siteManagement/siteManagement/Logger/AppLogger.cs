using System.Text;

namespace siteManagement.Logger
{
    public class AppLogger
    {
        public Serilog.Core.Logger _logger;

        public AppLogger()
        {
            _logger = AppLoggerConfiguration.CreateLogger();
        }

        public void ErrorLog(string? message, string stackTrace = "None", string path = "None")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("MESSAGE:");
            sb.AppendLine(message);
            sb.AppendLine();
            sb.AppendLine();


            _logger.Error(sb.ToString());
        }
    }
}
