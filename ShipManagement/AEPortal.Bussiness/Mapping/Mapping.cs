using AutoMapper;

namespace AEPortal.Bussiness.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            SourceMemberNamingConvention = LowerUnderscoreNamingConvention.Instance;
            DestinationMemberNamingConvention = PascalCaseNamingConvention.Instance;
        }
    }

}
