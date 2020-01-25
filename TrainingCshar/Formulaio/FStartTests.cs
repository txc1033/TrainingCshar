using AutoMoq;
using Moq;
using NUnit.Framework;
using TrainingCshar.Formulaio;

namespace TrainingCshar.Formulaio
{
    [TestFixture]
    public class FStartTests
    {
        [Test]
        public void TestMethod1()
        {
            // Arrange
            var mocker = new AutoMoqer();
            var fStart = mocker.Create<FStart>();

            // Act


            // Assert
            Assert.Fail();
        }
    }
}
