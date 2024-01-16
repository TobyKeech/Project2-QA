using System.Diagnostics;
using AutoMapper;
using System.Linq.Expressions;
using Project2.Business.DTO;
using Project2.Models;
using Project2.Persistence.Repositories;

namespace Project2.Business.Services
{
    public class BookingService : IBookingService
    {
        IBookingRepository _bookingRepository;
        private IMapper _mapper;

        public BookingDTO Create(BookingDTO dtoBooking)
        {
            Booking bookingData = _mapper.Map<Booking>(dtoBooking);
            bookingData = _bookingRepository.Create(bookingData);
            dtoBooking = _mapper.Map<BookingDTO>(bookingData);
            return dtoBooking;
        }

        public void Delete(BookingDTO dtoBooking)
        {
            Booking bookingData = _mapper.Map<Booking>(dtoBooking);
            _bookingRepository.Delete(bookingData);
        }

        public IQueryable<BookingDTO> FindAll()
        {
            var bookings = _bookingRepository.FindAll().ToList();
            List<BookingDTO> dtoBookings = new List<BookingDTO>();
            foreach (Booking booking in bookings)
            {
                dtoBookings.Add(_mapper.Map<BookingDTO>(booking));
            }
            return dtoBookings.AsQueryable();
        }

        public BookingDTO FindById(int id)
        {
            Booking booking = _bookingRepository.FindById(id);
            BookingDTO dtoBooking = _mapper.Map<BookingDTO>(booking);
            return dtoBooking;
        }

        public BookingDTO Update(BookingDTO booking)
        {
            Booking bookingData = _mapper.Map<Booking>(booking);
            var b = _bookingRepository.FindById(bookingData.Id);
            if (b == null)
                return null;

            b.BuyerId = bookingData.BuyerId;
            b.PropertyId = bookingData.PropertyId;
            b.Time = bookingData.Time;

            Booking book = _bookingRepository.Update(b);
            BookingDTO dtoBooking = _mapper.Map<BookingDTO>(book);
            return dtoBooking;

        }


    }
}
