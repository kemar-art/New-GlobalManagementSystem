using GlobalManagementSystem.Web.Data;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagementSystem.Web.Models
{
    public class MakeVM : BaseVM
    {
        [Display(Name = "Parts Name")]
        [Required]
        public string Name { get; set; }
    }
}
