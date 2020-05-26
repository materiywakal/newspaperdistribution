
namespace NewspaperDistribution.Domain.Models
{
    public class NewspaperPrintingHouseRelation
    {
        public int NewspaperPrintingHouseRelationId { get; set; }
        public int NewspaperId { get; set; }
        public virtual NewspaperModel NewspaperModel { get; set; }
        public int PrintingHouseId { get; set; }
        public virtual PrintingHouseModel PrintingHouseModel { get; set; }
    }
}
