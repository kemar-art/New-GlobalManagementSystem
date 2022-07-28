using System.ComponentModel.DataAnnotations;

namespace GlobalManagementSystem.Web.Models
{
    public class SupplierVM : BaseVM
    {
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        public string Contactnumber { get; set; }

        public string Email { get; set; }
    }
}
