﻿using System;

namespace Opto.ConsoleClient
{
    public interface IUsagePrinter
    {
        void PrintCommonUsageInfo();
        void ShowUnknownCommand(string unknownCommand);
    }

    public class UsagePrinter : IUsagePrinter
    {
        private readonly IConsoleWriter _consoleWriter;

        public UsagePrinter(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter ?? throw new ArgumentNullException(nameof(consoleWriter));
        }

        public void PrintCommonUsageInfo()
        {
            _consoleWriter.WriteLine("Usage: opto [-h | --help | /?]");
            _consoleWriter.WriteLine("       <command> [<args>]");
            _consoleWriter.WriteLine("These commands are available");
            _consoleWriter.WriteLine("   help  Show this help screen");
        }

        public void ShowUnknownCommand(string unknownCommand)
        {
            _consoleWriter.WriteLine($"Unknown opto command \"{unknownCommand}\".");
        }
    }
}