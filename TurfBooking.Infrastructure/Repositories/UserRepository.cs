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

namespace TurfBooking.Infrastructure.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDBContext _dbcontext;
       
        public UserRepository(ApplicationDBContext dBContext) 
        {
            _dbcontext = dBContext;
          
        }

        public void UnRegisterUser(User user)
        {
            _dbcontext.users.Remove(user);
            _dbcontext.SaveChanges();    
        }
       

        public List<User> GetAllUsers()
        {
            return _dbcontext.users.ToList();
        }

        public User GetParticularUser(int userid)
        {
            return _dbcontext.users.SingleOrDefault(user => user.UserId == userid);
        }

        public User UpdateUserDetails(User user)
        {
            User user1 = GetParticularUser(user.UserId);
            _dbcontext.Entry(user1).CurrentValues.SetValues(user);
            _dbcontext.SaveChanges();
            return user;
           
        }

     
    }
}
