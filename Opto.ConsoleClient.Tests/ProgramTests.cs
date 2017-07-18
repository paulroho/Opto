using Moq;
using Xunit;

namespace Opto.ConsoleClient.Tests
{
    public class ProgramTests : CapturingStandardOutTestsBase
    {
        private readonly Mock<IOptoMain> _optoMainMock;

        public ProgramTests()
        {
            _optoMainMock = new Mock<IOptoMain>();
            Program.OptoMain = _optoMainMock.Object;
        }

        public override void Dispose()
        {
            Program.ResetOptoMain();
            base.Dispose();
        }

        [Fact]
        public void ArgumentsFromCommandline_ArePassedToOptoMainExecute()
        {
            var args = new[] {"arg1", "arg2"};

            Program.Main(args);

            _optoMainMock.Verify(om => om.Execute(args), Times.Once);
        }
    }
}