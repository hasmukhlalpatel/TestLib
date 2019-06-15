using Xunit;
using Moq;
using AutoFixture;
using FluentAssertions;
using TestLib;

namespace XUnitTest1
{
    public class ServiceTest : TestBase<TestServcie>
    {
        [Fact]
        public void MockServiceTest()
        {
            var mokedServcie =  GetMock<ICalcServcie>();

            mokedServcie
                .Setup(x => x.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(3);

            var request  = Fixture.Create<CalcRequest>();

            var result = Sut.Add(request);

            result.Should().Be(3);

            mokedServcie
                .Verify(x => x.Add(It.IsAny<int>(), It.IsAny<int>()));
        }
    }


}
