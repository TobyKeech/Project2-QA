using Microsoft.AspNetCore.Mvc;
using Project2.EF;
using Project2.Models;

namespace Project2.Persistence.Repositories
{
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public SellerRepository(EstateContext repositoryContext)
            : base(repositoryContext)
        {

        }
    }
}
