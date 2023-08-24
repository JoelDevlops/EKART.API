using AutoMapper;
using EKART.API.Commamds.Categories;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Categories;
using EKART.USER.CORE.Services.Others;
using MediatR;

namespace EKART.API.Handlers.Categories
{
    public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoriesRepository;
        private readonly ISessionContext _session;

        public UpdateProductCategoryHandler(IMapper mapper, ICategoryRepository categoryRepository, ISessionContext sessionContext)
        {
            _mapper = mapper;
            _categoriesRepository = categoryRepository;
            _session = sessionContext;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommand updateProductCategoryCommand, CancellationToken cancellationToken)
        {

            EkartProductCategory category = await _categoriesRepository.FindAsync(updateProductCategoryCommand.Id, cancellationToken);
            if (category == null)
            {
                throw
                    new Exception("Data not available");
               
            }
            else
            {
                category = _mapper.Map<EkartProductCategory>(updateProductCategoryCommand);
                category.UpdatedBy = await _session.GetCurrentUser(cancellationToken);
                category.UpdatedOn = DateTime.UtcNow;
                int rowCount = await _categoriesRepository.Update(category, cancellationToken);
            }

            return Unit.Value;
        }
    }
}
