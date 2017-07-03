using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ads.Models
{
    public class AdsDbContext : IdentityDbContext<User>
    {
        public AdsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Ad> Ads { get; set; }

        public static AdsDbContext Create()
        {
            return new AdsDbContext();
        }
    }
}