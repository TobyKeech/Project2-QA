using Microsoft.AspNetCore.Mvc;
using Project2.Business.DTO;
using Project2.Business.Services;
using System.Net;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //Get all bookings
        [HttpGet]
        public IEnumerable<BookingDTO> Index()
        {
            var booking = _bookingService.FindAll().ToList();
            return booking;
        }
        //Find booking by Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDTO> GetById(int id)
        {
            var booking = _bookingService.FindById(id);
            return booking == null ? NotFound() : booking;
        }

        //Add booking
        [HttpPost()]
        public BookingDTO AddBooking(BookingDTO booking)
        {
            booking = _bookingService.Create(booking);
            return booking;
        }

        // UPDATE: Booking
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDTO> UpdateBooking(BookingDTO booking)
        {

            booking = _bookingService.Update(booking);
            return booking;
        }

        //Delete booking via id
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public HttpStatusCode DeleteBooking(int id)
        {
            var booking = _bookingService.FindById(id);
            if (booking == null)
                return HttpStatusCode.NotFound;
            _bookingService.Delete(booking);
            return HttpStatusCode.NoContent;
        }

    }
}
