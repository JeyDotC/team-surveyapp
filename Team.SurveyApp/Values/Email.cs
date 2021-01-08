using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Team.SurveyApp.Values
{
    public struct Email
    {
        public string User { get; }

        public string Domain { get; }

        public Email(string user, string domain): this()
        {
            User = user;
            Domain = domain;
        }

        public static implicit operator Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidOperationException("Email string cannot be null or empty.");
            }

           if(!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new InvalidOperationException("Incorrect email format.");
            }

            var parts = email.Split('@');

            return new Email(parts[0], parts[1]);
        }

        public override string ToString() => $"{User}@{Domain}";

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Email)obj;

            return User == other.User && Domain == other.Domain;
        }

        // override object.GetHashCode
        public override int GetHashCode() => User.GetHashCode() + Domain.GetHashCode();
    }
}
