using System.Text;

namespace SmartHomeControlCenter.Core
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();
        private readonly List<string> _logs = new List<string>();

        public static Logger Instance => _instance;

        private Logger()
        {
        }

        public void Log(string message)
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] {message}";
            _logs.Add(entry);
            Console.WriteLine($"[LOGGER] {entry}");
        }

        public void PrintAllLogs()
        {
            Console.WriteLine("\n===== ALLA LOGGAR =====");
            foreach (var log in _logs)
            {
                Console.WriteLine(log);
            }
        }

        public int GetInstanceId()
        {
            return GetHashCode();
        }
    }
}