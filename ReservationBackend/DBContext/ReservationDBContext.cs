using System;
using ReservationBackend.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReservationBackend.DBContext
{
	public class ReservationDBContext : DbContext
    {
        public ReservationDBContext(DbContextOptions<ReservationDBContext> options) : base(options)
        {
        }
        
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}

