using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;
using Ads.Helpers;

namespace Ads.Models
{
    public class Ad
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public ConditionType Condition { get; set; }

        [Required]
        public string Description { get; set; }

        public double Price { get; set; }

        [Required]
        public Categories Category { get; set; }

        [Required]
        public Cities City { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }

        [ImageUrl]
        [Display(Name = "Picture")]
        public string ImageUrl { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}