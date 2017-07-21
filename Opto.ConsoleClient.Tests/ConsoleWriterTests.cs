using System;
using FluentAssertions;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class ConsoleWriterTests : CapturingStandardOutTestsBase
    {
        private readonly ConsoleWriter _writer;

        public ConsoleWriterTests()
        {
            _writer = new ConsoleWriter();
        }

        [Fact]
        public void WriteLine_WithNoParameter_WritesJustANewLine()
        {
            _writer.WriteLine();

            ConsoleOutput.Should().Be("\r\n");
        }

        [Fact]
        public void WriteLine_WritesTheTextToConsoleOutAndStartsANewLine()
        {
            _writer.WriteLine("The message");

            ConsoleOutput.Should().Be($"The message{Environment.NewLine}");
        }
    }
}