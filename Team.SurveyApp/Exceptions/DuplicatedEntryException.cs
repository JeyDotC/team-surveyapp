using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Exceptions
{

    [Serializable]
    public class DuplicatedEntryException : InvalidOperationException
    {
        public DuplicatedEntryException() { }
        public DuplicatedEntryException(string message) : base(message) { }
        public DuplicatedEntryException(string message, Exception inner) : base(message, inner) { }
        protected DuplicatedEntryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
