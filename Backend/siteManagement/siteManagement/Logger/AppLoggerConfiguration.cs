using Serilog;
using Serilog.Events;
using System.Reflection;

namespace siteManagement.Logger
{
    public class AppLoggerConfiguration
    {
        public static Serilog.Core.Logger CreateLogger()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Logs/SiteManagement.log");

            return new LoggerConfiguration()
           .WriteTo.File(path, rollingInterval: RollingInterval.Day)
           .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
           .MinimumLevel.Override("System", LogEventLevel.Fatal)
           .MinimumLevel.Information()
           .CreateLogger();

        }
    }
}
