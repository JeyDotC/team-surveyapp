using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team.SurveyApp.Entities;

namespace Team.SurveyApp.Api.Requests
{
    public struct NewSurveyRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Survey ToEntity() => new Survey
        {
            Name = Name,
            Description = Description,
        };
    }
}
