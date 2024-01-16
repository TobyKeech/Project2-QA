using Project2.EF;
using Project2.Models;

namespace Project2.Persistence.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {

        public BookingRepository(EstateContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}


