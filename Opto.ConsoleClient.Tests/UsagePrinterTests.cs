using System;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class UsagePrinterTests
    {
        private readonly MockConsoleWriter _mockConsoleWriter;
        private readonly UsagePrinter _usagePrinter;

        public UsagePrinterTests()
        {
            _mockConsoleWriter = new MockConsoleWriter();
            _usagePrinter = new UsagePrinter(_mockConsoleWriter);
        }

        [Fact]
        public void PassingNullConsoleWriter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new UsagePrinter(null));
        }

        [Fact]
        public void PrintCommonUsageInfo_ShowsHowToGetHelp()
        {
            _usagePrinter.PrintCommonUsageInfo();

            _mockConsoleWriter.Output.Should().Contain("opto help");
        }

        [Fact]
        public void ShowUnknownCommandInfo_ShowsTheUnknownCommand()
        {
            _usagePrinter.ShowUnknownCommand("ThisIsUnknown");

            _mockConsoleWriter.Output.Should().Be("Unknown opto command \"ThisIsUnknown\".\r\n");
        }
    }

    public class MockConsoleWriter : IConsoleWriter
    {
        private readonly StringBuilder _buffer = new StringBuilder();

        public string Output => _buffer.ToString();

        public void WriteLine(string line)
        {
            _buffer.AppendLine(line);
        }
    }
}