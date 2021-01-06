using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Abstractions.Entity;

namespace Team.SurveyApp.Abstractions.Repository
{
    public interface IDelete<TEntity>
        where TEntity : IHaveId
    {
        void Delete(TEntity entity);
    }
}
