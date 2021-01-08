using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Services;

namespace Team.SurveyApp.Tests.Services
{
    [TestFixture]
    public class DefaultHashingServiceTest
    {
        [Test]
        public void HashString_ShouldReturnHashedString()
        {
            // Arrange
            var nonHashedString = "MyP@ssw0rd";
            var service = new DefaultHashingService();

            // Act
            var hashedString = service.HashString(nonHashedString);

            // Assert
            Assert.AreEqual("b676993c5c591ce1f67b0f0efc4912a8a04782b1283254824c7fb9afc3d7dd3f", hashedString);
        }
    }
}
