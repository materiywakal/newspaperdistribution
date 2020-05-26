using System.Collections.Generic;

namespace NewspaperDistribution.UI.ViewModels
{
    public class PostalOfficeViewModel
    {
        public int PostalOfficeId { get; set; }
        public int OfficeNumber { get; set; }
        public string Address { get; set; }
        public List<NewspaperViewModel> NewspaperViewModels { get; set; }
    }
}
