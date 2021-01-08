using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Services;

namespace Team.SurveyApp.Api.Requests.Respondents
{
    public struct NewRespondentRequest
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        internal Respondent ToEntity(IHashingService hasher) => new Respondent
        {
            Name = Name,
            Email = Email,
            HashedPassword = hasher.HashString(Password)
        };
    }
}
