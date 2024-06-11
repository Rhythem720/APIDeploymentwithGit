using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;

namespace TurfBooking.Domain.IRepositories
{
    public interface IUserRepository
    {
        
        void UnRegisterUser(User user); 
      
        List<User> GetAllUsers();

        User GetParticularUser(int id);
        User UpdateUserDetails(User user);
    }
}
