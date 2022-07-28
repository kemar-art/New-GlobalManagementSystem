using GlobalManagementSystem.Web.Data;
using GlobalManagementSystem.Web.Models;


namespace GlobalManagementSystem.Web.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<ProductVM> GetProductview(int id);
    }
}
