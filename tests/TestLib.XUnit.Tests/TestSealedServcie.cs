namespace XUnitTest1
{
    public class TestSealedServcie : ITestServcie
    {
        private readonly TestSealed _servcie;

        public TestSealedServcie(TestSealed servcie)
        {
            _servcie = servcie;
        }

        public int Add(CalcRequest request)
        {
            return _servcie.Add(request.X, request.Y);
        }
    }
    
    public sealed class TestSealed
    {
        public int Add(int a, int b)
        {
            return 5;
        }
    }
}