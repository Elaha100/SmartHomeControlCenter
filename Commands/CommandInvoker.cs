using SmartHomeControlCenter.Core;

namespace SmartHomeControlCenter.Commands
{
    public class CommandInvoker
    {
        private readonly List<ICommand> _history = new List<ICommand>();
        private readonly Logger _logger = Logger.Instance;

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Add(command);
            _logger.Log($"Kommando kördes: {command.Name}");
        }

        public void PrintHistory()
        {
            Console.WriteLine("\n===== COMMAND HISTORY =====");
            if (_history.Count == 0)
            {
                Console.WriteLine("Ingen historik ännu.");
                return;
            }

            for (int i = 0; i < _history.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_history[i].Name}");
            }
        }

        public void ReplayLastFive()
        {
            Console.WriteLine("\n===== REPLAY SENASTE 5 =====");

            var lastFive = _history.TakeLast(5).ToList();

            if (lastFive.Count == 0)
            {
                Console.WriteLine("Ingen historik att spela upp.");
                return;
            }

            foreach (var command in lastFive)
            {
                Console.WriteLine($"Replay -> {command.Name}");
                command.Execute();
            }
        }

        public int GetLoggerInstanceId()
        {
            return _logger.GetInstanceId();
        }
    }
}