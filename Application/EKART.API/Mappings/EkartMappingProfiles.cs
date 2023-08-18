using AutoMapper;
using EKART.API.Models.Authorization;
using EKART.API.Models.UserDetail;
using EKART.USER.CORE.DTO.AuthDTO;
using EKART.USER.CORE.Entities;

namespace EKART.API.Mappings
{
    public class EkartMappingProfiles : Profile
    {
        public EkartMappingProfiles() {

            CreateMap<TokenWithRolesDTO, TokenWithRolesListItem>();
            CreateMap<EkartUserDetail, UserDetailListItem>();
        }
    }
}
