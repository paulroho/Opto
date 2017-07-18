using FluentAssertions;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class CommandlineSmokeTests : CapturingStandardOutTestsBase
    {
        [Fact]
        public void CallingWithNoArguments_ShowsUsageInfo()
        {
            var noArguments = new string[]{};

            Program.Main(noArguments);

            ConsoleOutput.Should().Contain("Usage");
        }
    }
}