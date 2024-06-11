using TurfBooking.Domain.Entities;
using TurfBooking.Domain.IRepositories;

namespace TurfBooking.ApplicationLayer.Services
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public List<Booking> GetAllBooking()
        {
            var bookings = _bookingRepository.GetAllBookings();
            if(bookings!=null)
            {
                return bookings;
            }
            else
            return null;
        }
        public bool CreateBooking(Booking booking)
        {
            var newbooking = _bookingRepository.GetBooking(booking.BookingId);
            if (newbooking == null)
            {
                _bookingRepository.CreateBooking(booking);
                return true;

            }
            else
                return false;
                

        }
        public bool UpdateBooking(Booking booking)
        {
            
            if(_bookingRepository.GetBooking(booking.BookingId)!=null)
            {
                _bookingRepository.UpdateBooking(booking);
                return true;
            }
            else
                return false;
        }

        public bool DeleteBooking(int bookingid)
        {
            return _bookingRepository.DeleteBooking(bookingid);
        }

        public Booking GetBookingByID(int bookingId)
        {
            var booking = _bookingRepository.GetBooking(bookingId);
            if (booking != null)
                return booking;
            else
                return null;
            
        }
      
    }
}
