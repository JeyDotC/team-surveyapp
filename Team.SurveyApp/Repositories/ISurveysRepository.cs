using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Repositories
{
    public interface ISurveysRepository : 
        ICreate<Survey>,
        IRead<Survey>,
        IUpdate<Survey>
    {
    }
}
