using System.Linq;
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

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);
            
            //General
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(3));
            //Balanced
            Assert.That(result, Does.Contain(1));
            Assert.That(result, Does.Contain(3));
            Assert.That(result, Does.Contain(5));
            //Specific
            Assert.That(result, Is.EquivalentTo(new [] {1,3,5}));
            //General
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.Unique);
        }
    }
}