using System.Collections.Generic;
using Moq;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class OptoMainTests
    {
        private readonly OptoMain _main;
        private readonly Mock<IUsagePrinter> _usagePrinterMock;
        private readonly Mock<IOptoCommand> _dumpCommandMock;

        public OptoMainTests()
        {
            _usagePrinterMock = new Mock<IUsagePrinter>();
            _dumpCommandMock = new Mock<IOptoCommand>();
            _dumpCommandMock.Setup(cmd => cmd.Key).Returns("dump");
            _main = new OptoMain(_usagePrinterMock.Object, new []{_dumpCommandMock.Object});
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
        public void CallingHelpForAnUnknownCommand_PrintsErrorMessageAndCommonHelp()
        {
            _main.Execute("help", "ThisIsUnknown");

            _usagePrinterMock.Verify(up => up.PrintUnknownCommandHelp("ThisIsUnknown"), Times.Once);
            _usagePrinterMock.Verify(up => up.PrintCommonUsageInfo(), Times.Once);
        }

        [Fact]
        public void CallingHelpForDump_ShowsJustTheHelptextFromTheDumpCommand()
        {
            _dumpCommandMock.SetupGet(dc => dc.HelpText).Returns(() => "The dump help");
            _main.Execute("help", "dump");

            _usagePrinterMock.Verify(up => up.PrintCommandInfo("The dump help"), Times.Once);
            _usagePrinterMock.Verify(up => up.PrintCommonUsageInfo(), Times.Never);
        }

        [Fact]
        public void CallingWithUnknownArgument_PrintsErrorMessageAndHelp()
        {
            _main.Execute("ThisIsUnknown");

            _usagePrinterMock.Verify(up => up.PrintUnknownCommandHelp("ThisIsUnknown"), Times.Once);
            _usagePrinterMock.Verify(up => up.PrintCommonUsageInfo(), Times.Once);
        }

        [Fact]
        public void CallingCommandDumpWithAnArgument_InvokesTheDumpCommandWithThatArgument()
        {
            _main.Execute("dump", "MyFile.ext");

            _dumpCommandMock.Verify(d => d.Execute(new []{"MyFile.ext"}), Times.Once());
        }
    }
}