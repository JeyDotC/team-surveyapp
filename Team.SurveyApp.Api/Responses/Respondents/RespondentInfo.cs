using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Api.Responses.Respondents
{
    public struct RespondentInfo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime Created { get; set; }

        internal static RespondentInfo FromEntity(Respondent entity) => new RespondentInfo
        {
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email.ToString(),
            Created = entity.Created
        };
    }
}
