using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Repositories
{
    public interface IRead<TEntity>
    {
        IEnumerable<TEntity> List();
    }
}
