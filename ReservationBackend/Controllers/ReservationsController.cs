using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationBackend.DBContext;
using ReservationBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationBackend.Controllers
{
    [Route("api/[controller]")]
    public class ReservationsController : Controller
    {
        private readonly ReservationDBContext _context;

        public ReservationsController(ReservationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(Reservation reservation)
        {
            // Check if the reservation time is at least 24 hours in advance
            if (reservation.StartTime <= DateTime.Now.AddHours(24))
            {
                return BadRequest("Reservations must be made at least 24 hours in advance.");
            }

            // Check if the selected time slot is available in the provider's schedule
            var provider = await _context.Providers.FindAsync(reservation.ProviderId);
            if (provider == null)
            {
                return NotFound("Provider not found.");
            }

            var availableSlot = provider.Schedule.Find(slot =>
                slot.StartTime == reservation.StartTime && slot.EndTime == reservation.EndTime);

            if (availableSlot == null)
            {
                return BadRequest("The selected time slot is not available.");
            }

            // Add the reservation to the database
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return Ok(reservation);
        }

        [HttpPost("{reservationId}/confirm")]
        public async Task<IActionResult> ConfirmReservation(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);
            if (reservation == null)
            {
                return NotFound("Reservation not found.");
            }

            reservation.IsConfirmed = true;
            await _context.SaveChangesAsync();
            return Ok(reservation);
        }
    }
}

