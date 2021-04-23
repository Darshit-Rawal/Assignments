using Assignment_8;
using NUnit.Framework;
using FluentAssertions;
using System.Threading.Tasks;
using FluentAssertions.Extensions;
using System;

namespace UnitTest
{
    public class Tests
    {
        private Service _service;

        [SetUp]
        public void Setup()
        {
            _service = new Service();
        }

        [Test]
        public async Task GetStringArray_Test()
        {
            // Act
            var result = await _service.GetStringArray();

            // Assert
            Assert.That(result, Has.All.With.Length.EqualTo(3).And.All.Contain("a"));
        }

        [Test]
        public async Task GetUsersData_Test()
        {
            // Act
            var result = await _service.GetUserData();

            // Assert
            Assert.That(result, Has
             .Length.EqualTo(3)
             .And.Exactly(1).Property("Id").EqualTo(1)
             .And.Some.Property("Address").Null
             .And.All.Property("Name").Not.Null
             .And.All.Property("Email").Contains('@')
             .And.No.Property("Id").LessThanOrEqualTo(0));
        }


        [Test]
        public void GetTable_Test()
        {
            // Arrange
            int number = 5;

            // Act
            int[] data = _service.GetTable(number);

            // Assert
            data.Should().NotBeEmpty()
           .And.HaveCount(10)
           .And.AllBeOfType(typeof(int))
           .And.StartWith(number * 1)
           .And.EndWith(number * 10);
        }


        [Test]
        public void GetName_Test()
        {
            // Act
            string value = _service.GetString();

            // Assert
            value.Should().NotBeNullOrWhiteSpace()
            .And.Contain("parth")
            .And.Contain("n", Exactly.Thrice())
            .And.Be("parth nonghanvadra")
            .And.NotBe("nonghanvadra parth")
            .And.BeOneOf(
                "Darshit Rawal",
                "Rawal Darshit"
            );
        }

        [Test]
        public void Date_Test()
        {
            // Arrange
            DateTime date1 = new DateTime(2000, 03, 07);

            // Act
            DateTime? date = _service.GetDate();

            // Assert
            date.Should().Be(23.April(2021))
            .And.BeBefore(date1)
            .And.NotBeAfter(date1)
            .And.HaveDay(23)
            .And.HaveMonth(04)
            .And.HaveYear(2021)
            .And.BeMoreThan(0.Days()).Before(date1);
        }
    }
}