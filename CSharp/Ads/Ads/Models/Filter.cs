namespace Ads.Models
{
    public class Filter
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public Categories Category { get; set; }

        public Cities City { get; set; }

        public ConditionType Condition { get; set; }
    }
}