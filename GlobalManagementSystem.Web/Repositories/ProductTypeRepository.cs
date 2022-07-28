using GlobalManagementSystem.Web.Contracts;
using GlobalManagementSystem.Web.Data;
using GlobalManagementSystem.Web.Repositoriesy;

namespace GlobalManagementSystem.Web.Repositories
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
