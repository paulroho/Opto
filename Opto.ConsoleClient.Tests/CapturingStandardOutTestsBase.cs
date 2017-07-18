using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    [Collection("Tests redirecting Standard.Out")]  // Prevent tests derived from that class to execute in parallel
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

        public virtual void Dispose()
        {
            Debug.WriteLine("Disposing");
            Console.SetOut(_originalOutStream);
        }
    }
}