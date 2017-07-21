using System;
using System.Collections.Generic;
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
        private readonly Dictionary<string[], Action<string[]>> _commandMappings;

        public OptoMain(IUsagePrinter usagePrinter, IOptoCommand[] commands)
        {
            _usagePrinter = usagePrinter;
            _commands = commands;
            _commandMappings = new Dictionary<string[], Action<string[]>>
            {
                {new[] {null, "help", "/?", "-h", "--help"}, ShowHelp},
            };
            foreach (var command in _commands)
            {
                _commandMappings.Add(new[] {command.Key}, args => command.Execute(args));
            }
        }

        private void ShowHelp(string[] args)
        {
            var commandKey = args.FirstOrDefault();
            if (commandKey != null)
            {
                var command = _commands.SingleOrDefault(cmd => cmd.Key == commandKey);
                if (command != null)
                    _usagePrinter.PrintCommandInfo(command.HelpText);
                else
                {
                    _usagePrinter.PrintUnknownCommandHelp(commandKey);
                    _usagePrinter.PrintCommonUsageInfo();
                }
            }
            else
            {
                _usagePrinter.PrintCommonUsageInfo();
            }
        }

        public void Execute(params string[] args)
        {
            var commandKey = args.FirstOrDefault();
            var action = GetCommandAction(commandKey);
            var commandArgs = args.Skip(1).ToArray();
            action(commandArgs);
        }

        private Action<string[]> GetCommandAction(string command)
        {
            var mapping = _commandMappings.SingleOrDefault(cm => cm.Key.Any(c => c == command));

            return mapping.Key != null
                ? mapping.Value
                : UnknownCommandAction;

            void UnknownCommandAction(string[] args)
            {
                _usagePrinter.PrintUnknownCommandHelp(command);
                _usagePrinter.PrintCommonUsageInfo();
            }
        }
    }
}
