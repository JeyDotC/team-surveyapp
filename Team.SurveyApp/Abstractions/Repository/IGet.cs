using Team.SurveyApp.Abstractions.Entity;

namespace Team.SurveyApp.Abstractions.Repository
{
    public interface IGet<TEntity>
        where TEntity : IHaveId
    {
        TEntity Get(int id);
    }
}
