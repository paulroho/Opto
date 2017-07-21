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
        private readonly Dictionary<string[], Action<string[]>> _commandMappings;

        public OptoMain(IUsagePrinter usagePrinter)
        {
            _usagePrinter = usagePrinter;
            _commandMappings = new Dictionary<string[], Action<string[]>>
            {
                {new[] {null, "help", "/?", "-h", "--help"}, args => _usagePrinter.PrintCommonUsageInfo()}
            };
        }

        public void Execute(params string[] args)
        {
            var command = args.FirstOrDefault();
            var action = GetCommandAction(command);
            action(args);
        }

        private Action<string[]> GetCommandAction(string command)
        {
            var mapping = _commandMappings.SingleOrDefault(cm => cm.Key.Any(c => c == command));

            void UnknownCommandAction(string[] args)
            {
                _usagePrinter.ShowUnknownCommand(command);
                _usagePrinter.PrintCommonUsageInfo();
            }

            return mapping.Key != null
                ? mapping.Value
                : UnknownCommandAction;
        }
    }
}
