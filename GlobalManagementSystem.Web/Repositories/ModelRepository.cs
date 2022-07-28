using GlobalManagementSystem.Web.Contracts;
using GlobalManagementSystem.Web.Data;

namespace GlobalManagementSystem.Web.Repositoriesy
{
    public class ModelRepository : GenericRepository<Model>, IModelRepository
    {
        public ModelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
