using Netflix.Domain.Entities;

namespace Netflix.Infrastructure.DB.Repository.Tickets
{
    public class TicketRepository : NetflixRepository<Ticket, TicketContext>
    {
        public TicketRepository(TicketContext context) : base(context)
        {

        }
    }
}
