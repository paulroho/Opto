using System.Linq;

namespace Opto.ConsoleClient
{
    public class HelpCommand : IOptoCommand
    {
        private readonly IUsagePrinter _usagePrinter;
        private readonly IOptoCommandWithHelp[] _commands;

        public HelpCommand(IUsagePrinter usagePrinter, IOptoCommandWithHelp[] commands)
        {
            _usagePrinter = usagePrinter;
            _commands = commands;
        }

        public void Execute(string[] args)
        {
            var commandKey = args.FirstOrDefault();
            if (commandKey == null)
            {
                _usagePrinter.PrintCommonUsageInfo();
            }
            else
            {
                ShowCommandHelp(commandKey);
            }
        }

        private void ShowCommandHelp(string commandKey)
        {
            var command = _commands.SingleOrDefault(cmd => cmd.Key == commandKey);
            if (command != null)
            {
                _usagePrinter.PrintCommandInfo(command.HelpText);
            }
            else
            {
                _usagePrinter.PrintUnknownCommandHelp(commandKey);
                _usagePrinter.PrintCommonUsageInfo();
            }
        }

        public string Key { get; } = "help";
    }
}