using Netflix.Domain.Entities;
using Netflix.Infrastructure.Abstractions.DB;

namespace Netflix.Infrastructure.DB.Repository.Tickets
{
    public class TicketRepository : NetflixRepository<Ticket, TicketContext>, ITicketRepository
    {
        public TicketRepository(TicketContext context) : base(context)
        {

        }
    }
}
