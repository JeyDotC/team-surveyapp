using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Api.Requests.Questions
{
    public struct NewQuestionRequest
    {
        public string Text { get; set; }

        public Question ToEntity() => new Question
        {
            Text = Text
        };
    }
}
