namespace XUnitTest1
{
    public interface ITestServcie
    {
        int Add(CalcRequest request);
    }

    public class CalcRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    public class TestServcie : ITestServcie
    {
        private readonly ICalcServcie _servcie;

        public TestServcie(ICalcServcie servcie)
        {
            _servcie = servcie;
        }

        public int Add(CalcRequest request)
        {
            return _servcie.Add(request.X, request.Y);
        }
    }


}