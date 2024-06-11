using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;

namespace TurfBooking.Domain.IRepositories
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBookings();
        Booking GetBooking(int bookingid);
        Booking UpdateBooking(Booking booking);
        bool DeleteBooking(int bookingid);
        void CreateBooking(Booking booking);
    }
}
