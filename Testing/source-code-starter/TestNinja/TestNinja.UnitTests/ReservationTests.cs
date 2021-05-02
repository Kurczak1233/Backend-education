using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_UserAdmin_ReturnsTrue()
        {
            //Arrange
            Reservation reservation = new();
            //Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });
            //Assert 
            Assert.IsTrue(result);
        }
        [TestMethod]

        public void CanBeCancelledBy_Creator_ReturnsTrue()
        {
            //Arrange
            User user = new();
            Reservation reservation = new()
            {
                MadeBy = user
            };
            //Act
            var result = reservation.CanBeCancelledBy(user);
            //Assert 
            Assert.IsTrue(result);
        }
        [TestMethod]

        public void CanBeCancelledBy_OrdinaryUser_ReturnsFalse()
        {
            //Arrange
            Reservation reservation = new();
            //Act
            var result = reservation.CanBeCancelledBy(new User { });
            //Assert 
            Assert.IsFalse(result);
        }
    }
}
