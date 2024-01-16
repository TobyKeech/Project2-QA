using Project2.EF;
using Project2.Models;

namespace Project2.Persistence.Repositories
{
    public class BuyerRepository : RepositoryBase<Buyer>, IBuyerRepository
    {
        public BuyerRepository(EstateContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
