using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Team.SurveyApp.Api.Requests.Surveys;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;

namespace Team.SurveyApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveysController : ControllerBase
    {
        private readonly ILogger<SurveysController> _logger;
        private readonly ISurveysRepository _surveysRepository;
        private readonly IQuestionsRepository _questionsRepository;

        public SurveysController(ILogger<SurveysController> logger, ISurveysRepository surveysRepository, IQuestionsRepository questionsRepository)
        {
            _logger = logger;
            
            _surveysRepository = surveysRepository;
            _questionsRepository = questionsRepository;
        }

        [HttpGet("{id}")]
        public Survey Get(int id) => _surveysRepository.Get(id);

        [HttpGet]
        public IEnumerable<Survey> Get() => _surveysRepository.List();

        [HttpPost]
        public Survey Post([FromBody]NewSurveyRequest survey) => _surveysRepository.Add(survey.ToEntity());

        [HttpPut("{id}")]
        public Survey Put(int id, [FromBody]UpdateSurveyRequest survey) 
        {
            var existingSurvey = _surveysRepository.Get(id);
            existingSurvey.Name = survey.Name ?? existingSurvey.Name;
            existingSurvey.Description = survey.Description ?? existingSurvey.Description;

            _surveysRepository.Update(existingSurvey);

            return existingSurvey;
        }

        [HttpPost("{id}/Questions")]
        public Survey PostQuestion(int id, [FromBody]AddQuestionRequest question)
        {
            var existingQuestion = _questionsRepository.Get(question.QuestionId);
            var existingSurvey = _surveysRepository.Get(id);

            existingSurvey.AddQuestion(existingQuestion);

            _surveysRepository.Update(existingSurvey);

            return existingSurvey;
        }

        [HttpDelete("{id}/Questions/{questionId}")]
        public Survey PostQuestion(int id, int questionId)
        {
            var existingSurvey = _surveysRepository.Get(id);

            existingSurvey.RemoveQuestion(questionId);

            _surveysRepository.Update(existingSurvey);

            return existingSurvey;
        }

        [HttpPut("{id}/Questions")]
        public Survey PutQuestion(int id, [FromBody]MoveQuestionRequest question)
        {
            var existingQuestion = _questionsRepository.Get(question.QuestionId);
            var existingSurvey = _surveysRepository.Get(id);

            existingSurvey.MoveQuestion(existingQuestion, question.NewPosition);

            _surveysRepository.Update(existingSurvey);

            return existingSurvey;
        }
    }
}
