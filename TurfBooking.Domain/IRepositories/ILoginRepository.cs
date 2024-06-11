using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;

namespace TurfBooking.Domain.IRepositories
{
    public interface ILoginRepository
    {
        string LoginUser(string email, string password, out User user);
        
        bool RegisterUser(User user);
        bool IsEmailAvailable(string email);

    }
}
