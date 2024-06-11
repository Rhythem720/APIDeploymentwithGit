using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;
using TurfBooking.Domain.IRepositories;

namespace TurfBooking.ApplicationLayer.Services
{
    public class LoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository login)
        {
            _loginRepository = login;
        }
        public string LoginUser(string useremail, string password)
        {
            if (_loginRepository.IsEmailAvailable(useremail))
            {
                return _loginRepository.LoginUser(useremail, password, out User user);

            }
            else
                return "User is not Registered";
        }

        public bool RegisterUser(User newuser)
        {
           if(!_loginRepository.IsEmailAvailable(newuser.UserEmail))
            {
                _loginRepository.RegisterUser(newuser);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
