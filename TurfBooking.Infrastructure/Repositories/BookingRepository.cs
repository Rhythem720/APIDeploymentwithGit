using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurfBooking.Domain.Entities;
using TurfBooking.Domain.IRepositories;
using TurfBooking.Infrastructure.Data;

namespace TurfBooking.Infrastructure.Services
{
    public class BookingRepository : IBookingRepository
    {
        public readonly ApplicationDBContext _applicationDBContext;
        public BookingRepository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
        }
        public void CreateBooking(Booking booking)
        {

            _applicationDBContext.bookings.Add(booking);
            _applicationDBContext.SaveChanges();
        }

        public bool DeleteBooking(int bookingid)
        {
           Booking booking= GetBooking(bookingid);
            if (booking == null)
            {
                return false;
            }
            else
                return true;
        }

        public List<Booking> GetAllBookings()
        {
            return _applicationDBContext.bookings.ToList();
        }

        public Booking GetBooking(int bookingId)
        {
            return _applicationDBContext.bookings.SingleOrDefault(x=>x.BookingId==bookingId);

        }

        public Booking UpdateBooking(Booking booking)
        {
            Booking booking1= _applicationDBContext.bookings.SingleOrDefault(x=>x.BookingId==booking.BookingId);
           if(booking1!=null)
            {
                _applicationDBContext.Entry(booking1).CurrentValues.SetValues(booking);
                _applicationDBContext.SaveChanges();
                return booking;
            }
           else
           return null;

        }
    }
}
