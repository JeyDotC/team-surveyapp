using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Entities
{
    public class Response
    {
        public Question Question { get; set; }

        public Respondent Respondent { get; set; }

        public string Answer { get; set; }
    }
}
