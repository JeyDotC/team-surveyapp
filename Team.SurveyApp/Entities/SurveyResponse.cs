using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Abstractions.Entity;

namespace Team.SurveyApp.Entities
{
    public class SurveyResponse : IHaveId
    {
        public int Id { get; set; }

        public Survey Survey { get; set; }

        public Respondent Respondent { get; set; }

        public IEnumerable<Response> Responses { get; set; }

        public SurveyResponse() { }

        public SurveyResponse(Survey survey, Respondent respondent)
        {
            Survey = survey;
            Respondent = respondent;
        }
    }
}
