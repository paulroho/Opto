using System;
using System.IO;

namespace Opto.ConsoleClient.Tests
{
    public class CapturingStandardOutTestsBase : IDisposable
    {
        private readonly TextWriter _originalOutStream;
        private readonly StringWriter _consoleOutStream;

        protected CapturingStandardOutTestsBase()
        {
            _originalOutStream = Console.Out;
            _consoleOutStream = new StringWriter();
            Console.SetOut(_consoleOutStream);
        }

        protected String ConsoleOutput => _consoleOutStream.ToString();

        public void Dispose()
        {
            Console.SetOut(_originalOutStream);
        }
    }
}