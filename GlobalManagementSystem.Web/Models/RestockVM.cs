using GlobalManagementSystem.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Models
{
    public class RestockVM : BaseVM
    {
        public ProductVM Product { get; set; }
        [Display(Name = "Product")]
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int QTY { get; set; }

        [Required]
        public double Cost { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Arriveddate { get; set; }

        [Display(Name = "Order Status")]
        public string Orderstatus { get; set; }

        public Supplier Supplier { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
    }
}
