using AutoMapper;
using EKART.API.Models.Authorization;
using EKART.API.Queries.Authorization;
using EKART.USER.CORE.DTO.AuthDTO;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Authorization;
using EKART.USER.CORE.Repositories.Token;
using EKART.USER.CORE.Repositories.UserDetails;
using EKART.USER.CORE.Services.Others;
using MediatR;


namespace EKART.API.Handlers.Authorization
{
    public class AuthorizeHandler : IRequestHandler<AuthorizationQuery, TokenWithRolesListItem>
    {
        private readonly IMapper _mapper;
        private IAuthorizeRepository _repository;
        private ITokenGenerator _tokenGeneratorrepository;
        private IConfiguration _configuration;
        private IUserDetailsRepository _userDetailsRepository;
        private ITokenDetailsRepository _tokenDetailsRepository;
        public AuthorizeHandler(IMapper mapper, IAuthorizeRepository repository, ITokenGenerator tokenGeneratorrepository, IConfiguration configuration, IUserDetailsRepository userDetailsRepository,ITokenDetailsRepository tokenDetailsRepository )
        {
            _mapper = mapper;
            _repository = repository;   
            _configuration = configuration;
            _tokenGeneratorrepository = tokenGeneratorrepository;   
            _userDetailsRepository = userDetailsRepository; 
            _tokenDetailsRepository = tokenDetailsRepository;

        }

        public async Task<TokenWithRolesListItem> Handle(AuthorizationQuery authorizationQuery, CancellationToken cancellationToken)
        {
            var tokenWithRolesListItem = new TokenWithRolesListItem();
            var now = DateTime.Now;
            var tokenValidityInMinutes = int.Parse(_configuration["Jwt:TokenValidityInMinutes"]);
            var refreshTokenValidityInDays = int.Parse(_configuration["Jwt:RefreshTokenValidityInDays"]);
            var rolesDTO = await _repository.AuthorizeAsync(authorizationQuery.UserName, authorizationQuery.Password, cancellationToken);

            if (!rolesDTO.Any())
                return tokenWithRolesListItem;

            tokenWithRolesListItem.Roles = rolesDTO.Select(p => p.Roles).ToArray();
            var jwtToken = await _tokenGeneratorrepository.GenerateJWTToken(authorizationQuery.UserName, cancellationToken);
            var refreshToken = await _tokenGeneratorrepository.GenerateRefreshToken(cancellationToken);
            var ekartUserDetail = await _userDetailsRepository.GetByEmail(authorizationQuery.UserName, cancellationToken);
            var tokenDetails = await _tokenDetailsRepository.FindAsync(ekartUserDetail.Id, cancellationToken);

            if (tokenDetails == null)
            {
                tokenDetails = new EkartTokenDetails
                {
                    UserId = ekartUserDetail.Id
                };

                tokenDetails.JWTToken = jwtToken;
                tokenDetails.RefreshToken = refreshToken;
                tokenDetails.JWTExpiry = now.AddMinutes(tokenValidityInMinutes);
                tokenDetails.RefreshExpiry = now.AddDays(refreshTokenValidityInDays);

                await _tokenDetailsRepository.SaveToken(tokenDetails, cancellationToken);
            }
            else
            {
                tokenDetails.JWTToken = jwtToken;
                tokenDetails.RefreshToken = refreshToken;
                tokenDetails.JWTExpiry = now.AddMinutes(tokenValidityInMinutes);
                tokenDetails.RefreshExpiry = now.AddDays(refreshTokenValidityInDays);

                await _tokenDetailsRepository.Update(tokenDetails, cancellationToken);
            }
            tokenWithRolesListItem.JwtToken = jwtToken;
            tokenWithRolesListItem.RefreshToken = refreshToken;
            return tokenWithRolesListItem;
        }



    }
}
