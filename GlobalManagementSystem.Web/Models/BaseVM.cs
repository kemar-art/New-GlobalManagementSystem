namespace GlobalManagementSystem.Web.Models
{
    public abstract class BaseVM
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
