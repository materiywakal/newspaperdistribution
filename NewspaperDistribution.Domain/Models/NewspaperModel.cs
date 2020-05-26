
using System.Collections.Generic;

namespace NewspaperDistribution.Domain.Models
{
    public class NewspaperModel
    {
        public int NewspaperId { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public virtual List<NewspaperPrintingHouseRelation> NewspaperPrintingHouseRelation { get; set; }
        public virtual List<NewspaperPostalOfficeRelation> NewspaperPostalOfficeRelation { get; set; }
    }
}
