using GlobalManagementSystem.Web.Contracts;
using GlobalManagementSystem.Web.Data;
using GlobalManagementSystem.Web.Repositoriesy;

namespace GlobalManagementSystem.Web.Repositories
{
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
