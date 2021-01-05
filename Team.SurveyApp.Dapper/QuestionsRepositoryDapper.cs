using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Team.SurveyApp.Dapper.Extensions;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;

namespace Team.SurveyApp.Dapper
{
    public class QuestionsRepositoryDapper : IQuestionsRepository
    {
        private readonly IDbConnection _connection;

        public QuestionsRepositoryDapper(IDbConnection connection) => _connection = connection;

        public Question Add(Question entity) => _connection.Insert(entity);

        public Question Get(int id) => _connection.Get<Question>(id);

        public IEnumerable<Question> List() => _connection.Query<Question>("SELECT * FROM Question");

        public void Update(Question entity)
        {
            throw new NotImplementedException();
        }
    }
}
