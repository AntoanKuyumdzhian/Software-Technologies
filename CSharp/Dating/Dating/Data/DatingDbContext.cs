using System.Data.Entity;
using Dating.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Dating.Data
{
    public class DatingDbContext : IdentityDbContext<User>
    {
        public DatingDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Profile> Profiles { get; set; }

        public static DatingDbContext Create()
        {
            return new DatingDbContext();
        }
    }
}