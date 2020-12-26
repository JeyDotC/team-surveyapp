using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Entities
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;
    }
}
