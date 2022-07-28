using GlobalManagementSystem.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Models
{
    public class ModelVM : BaseVM
    {
        [Display(Name = "Product Type")]
        public ProductTypeVM ProductType { get; set; }
        public int ProductTypeId { get; set; }

        [Display(Name = "Model")]
        [Required]
        public string Name { get; set; }
    }
}
