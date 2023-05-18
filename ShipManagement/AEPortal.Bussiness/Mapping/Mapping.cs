using AEPortal.Bussiness.ResponseModel;
using AEPortal.Bussiness.ViewModel;
using AEPortal.Common.Models;
using AEPortal.Data.Entities;
using AutoMapper;

namespace AEPortal.Bussiness.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            SourceMemberNamingConvention = LowerUnderscoreNamingConvention.Instance;
            DestinationMemberNamingConvention = PascalCaseNamingConvention.Instance;

            CreateMap<Ship, ShipResponseDto>();
            CreateMap<ShipCreateViewModel, Ship>();
            CreateMap<ShipUpdateViewModel, Ship>();
            CreateMap<PageList<Ship>, PageList<ShipResponseDto>>();
        }
    }

}
