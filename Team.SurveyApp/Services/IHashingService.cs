using System;
using System.Collections.Generic;
using System.Text;

namespace Team.SurveyApp.Services
{
    public interface IHashingService
    {
        string HashString(string original);
    }
}
