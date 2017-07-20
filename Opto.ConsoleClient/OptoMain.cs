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
        private Dictionary<string[], Action> _commandMappings;

        public OptoMain(IUsagePrinter usagePrinter)
        {
            _usagePrinter = usagePrinter;
            _commandMappings = new Dictionary<string[], Action>
            {
                {new[] {null, "help", "/?", "-h", "--help"}, _usagePrinter.PrintCommonUsageInfo}
            };
        }

        public void Execute(params string[] args)
        {
            var command = args.FirstOrDefault();
            var action = GetCommandAction(command);
            action();
        }

        private Action GetCommandAction(string command)
        {
            var mapping = _commandMappings.SingleOrDefault(cm => cm.Key.Any(c => c == command));

            void unknownCommandAction()
            {
                _usagePrinter.ShowUnknownCommand(command);
                _usagePrinter.PrintCommonUsageInfo();
            }

            return mapping.Key != null
                ? mapping.Value
                : unknownCommandAction;
        }
    }
}
