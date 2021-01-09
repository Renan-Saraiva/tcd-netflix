using Microsoft.EntityFrameworkCore;
using Netflix.Domain.Entities;

namespace Netflix.Infrastructure.DB.Repository.Tickets
{

    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
