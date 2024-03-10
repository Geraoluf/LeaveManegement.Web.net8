using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManegement.Web.Data
{                                      
    public class ApplicationDbContext : IdentityDbContext<Employee>
                                        //IdentityDbContext i din kode, vil det være tilpasset
                                        //til brug med brugerobjekter af typen Employee
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveTypes> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

    }
}
