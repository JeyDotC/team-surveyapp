using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Abstractions.Repository
{
    public interface IRead<TEntity>
    {
        IEnumerable<TEntity> List();
    }
}
