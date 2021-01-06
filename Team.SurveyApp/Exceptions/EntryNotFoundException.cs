using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Exceptions
{

    [Serializable]
    public class EntryNotFoundException : InvalidOperationException
    {
        public EntryNotFoundException() { }
        public EntryNotFoundException(string message) : base(message) { }
        public EntryNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected EntryNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
