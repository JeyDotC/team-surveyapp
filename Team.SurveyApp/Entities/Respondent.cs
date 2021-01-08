using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Abstractions.Entity;
using Team.SurveyApp.Values;

namespace Team.SurveyApp.Entities
{
    public class Respondent : IHaveId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string HashedPassword { get; set; }

        public Email Email { get; set; }

        public DateTime Created { get; set; }
    }
}
