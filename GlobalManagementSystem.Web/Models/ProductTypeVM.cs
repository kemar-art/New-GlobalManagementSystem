using GlobalManagementSystem.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Models
{
    public class ProductTypeVM : BaseVM
    {
        public MakeVM Make { get; set; }
        [Display(Name = "Parts Name")]
        [Required]
        public int MakeId { get; set; }

        [Display(Name = "Parts Type")]
        [Required]
        public string Name { get; set; }
    }
}
