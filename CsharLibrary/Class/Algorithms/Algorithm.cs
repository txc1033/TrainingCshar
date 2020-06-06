namespace CsharLibrary.Algorithms
{
    public class Recursion : IRecursion
    {
        public long Factorial(long number)
        {
            return number > 0 ? number * Factorial(number - 1) : 1;
        }
    }
}