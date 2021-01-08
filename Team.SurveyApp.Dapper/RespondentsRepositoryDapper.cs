using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;
using Team.SurveyApp.Dapper.Extensions;
using Dapper;

namespace Team.SurveyApp.Dapper
{
    public class RespondentsRepositoryDapper : IRespondentsRepository
    {
        private readonly IDbConnection _connection;

        public RespondentsRepositoryDapper(IDbConnection connection) => _connection = connection;

        public Respondent Add(Respondent entity)
        {
            entity.Created = DateTime.Now;

            return _connection.Insert(entity);
        }

        public void Delete(Respondent entity) => _connection.Execute("DELETE FROM Respondent WHERE Id = @Id", entity);

        public Respondent Get(int id) => _connection.Get<Respondent>(id);

        public IEnumerable<Respondent> List() => _connection.Query<Respondent>("SELECT * FROM Respondent");

        public void Update(Respondent entity) => _connection.Update(entity, except: new string[] { nameof(entity.Created) });
    }
}
