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
    internal class QuestionTableType
    {
        public const string TableTypeName = "Questions";

        public int Question_Id { get; set; }

        public static QuestionTableType FromQuestion(Question question) => new QuestionTableType
        {
            Question_Id = question.Id,
        };
    }
    public class SurveysRepositoryDapper : ISurveysRepository
    {
        private readonly IDbConnection _connection;

        public SurveysRepositoryDapper(IDbConnection connection) => _connection = connection;

        public Survey Add(Survey newSurvey) => _connection.Insert(newSurvey);

        public void Delete(Survey entity) => _connection.Execute("DELETE FROM Survey WHERE Id = @Id", entity);

        public Survey Get(int id)
        {
            var survey = _connection.Get<Survey>(id);
            var surveyQuestions = _connection.Query<Question>(
                @"SELECT [Question].* 
FROM [Question_Order] 
JOIN [Question] 
    ON [Question_Order].[Question_Id] = [Question].[Id]
WHERE [Question_Order].[Survey_Id] = @SurveyId
ORDER BY [Question_Order].[Order] ASC", new {
                    SurveyId = survey.Id
                });
            survey.LoadQuestions(surveyQuestions);
            return survey;
        }

        public IEnumerable<Survey> List() => _connection.Query<Survey>("SELECT * FROM Survey");

        public void Update(Survey existingSurvey) => _connection.Execute("Survey_Update", new {
            SurveyId = existingSurvey.Id,
            SurveyName = existingSurvey.Name,
            SurveyDescription = existingSurvey.Description,
            QuestionIds = existingSurvey.Questions.Select(q => new { Question_Id =  q.Id }).ToTableValuedParameter(QuestionTableType.TableTypeName),
        }, commandType: CommandType.StoredProcedure);
    }
}
