using GlobalManagementSystem.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Models
{
    public class ProductVM : BaseVM
    {
        public ModelVM Model { get; set; }
        [Required]
        public int ModelId { get; set; }


        [ForeignKey("ConditionId")]
        public Condition Condition { get; set; }
        public int ConditionId { get; set; }


        [Required]
        public string Description { get; set; }

        [Display(Name = "Serial Number")]
        [Required]
        public string Serialnumber { get; set; }

        [Display(Name = "Product")]
        public string Name { get; set; }

        public int QTY { get; set; }

        [Display(Name = "Price")]
        public double Unitcost { get; set; }
    }
}
