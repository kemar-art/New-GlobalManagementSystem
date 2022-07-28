using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Data
{
    public class Model : BaseEntity
    {
        [ForeignKey("ProductTypeId")]
        public ProductType? ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public string? Name { get; set; }
    }
}
