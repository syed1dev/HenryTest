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
    public class ProviderController : Controller
    {
        private readonly ReservationDBContext _context;

        public ProviderController(ReservationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvider(Provider provider)
        {
            _context.Providers.Add(provider);
            await _context.SaveChangesAsync();
            return Ok(provider);
        }
    }
}

