namespace LeaveManegement.Web.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; } //when created

        public DateTime DateModified { get; set; } //when modified

    }
}
