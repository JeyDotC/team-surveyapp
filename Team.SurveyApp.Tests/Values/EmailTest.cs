using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Values;

namespace Team.SurveyApp.Tests.Values
{
    [TestFixture]
    public class EmailTest
    {
        [Test]
        [TestCase("someone@email.com", "someone", "email.com")]
        [TestCase("someone@email.com.co", "someone", "email.com.co")]
        [TestCase("some-one@email.com.co", "some-one", "email.com.co")]
        public void ImplicitAssignmentOperator_ShouldCreateInstanceWithCorrectValues(string email, string expectedUser, string expectedDomain)
        {
            // Arrange
            Email emailValue;

            // Act
            emailValue = email;

            // Assert
            Assert.AreEqual(expectedUser, emailValue.User);
            Assert.AreEqual(expectedDomain, emailValue.Domain);
        }

        [Test]
        [TestCase("nameonly", Description = "Name Only")]
        [TestCase("@domainonly.com", Description = "Domain Only")]
        [TestCase("", Description = "Empty String")]
        public void ImplicitAssignmentOperator_ShouldFailOnInvalidValues(string invalidEmail)
        {
            // Arrange
            Email emailValue;

            // Act -> Assert
            Assert.Throws<InvalidOperationException>(() => emailValue = invalidEmail);

        }
    }
}
