using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using TestingAssignment_1.Controllers;
using TestingAssignment_1.Repository;
using Xunit;

namespace Passenger.Test
{
    public class PassengerTest
    {
        private readonly Mock<IDataRepository> mockRepository = new Mock<IDataRepository>();
        private readonly PassengerController _passengerController;

        public PassengerTest()
        {
            _passengerController = new PassengerController(mockRepository.Object);
        }

        [Fact]
        public void Test_GetUser()
        {
            // Arrange
            var resultObj = mockRepository.Setup(x => x.getPassengersList()).Returns(GetPassengers());

            // Act
            var response = _passengerController.GetList();

            // Assert
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public void Test_DeleteUser()
        {
            var user = new TestingAssignment_1.Models.Passenger();
            user.Id = Guid.NewGuid();
            // Arrange
            var resultObj = mockRepository.Setup(x => x.Delete(user.Id)).Returns(true);

            // Act
            var response = _passengerController.Delete(user.Id);

            //Assert
            Assert.True(response);

        }

        [Fact]
        public void Test_GetUserById()
        {
            // Arrange
            var user = new TestingAssignment_1.Models.Passenger();
            user.Id = Guid.NewGuid();
            user.firstName = "Darshit";
            user.lastName = "Rawal";
            user.phoneNumber = "123321323";

            // Act
            var responseObj = mockRepository.Setup(x => x.GetById(user.Id)).Returns(user);
            var result = _passengerController.Get(user.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<TestingAssignment_1.Models.Passenger>>(result);
            // Assert
            Assert.NotNull(isNull);
        }

        [Fact]
        public void Test_AddUser()
        {
            var newUser = new TestingAssignment_1.Models.Passenger();
            newUser.Id = Guid.NewGuid();
            newUser.firstName = "Darshit_DD";
            newUser.lastName = "Rawal_RR";
            newUser.phoneNumber = "123342343";

            // Act
            var response = mockRepository.Setup(x => x.AddPassenger(newUser)).Returns(AddUser());
            var result = _passengerController.Create(newUser);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_UpdateUser()
        {
            // Arrange
            var model = GetOnlyPassenger();

            // Act
            var resultObj = mockRepository.Setup(x => x.Update(model)).Returns(model);
            var response = _passengerController.Update(model);

            // Assert
            Assert.Equal(model, response);
        }

        private static IList<TestingAssignment_1.Models.Passenger> GetPassengers()
        {
            IList<TestingAssignment_1.Models.Passenger> passengers = new List<TestingAssignment_1.Models.Passenger>()
            {
                new TestingAssignment_1.Models.Passenger() {Id=Guid.NewGuid(), firstName="Darshit", lastName="Rawal", phoneNumber = "1231323434"},
                new TestingAssignment_1.Models.Passenger() {Id=Guid.NewGuid(), firstName="Rawal", lastName="Darshit", phoneNumber = "12313234344"},
                new TestingAssignment_1.Models.Passenger() {Id=Guid.NewGuid(), firstName="Rawal_D", lastName="Darshit_R", phoneNumber = "12313234234"},

            };
            return passengers;
        }

        private static TestingAssignment_1.Models.Passenger AddUser()
        {
            var newUser = new TestingAssignment_1.Models.Passenger();
            newUser.Id = Guid.NewGuid();
            newUser.firstName = "Shankar";
            newUser.lastName = "UserAdmin";
            newUser.phoneNumber = "123134343";
            return newUser;
        }

        private TestingAssignment_1.Models.Passenger GetOnlyPassenger()
        {
            return new TestingAssignment_1.Models.Passenger
            {
                Id = Guid.NewGuid(),
                firstName = "Darshit",
                lastName = "Rawal",
                phoneNumber = "1231321"
            };
        }
    }
}
