using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Abstractions.Repository;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Repositories
{
    public interface ISurveyResponsesRepository : 
        ICreate<SurveyResponse>
    {
    }
}
