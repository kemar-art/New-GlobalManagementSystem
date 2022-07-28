using GlobalManagementSystem.Web.Contracts;
using GlobalManagementSystem.Web.Data;

namespace GlobalManagementSystem.Web.Repositoriesy
{
    public class MakeRepository : GenericRepository<Make>, IMakeRepository
    {
        public MakeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
