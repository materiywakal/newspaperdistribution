using System.Linq;
using AutoMapper;
using NewspaperDistribution.Domain.Models;
using NewspaperDistribution.UI.ViewModels;

namespace NewspaperDistribution.UI.MapperProfiles
{
    public class NewspaperDistributionProfile : Profile
    {
        public NewspaperDistributionProfile()
        {
            CreateMap<NewspaperViewModel, NewspaperModel>()
                .ForMember(e => e.NewspaperPostalOfficeRelation, o => o.MapFrom(m => m.PostalOfficeViewModels))
                .ForMember(e => e.NewspaperPrintingHouseRelation, o => o.MapFrom(m => m.PrintingHouseViewModels))
                .AfterMap((model, entity) =>
                {
                    foreach (var entityNewspaperPostalOffice in entity.NewspaperPostalOfficeRelation)
                    {
                        entityNewspaperPostalOffice.NewspaperModel = entity;
                    }

                    foreach (var entityNewspaperPrintingHouse in entity.NewspaperPrintingHouseRelation)
                    {
                        entityNewspaperPrintingHouse.NewspaperModel = entity;
                    }
                });
            CreateMap<PostalOfficeViewModel, NewspaperPostalOfficeRelation>()
                .ForMember(e => e.PostalOfficeModel, o => o.MapFrom(m => m));
            CreateMap<PrintingHouseViewModel, NewspaperPrintingHouseRelation>()
                .ForMember(e => e.PrintingHouseModel, o => o.MapFrom(m => m));
            CreateMap<PostalOfficeViewModel, PostalOfficeModel>();
            CreateMap<PrintingHouseViewModel, PrintingHouseModel>();

            CreateMap<NewspaperModel, NewspaperViewModel>()
                .ForMember(e => e.PostalOfficeViewModels,
                    o => o.MapFrom(m => m.NewspaperPostalOfficeRelation.Select(x => x.PostalOfficeModel).ToList()))
                .ForMember(e => e.PrintingHouseViewModels,
                    o => o.MapFrom(m => m.NewspaperPrintingHouseRelation.Select(x => x.PrintingHouseModel).ToList()));
            CreateMap<PostalOfficeModel, PostalOfficeViewModel>()
                .ForMember(e => e.NewspaperViewModels,
                    o => o.MapFrom(m => m.NewspaperPostalOfficeRelation.Select(x => x.NewspaperModel).ToList()));
            CreateMap<PrintingHouseModel, PrintingHouseViewModel>()
                .ForMember(e => e.NewspaperViewModels,
                    o => o.MapFrom(m => m.NewspaperPrintingHouseRelation.Select(x => x.NewspaperModel).ToList()));
        }
    }
}
