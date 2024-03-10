using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManegement.Web.Data
{
    public class LeaveAllocation : BaseEntity  //ferie-fordeling
    {
       

        public int NumberOfDays { get; set; }


        [ForeignKey("LeaveTypesId")]
        public LeaveTypes LeaveTypes { get; set; }
        public int LeaveTypeId { get; set; } //foreignKeyRelationship


        public string EmployeeId { get; set; }


        
    }
}
