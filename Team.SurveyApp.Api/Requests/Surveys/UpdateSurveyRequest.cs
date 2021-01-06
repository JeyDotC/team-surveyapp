using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team.SurveyApp.Api.Requests.Surveys
{
    public struct UpdateSurveyRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
