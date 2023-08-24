using AutoMapper;
using EKART.API.Models.Category;
using EKART.API.Models.UserDetail;
using EKART.API.Queries.Categories;
using EKART.API.Queries.UserDetail;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Categories;
using EKART.USER.CORE.Repositories.UserDetails;
using MediatR;

namespace EKART.API.Handlers.UserDetail
{
    public class GetAllProductCategoryHandler : IRequestHandler<GetAllProductCategoryQuery, IEnumerable<ProductCategoryListItem>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesReadRepository _categoriesReadRepository;
        public GetAllProductCategoryHandler(IMapper mapper, ICategoriesReadRepository categoriesReadRepository)
        {
            _mapper = mapper;
            _categoriesReadRepository = categoriesReadRepository;
        }

        public async Task<IEnumerable<ProductCategoryListItem>> Handle(GetAllProductCategoryQuery getAllProductCategoryQuery, CancellationToken cancellationToken)
        {

            IEnumerable<EkartProductCategory> ekartProductCategories = await _categoriesReadRepository.GetAll(getAllProductCategoryQuery.IsActive, cancellationToken);
            _categoriesReadRepository.Dispose();
            return _mapper.Map<IEnumerable<ProductCategoryListItem>>(ekartProductCategories);
        }


    }
}
