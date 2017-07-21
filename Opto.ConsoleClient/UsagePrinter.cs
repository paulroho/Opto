using System;

namespace Opto.ConsoleClient
{
    public interface IUsagePrinter
    {
        void PrintCommonUsageInfo();
        void ShowUnknownCommand(string unknownCommand);
        void PrintCommandInfo(string commandHelpText);
    }

    public class UsagePrinter : IUsagePrinter
    {
        private readonly IConsoleWriter _consoleWriter;

        public UsagePrinter(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter ?? throw new ArgumentNullException(nameof(consoleWriter));
        }

        private void WriteLine(string message = null) => _consoleWriter.WriteLine(message);

        public void PrintCommonUsageInfo()
        {
            WriteLine("Usage: opto [-h | --help | /?]");
            WriteLine("       <command> [<args>]");
            WriteLine();
            WriteLine("These commands are available");
            WriteLine("   help             Show this help screen");
            WriteLine("   help <command>   Show help for <command>");
        }

        public void ShowUnknownCommand(string unknownCommand)
        {
            WriteLine($"Unknown opto command \"{unknownCommand}\".");
        }

        public void PrintCommandInfo(string commandHelpText)
        {
            throw new NotImplementedException();
        }
    }
}