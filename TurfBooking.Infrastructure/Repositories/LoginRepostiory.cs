using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;
using TurfBooking.Domain.IRepositories;
using TurfBooking.Infrastructure.Data;
using TurfBooking.Infrastructure.JwtServices;

namespace TurfBooking.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IConfiguration _config;

        public LoginRepository(ApplicationDBContext applicationDBContext,IConfiguration configuration)
        {
            _dbContext = applicationDBContext;
            _config= configuration;
        }
        public string LoginUser(string email, string password, out User user)
        {
            user = _dbContext.users.SingleOrDefault(user => user.UserEmail == email && user.Password == password);
            if(user!=null)
            {
               return AuthenticateUser(email, password,user);
            }
            else
            {
                return $"User Not Found with email {email}";
            }
           
        }

        private string AuthenticateUser(string email, string password,User user)
        {
            if (user != null)
            {
                var jwt = new JWTService(_config);
                return jwt.GenerateJSONWebToken(user);

            }
            else
                return "UserName or password Incorrect";
        }

        public bool RegisterUser(User user)
        {
            if (_dbContext.users.Add(user) != null)
            {
                _dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
       
        public bool IsEmailAvailable(string email)
        {
            User user = _dbContext.users.SingleOrDefault(u => u.UserEmail == email);
                if(user!=null)
                return true;
                else
                return false;

        }
    }
}
