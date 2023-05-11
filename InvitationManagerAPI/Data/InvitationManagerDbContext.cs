using InvitationManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvitationManagerAPI.Data
{
    public class InvitationManagerDbContext : DbContext
    {
        public InvitationManagerDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }

        public DbSet<CalendarBookings> Bookings { get; set; }
    }
}
