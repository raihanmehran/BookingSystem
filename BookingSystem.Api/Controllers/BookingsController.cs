using BookingSystem.Api.Models;
using BookingSystem.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : Controller
    {
        private readonly ILogger<BookingsController> _logger;
        private readonly IMessageProducer _messageProducer;

        // In-memory database
        public static readonly List<Booking> _bookings = new List<Booking>();

        public BookingsController(
            ILogger<BookingsController> logger,
            IMessageProducer messageProducer)
        {
            _logger = logger;
            _messageProducer = messageProducer;
        }

        [HttpPost("create")]
        public IActionResult CreatingBooking(Booking newBooking)
        {
            if (!ModelState.IsValid) return BadRequest();

            _bookings.Add(newBooking);

            _messageProducer.SendingMessage<Booking>(newBooking);

            return Ok();
        }
    }
}