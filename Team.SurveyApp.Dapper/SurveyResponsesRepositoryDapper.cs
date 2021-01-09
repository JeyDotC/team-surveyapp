using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Team.SurveyApp.Dapper.Extensions;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;

namespace Team.SurveyApp.Dapper
{

    public class SurveyResponsesRepositoryDapper : ISurveyResponsesRepository
    {
        private readonly IDbConnection _connection;

        public SurveyResponsesRepositoryDapper(IDbConnection connection) => _connection = connection;

        public SurveyResponse Add(SurveyResponse entity)
        {
            throw new NotImplementedException();
        }
    }
}
