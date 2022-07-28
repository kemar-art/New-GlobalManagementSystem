using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Data
{
    public class Inventory : BaseEntity
    {
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int ProductId { get; set; }

        public int QTY { get; set; }
        public string? Status { get; set; }
    }
}
