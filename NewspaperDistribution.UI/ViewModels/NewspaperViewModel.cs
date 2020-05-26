using System.Collections.Generic;

namespace NewspaperDistribution.UI.ViewModels
{
    public class NewspaperViewModel
    {
        public int NewspaperId { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public List<PrintingHouseViewModel> PrintingHouseViewModels { get; set; }
        public List<PostalOfficeViewModel> PostalOfficeViewModels { get; set; }
    }
}
