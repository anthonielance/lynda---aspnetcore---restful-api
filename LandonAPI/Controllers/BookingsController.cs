using LandonAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LandonAPI.Controllers
{
    public class BookingsController : Controller
    {
        private IBookingService _bookingService;

        public BookingsController(IBookingService bookingService) => _bookingService = bookingService;

        // TODO: authorization
        [HttpGet("{bookingId}", Name = nameof(GetBookingByIdAsync))]
        public async Task<IActionResult> GetBookingByIdAsync(Guid bookingId, CancellationToken ct)
        {
            var booking = await _bookingService.GetBookingAsync(bookingId, ct);
            if (booking == null) return NotFound();

            return Ok(booking);
        }
    }
}
