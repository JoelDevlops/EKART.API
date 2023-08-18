using AutoMapper;
using EKART.API.DATA.Repositories.Token;
using EKART.API.Models.Authorization;
using EKART.API.Queries.Authorization;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Authorization;
using EKART.USER.CORE.Repositories.Token;
using EKART.USER.CORE.Repositories.UserDetails;
using EKART.USER.CORE.Services.Others;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace EKART.API.Handlers.Authorization
{
   
    public class ReloadRefreshTokenHandler : IRequestHandler<ReloadRefreshTokenQuery, TokenListItem>
    {
        private readonly IMapper _mapper;
        private IAuthorizeRepository _repository;
        private ITokenGenerator _tokenGeneratorrepository;
        private IConfiguration _configuration;
        private IUserDetailsRepository _userDetailsRepository;
        private ITokenDetailsRepository _tokenDetailsRepository;
        public ReloadRefreshTokenHandler(IMapper mapper, IAuthorizeRepository repository, ITokenGenerator tokenGeneratorrepository, IConfiguration configuration, IUserDetailsRepository userDetailsRepository, ITokenDetailsRepository tokenDetailsRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _configuration = configuration;
            _tokenGeneratorrepository = tokenGeneratorrepository;
            _userDetailsRepository = userDetailsRepository;
            _tokenDetailsRepository = tokenDetailsRepository;

        }

        public async Task<TokenListItem> Handle(ReloadRefreshTokenQuery reloadRefreshTokenQuery, CancellationToken cancellationToken)
        {
           TokenListItem tokenListItem = new TokenListItem();
           var now = DateTime.Now;
           var tokenDetails = await _tokenDetailsRepository.FindWithRefreshToken(reloadRefreshTokenQuery.RefreshToken,cancellationToken);
           var tokenValidityInMinutes = int.Parse(_configuration["Jwt:TokenValidityInMinutes"]);
           var refreshTokenValidityInDays = int.Parse(_configuration["Jwt:RefreshTokenValidityInDays"]);
            if (tokenDetails == null) {
                throw new InvalidOperationException("User not found.");
            }
            if(DateTime.Now >   tokenDetails.RefreshExpiry)
            {
                throw new InvalidOperationException("Invalid refresh token.");
            }
            EkartUserDetail ekartUserDetail = await _userDetailsRepository.GetById(tokenDetails.UserId,cancellationToken); 
            var jwtToken = await _tokenGeneratorrepository.GenerateJWTToken(ekartUserDetail.Email, cancellationToken);
            var refreshToken = await _tokenGeneratorrepository.GenerateRefreshToken(cancellationToken);
            tokenListItem.JwtToken = jwtToken;  
            tokenListItem.RefreshToken = refreshToken;

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
            return tokenListItem;
        }

      
    }
}
