using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Abstractions.Entity
{
    public interface IHaveUpdatedTimeStamp
    {
        public DateTime Updated { get; set; }
    }
}
