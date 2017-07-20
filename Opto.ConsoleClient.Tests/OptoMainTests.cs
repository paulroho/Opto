using System;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class OptoMainTests
    {
        private readonly Mock<IUsagePrinter> _usagePrinterMock;
        private readonly OptoMain _main;

        public OptoMainTests()
        {
            _usagePrinterMock = new Mock<IUsagePrinter>();
            _main = new OptoMain(_usagePrinterMock.Object);
        }

        // ReSharper disable once MemberCanBePrivate.Global
        public static IEnumerable<string[]> CommandlineArgsForCommonHelp = new[]
        {
            new string[] { },
            new[] {"help"},
            new[] {"/?"},
            new[] {"-h"},
            new[] {"--help"},
        };

        [Theory]
        [MemberData(nameof(CommandlineArgsForCommonHelp))]
        public void CallingWithNoArgumentsOrHelpArguments_PrintsCommonUsageInfo(params string[] arguments)
        {
            _main.Execute(arguments);

            _usagePrinterMock.Verify(up => up.PrintCommonUsageInfo(), Times.Once);
        }

        [Fact]
        public void CallingWithUnknownArgument_PrintsErrorMessageAndHelp()
        {
            _main.Execute("ThisIsUnknown");

            _usagePrinterMock.Verify(up => up.ShowUnknownCommand("ThisIsUnknown"), Times.Once);
            _usagePrinterMock.Verify(up => up.PrintCommonUsageInfo(), Times.Once);
        }
    }
}