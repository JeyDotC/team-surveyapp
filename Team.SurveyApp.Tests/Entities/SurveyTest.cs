using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Tests.Entities
{
    [TestFixture]
    public class SurveyTest
    {
        private static Survey CreateDefaultSurvey()
        {
            var survey = new Survey { Id = 1 };
            survey.LoadQuestions(new Question[] {
                new Question { Id = 1 },
                new Question { Id = 2 },
                new Question { Id = 3 },
                new Question { Id = 4 },
                new Question { Id = 5 },
            });

            return survey;
        }

        [Test]
        public void MoveQuestion_ShouldMoveQuestion()
        {
            // Arrange
            var survey = CreateDefaultSurvey();

            // Act
            survey.MoveQuestion(new Question { Id = 3 }, 0);

            // Assert
            Assert.AreEqual(new int[] { 3, 1, 2, 4, 5 }, survey.Questions.Select(q => q.Id).ToArray());
        }

        [Test]
        [TestCase(12, 0, typeof(InvalidOperationException), Description = "Non-Added Id")]
        [TestCase(1, 15, typeof(IndexOutOfRangeException), Description = "Invalid upped bound index")]
        [TestCase(1, -2, typeof(IndexOutOfRangeException), Description = "Invalid lower bound index")]
        public void MoveQuestion_ShouldThrowIndexOutOfRangeException(int questionId, int destinationIndex, Type expectedException)
        {
            // Arrange
            var question = new Question { Id = questionId };

            var survey = CreateDefaultSurvey();

            // Act -> Assert
            Assert.Throws(expectedException, () => survey.MoveQuestion(question, destinationIndex));
        }
    }
}
