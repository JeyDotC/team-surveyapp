using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Team.SurveyApp.Services
{
    public class DefaultHashingService : IHashingService
    {
        public string HashString(string original)
        {
            using(var hashingAlgorithm = SHA256.Create())
            {
                var originalBytes = Encoding.UTF8.GetBytes(original);
                var hashedBytes = hashingAlgorithm.ComputeHash(originalBytes);
                var hashedChars = hashedBytes.Select(b => b.ToString("x2"));
                var hashedString = string.Join(string.Empty, hashedChars);

                return hashedString;
            }
        }
    }
}
