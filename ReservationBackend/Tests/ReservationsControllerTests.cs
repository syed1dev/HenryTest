using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReservationBackend.Controllers;
using ReservationBackend.DBContext;
using ReservationBackend.Models;

namespace ReservationBackenUnitTest
{
	public class ReservationsControllerTests
	{
        private ReservationsController _controller;
        private Mock<ReservationDBContext> _mockContext;
        [SetUp]
        public void Setup()
        {
            // Create a mock instance of BookingSystemDbContext
            _mockContext = new Mock<ReservationDBContext>();

            // Initialize the controller with the mock context
            _controller = new ReservationsController(_mockContext.Object);
        }

        [Test]
        public async Task CreateReservation_ValidInput_ShouldReturnOkResult()
        {
            // Arrange
            var reservation = new Reservation
            {
                ProviderId = 1,
                ClientId = 1,
                StartTime = DateTime.Now.AddHours(25),
                EndTime = DateTime.Now.AddHours(26),
                ReservationTime = DateTime.Now
            };

            // Mock the DbSet and other dependencies as needed

            // Act
            var result = await _controller.CreateReservation(reservation);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            // Add more assertions as needed
        }
    }

}

