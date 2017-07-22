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
        private readonly Dictionary<string, Action<string[]>> _commandMappings;

        public OptoMain(IUsagePrinter usagePrinter, IOptoCommand[] commands)
        {
            _usagePrinter = usagePrinter;
            _commands = commands;
            _commandMappings = new Dictionary<string, Action<string[]>>();
            foreach (var command in _commands)
            {
                _commandMappings.Add(command.Key, args => command.Execute(args));
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
            if (command == null)
            {
                var helpCommand = _commands.Single(cmd => cmd.Key == "help");
                return args => helpCommand.Execute(args);
            }

            var mapping = _commandMappings.SingleOrDefault(cm => cm.Key == command);

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
