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

        //Get all properties
        [HttpGet]
        public IEnumerable<BookingDTO> Index()
        {
            var booking = _bookingService.FindAll().ToList();
            return booking;
        }
        //Find booking by Id
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public ActionResult<BookingDTO> GetById(int id)
        //{
        //    var booking = _bookingService.FindById(id);
        //    return booking == null ? NotFound() : booking;
        //}
    }
}
