using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Abstractions.Repository;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Repositories
{
    public interface IRespondentsRepository : 
        ICreate<Respondent>,
        IRead<Respondent>,
        IUpdate<Respondent>,
        IDelete<Respondent>,
        IGet<Respondent>
    {
    }
}
