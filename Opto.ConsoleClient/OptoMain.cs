using System;
using System.Linq;

namespace Opto.ConsoleClient
{
    public interface IOptoMain
    {
        void Execute(params string[] args);
    }

    public class OptoMain : IOptoMain
    {
        private readonly IUsagePrinter _usagePrinter;
        private readonly IOptoCommand[] _commands;

        public OptoMain(IUsagePrinter usagePrinter, IOptoCommand[] commands)
        {
            _usagePrinter = usagePrinter;
            _commands = commands;
        }

        public void Execute(params string[] args)
        {
            var commandKey = args.FirstOrDefault();
            var action = GetCommandAction(commandKey);
            var commandArgs = args.Skip(1).ToArray();
            action(commandArgs);
        }

        private Action<string[]> GetCommandAction(string commandKey)
        {
            if (commandKey == null)
                return args => _commands.Single(cmd => cmd.Key == "help").Execute(args);

            var command = _commands.SingleOrDefault(cmd => cmd.Key == commandKey);
            if (command != null)
                return args => command.Execute(args);

            return UnknownCommandAction;

            void UnknownCommandAction(string[] args)
            {
                _usagePrinter.PrintUnknownCommandHelp(commandKey);
                _usagePrinter.PrintCommonUsageInfo();
            }
        }
    }
}
