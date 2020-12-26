using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Repositories
{
    public interface IQuestionsRepository : 
        ICreate<Question>,
        IRead<Question>,
        IUpdate<Question>
    {
    }
}
