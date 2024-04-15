using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
        
        public User(Client client, DateTime dateOfBirth, string email, string firstName, string lastName)
        {
            if (!IsValidUser(firstName, lastName, email, dateOfBirth))
            {
                throw new ArgumentException("Invalid user data.");
            }
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = email;
            FirstName = firstName;
            LastName = lastName;
        }


        private bool IsValidUser(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            DateTime now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }

            return true;

        }
        
        
        
        
    }
}