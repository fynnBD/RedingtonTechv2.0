using System.Globalization;
using System.Text;
using ReadingtonTech.Models.Interfaces;
using ReadingtonTech.Services.Interfaces;
using static System.String;

namespace ReadingtonTech.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly string _logDirectory;
        private readonly string _logFilePrefix;
        private const string LogString = "{0}: Successful Calculation for {1} and type {2}. Result was {3}";
        private const string LogFailString = "{0}: Failed Calculation for {1} and type {2}. Error was {3}";

        public LoggingService()
        {
            _logDirectory = System.Configuration.ConfigurationManager.AppSettings["Logging:LoggingDirectory"]
                           ?? Directory.GetCurrentDirectory();

            _logFilePrefix = System.Configuration.ConfigurationManager.AppSettings["Logging:logFilePrefix"]
                            ?? "\\RedingtonLog_";
        }

        public async Task LogResult(IProbabilityOutput result)
        {
            DateTime current = DateTime.Now;
            string path = _logDirectory + _logFilePrefix + current.ToString("yy-MM-dd") + ".txt";

            FileStream fs;
            StreamWriter sw;

            if (!File.Exists(path))
            {
                fs = File.Create(path);
            }
            else
            {
                fs = File.Open(path, FileMode.Append);
            }

            sw = new StreamWriter(fs);
            await sw.WriteLineAsync(FormatLogLine(result, current));
            sw.Close();
        }

        public string GetLogStringFromResult(IProbabilityOutput result)
        {
            return FormatLogLine(result, DateTime.Now);
        }

        private string FormatLogLine(IProbabilityOutput result, DateTime current)
        {
            StringBuilder sb = new StringBuilder();

            if (result.isValid)
            {
                sb.Append(Format(LogString, current.ToShortDateString(), GetStringFromValues(result.Values), result.CalculationType, result.result));
            }
            else
            {
                sb.Append(Format(LogFailString, current.ToShortDateString(), GetStringFromValues(result.Values), result.CalculationType, result.errorReason));
            }

            return sb.ToString();
        }

        private string GetStringFromValues(decimal[] values) => Join(",",
            values.Select(x => x.ToString(CultureInfo.InvariantCulture)).ToArray());
    }
}
