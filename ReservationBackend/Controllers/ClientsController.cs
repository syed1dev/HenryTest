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
    public class ClientsController : Controller
    {
        private readonly ReservationDBContext _context;

        public ClientsController(ReservationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return Ok(client);
        }

    }
}

