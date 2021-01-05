using System;
using System.Collections.Generic;
using System.Text;
using Team.SurveyApp.Abstractions.Entity;

namespace Team.SurveyApp.Entities
{
    public class Question : IHaveId
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Updated { get; set; } = DateTime.Now;

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return (obj as Question).Id == Id;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
