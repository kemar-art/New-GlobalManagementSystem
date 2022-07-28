using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalManagementSystem.Web.Data
{
    public class Product : BaseEntity
    {
        [ForeignKey("ModelId")]
        public Model? Model { get; set; }
        public int ModelId { get; set; }

        [ForeignKey("ConditionId")]
        public Condition Condition { get; set; }
        public int ConditionId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
        public string? Serialnumber { get; set; }
        public int QTY { get; set; }
        public double Unitcost { get; set; }
    }
}
