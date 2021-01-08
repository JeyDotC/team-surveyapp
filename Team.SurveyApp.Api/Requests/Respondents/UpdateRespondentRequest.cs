using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Services;

namespace Team.SurveyApp.Api.Requests.Respondents
{
    public struct UpdateRespondentRequest
    {
        public string Name { get; set; }

        public string NewPassword { get; set; }

        public string Email { get; set; }
    }
}
