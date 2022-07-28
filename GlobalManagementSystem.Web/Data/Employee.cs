using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GlobalManagementSystem.Web.Data
{
    public class Employee : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string? TRN { get; set; }
        public string? NIS { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime Datestarted { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime DateEnded { get; set; }
    }
}
