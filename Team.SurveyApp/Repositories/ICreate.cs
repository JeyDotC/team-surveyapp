using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Repositories
{
    public interface ICreate<TEntity>
    {
        TEntity Add(TEntity entity);
    }
}
