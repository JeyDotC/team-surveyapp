using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Repositories
{
    public interface IUpdate<TEntity>
    {
        void Update(TEntity entity);
    }
}
