using InvitationManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvitationManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public  DbSet<protokollUser> Users => Set<protokollUser>();
    }
}
