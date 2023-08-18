
using AutoMapper;
using EKART.API.DATA.Repositories.Token;
using EKART.API.Models.Authorization;
using EKART.API.Models.UserDetail;
using EKART.API.Queries.Authorization;
using EKART.API.Queries.UserDetail;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Authorization;
using EKART.USER.CORE.Repositories.Token;
using EKART.USER.CORE.Repositories.UserDetails;
using EKART.USER.CORE.Services.Others;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace EKART.API.Handlers.UserDetail
{

    public class GetAllUserDetailHandler : IRequestHandler<GetAllUserDetailQuery, IEnumerable<UserDetailListItem>>
    {
        private readonly IMapper _mapper;
        private IUserDetailsRepository _userDetailsRepository;
        public GetAllUserDetailHandler(IMapper mapper,IUserDetailsRepository userDetailsRepository)
        {
            _mapper = mapper;
            _userDetailsRepository = userDetailsRepository;
        }

        public async Task <IEnumerable<UserDetailListItem>> Handle(GetAllUserDetailQuery getAllUserDetailQuery, CancellationToken cancellationToken)
        {

            IEnumerable<EkartUserDetail> ekartUserDetail = await _userDetailsRepository.GetAll(getAllUserDetailQuery.IsActive,cancellationToken);
            _userDetailsRepository.Dispose();
            return _mapper.Map<IEnumerable<UserDetailListItem>>(ekartUserDetail);   
        }


    }
}
