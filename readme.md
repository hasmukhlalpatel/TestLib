# Test library for .net 
##Simple service test
```csharp
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
````