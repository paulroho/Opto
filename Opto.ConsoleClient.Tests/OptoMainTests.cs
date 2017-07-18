using Moq;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class OptoMainTests
    {
        [Fact]
        public void CallingWithNoArguments_PrintsCommonUsageInfo()
        {
            var usagePrinterMock = new Mock<IUsagePrinter>();
            var main = new OptoMain(usagePrinterMock.Object);

            main.Execute();

            usagePrinterMock.Verify(up => up.PrintCommonUsageInfo(), Times.Once);
        }
    }
}