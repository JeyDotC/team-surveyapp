using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Team.SurveyApp.Api.Requests;
using Team.SurveyApp.Api.Requests.Questions;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;

namespace Team.SurveyApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsController(ILogger<QuestionsController> logger, IQuestionsRepository questionsRepository)
        {
            _logger = logger;
            
            _questionsRepository = questionsRepository;
        }

        [HttpGet]
        public IEnumerable<Question> Get() => _questionsRepository.List();

        [HttpPost]
        public Question Post([FromBody]NewQuestionRequest question) => _questionsRepository.Add(question.ToEntity());

        [HttpPut("{id}")]
        public Question Put(int id, [FromBody]UpdateQuestionRequest question)
        {
            var existingQuestion = _questionsRepository.Get(id);
            existingQuestion.Text = question.Text ?? existingQuestion.Text;

            _questionsRepository.Update(existingQuestion);

            return existingQuestion;
        }
    }
}
