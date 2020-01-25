namespace TrainingCshar.Algorithms
{
    public class Recursividad : IRecursividad
    {
        public long Factorial(long numero)
        {
            return numero > 0 ? numero * Factorial(numero - 1) : 1;
        }
    }
}