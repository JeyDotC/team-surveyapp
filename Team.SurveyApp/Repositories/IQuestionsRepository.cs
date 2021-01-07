using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Abstractions.Repository;

namespace Team.SurveyApp.Repositories
{
    public interface IQuestionsRepository : 
        ICreate<Question>,
        IRead<Question>,
        IUpdate<Question>,
        IGet<Question>,
        IDelete<Question>
    {
    }
}
