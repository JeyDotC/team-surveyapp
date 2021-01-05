using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team.SurveyApp.Abstractions.Entity;
using Team.SurveyApp.Exceptions;

namespace Team.SurveyApp.Entities
{
    public class Survey : IHaveId
    {
        private readonly List<Question> _questions = new List<Question>();

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;

        public IEnumerable<Question> Questions => _questions;

        public void LoadQuestions(IEnumerable<Question> questions)
        {
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public void AddQuestion(Question question)
        {
            if (_questions.Any(q => q.Id == question.Id))
            {
                throw new DuplicatedEntryException("A question can be added only once per Survey.");
            }

            _questions.Add(question);
        }

        public void MoveQuestion(Question question, int to)
        {
            var from = _questions.IndexOf(question);

            if (from < 0)
            {
                throw new InvalidOperationException($"Question with Id {question.Id} has not been added to this survey.");
            }

            if (to < 0 || _questions.Count <= to)
            {
                throw new IndexOutOfRangeException($"Destination location {to} is out of bounds [0 - {_questions.Count}].");
            }

            _questions.Remove(question);
            _questions.Insert(to, question);
        }
    }
}
