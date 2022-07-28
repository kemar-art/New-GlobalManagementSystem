using GlobalManagementSystem.Web.Contracts;
using GlobalManagementSystem.Web.Data;
using GlobalManagementSystem.Web.Repositoriesy;

namespace GlobalManagementSystem.Web.Repositories
{
    public class RestockRepository : GenericRepository<Restock>, IRestockRepository
    {
        public RestockRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
