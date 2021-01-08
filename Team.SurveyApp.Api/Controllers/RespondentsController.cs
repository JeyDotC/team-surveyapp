using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Team.SurveyApp.Api.Filters;
using Team.SurveyApp.Api.Requests.Respondents;
using Team.SurveyApp.Api.Responses.Respondents;
using Team.SurveyApp.Entities;
using Team.SurveyApp.Repositories;
using Team.SurveyApp.Services;

namespace Team.SurveyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionSerializationFilter]
    public class RespondentsController : ControllerBase
    {
        private readonly IRespondentsRepository _respondentsRepository;
        private readonly IHashingService _hashingService;

        public RespondentsController(IRespondentsRepository respondentsRepository, IHashingService hashingService)
        {
            _respondentsRepository = respondentsRepository;
            _hashingService = hashingService;
        }

        // GET: api/Responders
        [HttpGet]
        public IEnumerable<RespondentInfo> Get() => _respondentsRepository.List().Select(RespondentInfo.FromEntity);

        // GET: api/Responders/5
        [HttpGet("{id}", Name = "Get")]
        public RespondentInfo Get(int id) => RespondentInfo.FromEntity(_respondentsRepository.Get(id));

        // POST: api/Responders
        [HttpPost]
        public RespondentInfo Post([FromBody] NewRespondentRequest value)
            => RespondentInfo.FromEntity(_respondentsRepository.Add(value.ToEntity(_hashingService)));

        // PUT: api/Responders/5
        [HttpPut("{id}")]
        public RespondentInfo Put(int id, [FromBody] UpdateRespondentRequest value)
        {
            var existingRespondent = _respondentsRepository.Get(id);

            existingRespondent.Name = value.Name ?? existingRespondent.Name;
            existingRespondent.Email = value.Email ?? existingRespondent.Email;
            existingRespondent.HashedPassword = _hashingService.HashString(value.NewPassword) ?? existingRespondent.HashedPassword;

            _respondentsRepository.Update(existingRespondent);

            return RespondentInfo.FromEntity(existingRespondent);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var existingRespondent = _respondentsRepository.Get(id);

            _respondentsRepository.Delete(existingRespondent);
        }
    }
}
