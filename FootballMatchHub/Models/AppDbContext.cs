using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FootballMatchHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<>  { get; set; }
        //public DbSet<>  { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}