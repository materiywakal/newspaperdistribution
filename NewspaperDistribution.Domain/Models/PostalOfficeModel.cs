using System.Collections.Generic;

namespace NewspaperDistribution.Domain.Models
{
    public class PostalOfficeModel
    {
        public int PostalOfficeId { get; set; }
        public int OfficeNumber { get; set; }
        public string Address { get; set; }
        public virtual List<NewspaperPostalOfficeRelation> NewspaperPostalOfficeRelation { get; set; }
    }
}
