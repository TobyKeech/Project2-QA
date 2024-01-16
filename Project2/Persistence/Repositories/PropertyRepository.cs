using Project2.EF;
using Project2.Models;

namespace Project2.Persistence.Repositories
{
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(EstateContext repostioryContext)
            : base(repostioryContext)
        {

        }
    }
}
