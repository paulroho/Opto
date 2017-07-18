using System;
using FluentAssertions;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class ConsoleWriterTests : CapturingStandardOutTestsBase
    {
        [Fact]
        public void WriteLine_WritesTheTextToConsoleOutAndStartsANewLine()
        {
            var writer = new ConsoleWriter();

            writer.WriteLine("The message");

            ConsoleOutput.Should().Be($"The message{Environment.NewLine}");
        }
    }
}