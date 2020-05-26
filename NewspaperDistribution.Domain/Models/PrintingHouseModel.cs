using System.Collections.Generic;

namespace NewspaperDistribution.Domain.Models
{
    public class PrintingHouseModel
    {
        public int PrintingHouseId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int MaxCirculation { get; set; }
        public virtual List<NewspaperPrintingHouseRelation> NewspaperPrintingHouseRelation { get; set; }
    }
}
