namespace XUnitTest1
{
    public class TestAbstractServcie : ITestServcie
    {
        private readonly TestAbstract _servcie;

        public TestAbstractServcie(TestAbstract servcie)
        {
            _servcie = servcie;
        }

        public int Add(CalcRequest request)
        {
            return _servcie.Add(request.X, request.Y);
        }
    }

    public abstract class TestAbstract
    {
        public abstract int Add(int a, int b);
    }
}