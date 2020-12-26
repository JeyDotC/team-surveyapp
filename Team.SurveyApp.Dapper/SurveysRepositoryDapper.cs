using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;

namespace Team.SurveyApp.Dapper
{
    public class SurveysRepositoryDapper : ISurveysRepository
    {
        private readonly IDbConnection _connection;

        public SurveysRepositoryDapper(IDbConnection connection) => _connection = connection;

        public Survey Add(Survey newSurvey)
        {
            var persistedSurvey = new Survey
            {
                Name = newSurvey.Name,
                Description = newSurvey.Description,
                Updated = DateTime.Now,
            };

            persistedSurvey.Id = _connection.QuerySingle<int>(
@"INSERT INTO Survey (Name, Description, Updated)
OUTPUT INSERTED.Id
VALUES (@Name, @Description, @Updated)", persistedSurvey);

            return persistedSurvey;
        }

        public IEnumerable<Survey> List() => _connection.Query<Survey>("SELECT * FROM Survey");

        public void Update(Survey existingSurvey)
        {
            throw new NotImplementedException();
        }
    }
}
