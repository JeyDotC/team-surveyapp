using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Team.SurveyApp.Api.Requests;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;

namespace Team.SurveyApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Surveys : ControllerBase
    {
        private readonly ILogger<Surveys> _logger;
        private readonly ISurveysRepository _surveysRepository;

        public Surveys(ILogger<Surveys> logger, ISurveysRepository surveysRepository)
        {
            _logger = logger;
            
            _surveysRepository = surveysRepository;
        }

        [HttpGet]
        public IEnumerable<Survey> Get() => _surveysRepository.List();

        [HttpPost]
        public Survey Post([FromBody]NewSurveyRequest survey) => _surveysRepository.Add(survey.ToEntity());
    }
}
