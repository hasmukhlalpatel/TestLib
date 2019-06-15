using Xunit;
using Moq;
using AutoFixture;
using FluentAssertions;
using TestLib;
using System;

namespace XUnitTest1
{

    public class SealedServiceTest : TestBase<TestSealedServcie>
    {
        [Fact]
        public void MockServiceTest()
        {

            var request = Fixture.Create<CalcRequest>();

            Action action = () => { var result = Sut.Add(request); };

            action.Should().Throw<System.Reflection.TargetInvocationException>();

        }
    }


}
