using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTest
    {
        [Test]
        public void Log_WhenCalled_ShouldSetTheLastErrorProperty()
        {
            ErrorLogger logger = new();
            
            logger.Log("a");
            
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            ErrorLogger logger = new();
            
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
        }
    }
}