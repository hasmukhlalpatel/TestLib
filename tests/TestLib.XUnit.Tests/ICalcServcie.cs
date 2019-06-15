namespace XUnitTest1
{
    public interface ICalcServcie
    {
        int Add(int a, int b);
    }

    public class CalcServcie : ICalcServcie
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}