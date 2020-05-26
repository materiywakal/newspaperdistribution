
namespace NewspaperDistribution.Domain.Models
{
    public class NewspaperPostalOfficeRelation
    {
        public int NewspaperPostalOfficeRelationId { get; set; }
        public int NewspaperId { get; set; }
        public virtual NewspaperModel NewspaperModel { get; set; }
        public int PostalOfficeId { get; set; }
        public virtual PostalOfficeModel PostalOfficeModel { get; set; }
    }
}
