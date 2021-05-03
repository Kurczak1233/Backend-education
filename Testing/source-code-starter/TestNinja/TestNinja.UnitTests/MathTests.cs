using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        //SetUp
        //TearDown 
        private Math _math;
        
        [SetUp]
        public void SetUp()
        {
            _math = new();
        }
        
        //In this path we have only one executional paths, so for this reason we have to create only one test.
        [Test]
        public void Add_WhenCalled_ReturnGreaterValue()
        {
            //Act
            var result = _math.Add(1, 2);
            //Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2,1,2)]
        [TestCase(1,2,2)]
        [TestCase(1,1,1)]
        public void Max_WhenCalled_ReturnFirstArgument(int a, int b, int expectedValue)
        {
            var result = _math.Max(a, b);
            
            Assert.That(result, Is.EqualTo(expectedValue));
        }
    }
}