using GlobalManagementSystem.Web.Contracts;
using GlobalManagementSystem.Web.Data;

namespace GlobalManagementSystem.Web.Repositoriesy
{
    public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
