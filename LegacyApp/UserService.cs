using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly ClientRepository _clientRepository;
        private readonly UserCreditService _userCreditService;
        private Client _client;


        
        //This is the constructor only for unit tests
        public UserService(ClientRepository clientRepository, UserCreditService userCreditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
        }
        
        //This is normal constructor
        public UserService()
        {

            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!IsValidUser(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            _client = _clientRepository.GetById(clientId);
            var user = new User(_client, dateOfBirth, email, firstName, lastName);
            
            SetCreditLimit(user);
            
            if (!IsCreditLimitValid(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
        
        private void SetCreditLimit(User user)
        {
            if (_client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else
            {
                user.HasCreditLimit = true;
                user.CreditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                if (_client.Type == "ImportantClient")
                {
                    user.CreditLimit *= 2;
                }
            }
        }

        public bool IsValidUser(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                return false;
            }

            DateTime now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }

            if (age < 21)
            {
                return false;
            }

            return true;
        }

        private bool IsCreditLimitValid(User user)
        {
            return !user.HasCreditLimit || user.CreditLimit >= 500;
        }


    }
}
