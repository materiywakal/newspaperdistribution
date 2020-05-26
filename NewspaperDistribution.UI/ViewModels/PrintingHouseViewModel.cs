using System.Collections.Generic;

namespace NewspaperDistribution.UI.ViewModels
{
    public class PrintingHouseViewModel
    {
        public int PrintingHouseId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public int MaxCirculation { get; set; }
        public List<NewspaperViewModel> NewspaperViewModels { get; set; }
    }
}
