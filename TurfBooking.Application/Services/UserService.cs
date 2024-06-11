using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;
using TurfBooking.Domain.IRepositories;

namespace TurfBooking.ApplicationLayer.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
                _userRepository= userRepository;
        }

      
       public User GetUser(int id)
        {
            User old_user = _userRepository.GetParticularUser(id);
            if (old_user != null)
            {
                return old_user;
            }
            else
                return null;
        }

        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            if (users != null)
            {
                return users;
            }
            else
                return null;
        }
        public bool UnRegisterUser(int id)
        {  User  user= _userRepository.GetParticularUser(id);
            if(user!=null)
            {
                _userRepository.UnRegisterUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateUserDetails(User user)
        {
            if (user != null && GetUser(user.UserId) != null)
            {
                _userRepository.UpdateUserDetails(user);
                return true;
            }
            else
                return false;
        }
    }
}
