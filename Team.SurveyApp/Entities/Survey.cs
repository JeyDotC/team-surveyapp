using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        
        public string  Name { get; set; }

        public string Description { get; set; }

        public DateTime Updated { get; set; }
    }
}
