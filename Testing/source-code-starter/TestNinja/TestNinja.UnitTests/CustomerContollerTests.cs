using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerContollerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();

           var result = controller.GetCustomer(0);
            //Not Found
            Assert.That(result, Is.TypeOf<NotFound>());
            
            //NotFound or one of its derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustoer_IdIsNotZer_ReturnOk()
        {
            
        }
    }
}