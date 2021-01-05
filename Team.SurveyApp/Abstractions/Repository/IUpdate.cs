using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Abstractions.Repository
{
    public interface IUpdate<TEntity>
    {
        void Update(TEntity entity);
    }
}
