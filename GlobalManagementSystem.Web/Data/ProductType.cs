using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Data
{
    public class ProductType : BaseEntity
    {
        [ForeignKey("MakeId")]
        public Make? Make { get; set; }
        public int MakeId { get; set; }

        public string? Name { get; set; }
    }
}
