using System;
using System.Text;
using FluentAssertions;
using Moq;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class UsagePrinterTests
    {
        [Fact]
        public void PassingNullConsoleWriter_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new UsagePrinter(null));
        }

        [Fact]
        public void PrintCommonUsageInfo_ShowsHowToGetHelp()
        {
            var mockConsoleWriter = new MockConsoleWriter();
            var printer = new UsagePrinter(mockConsoleWriter);

            printer.PrintCommonUsageInfo();

            mockConsoleWriter.Output.Should().Contain("opto help");
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