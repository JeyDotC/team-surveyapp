using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Team.SurveyApp.Api.Requests
{
    public struct MoveQuestionRequest
    {
        public int QuestionId { get; set; }

        public int NewPosition { get; set; }
    }
}
