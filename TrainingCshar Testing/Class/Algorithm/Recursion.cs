using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CsharLibrary.Algorithms;

namespace TrainingCshar_Testing
{
    [TestClass]
    public class RecursionTest
    {
        Recursion recursion = new Recursion();
        [TestMethod]
        public void NotNullOrZero()
        {
            long result = recursion.Factorial(0);
            Assert.IsNotNull(result);
            Assert.AreNotEqual(result, 0);
        }

        [TestMethod]
        public void MaxLimit()
        {
            int factor = 64;
            long result = recursion.Factorial(factor);
            long limit = long.MaxValue;
            string message = string.Format("la factorizacion es variable al limite" +
                                  "\nfactor: {0}\nlimite: {1}\nresultado: {2}"
                                  , factor, limit, result);
            Assert.AreEqual(result, recursion.Factorial(factor+1));
            if (result > limit)
            {
                throw new AssertFailedException(message.Replace("variable", "mayor"));
            }
                
            if (result < limit)
            {
                System.Console.WriteLine(message.Replace("variable", "menor"));
            }
        }
    }
}