using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Abstractions.Repository;

namespace Team.SurveyApp.Repositories
{
    public interface ISurveysRepository : 
        ICreate<Survey>,
        IRead<Survey>,
        IUpdate<Survey>,
        IGet<Survey>,
        IDelete<Survey>
    {
    }
}
