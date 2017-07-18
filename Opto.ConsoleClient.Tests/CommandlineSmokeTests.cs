using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class CommandlineSmokeTests : IDisposable
    {
        private readonly TextWriter _originalOutStream;
        private readonly StringWriter _consoleOutStream;

        public CommandlineSmokeTests()
        {
            _originalOutStream = Console.Out;
            _consoleOutStream = new StringWriter();
            Console.SetOut(_consoleOutStream);
        }

        private String ConsoleOutput => _consoleOutStream.ToString();

        public void Dispose()
        {
            Console.SetOut(_originalOutStream);
        }

        [Fact]
        public void CallingWithNoArguments_ShowsUsageInfo()
        {
            var noArguments = new string[]{};

            // Act
            Program.Main(noArguments);

            ConsoleOutput.Should().Contain("usage");
        }
    }
}