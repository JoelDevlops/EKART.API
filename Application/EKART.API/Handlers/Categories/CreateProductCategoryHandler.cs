using AutoMapper;
using EKART.API.Commamds.Categories;
using EKART.API.DATA.Repositories.Categories;
using EKART.USER.CORE.Entities;
using EKART.USER.CORE.Repositories.Categories;
using EKART.USER.CORE.Services.Others;
using MediatR;

namespace EKART.API.Handlers.Categories
{
    public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, Unit>
    {

        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoriesRepository;
        private readonly ISessionContext _session;

        public CreateProductCategoryHandler(IMapper mapper, ICategoryRepository categoryRepository,ISessionContext sessionContext)
        {
            _mapper = mapper;
            _categoriesRepository = categoryRepository;
            _session = sessionContext;  
        }

        public async Task<Unit> Handle(CreateProductCategoryCommand createProductCategoryCommand, CancellationToken cancellationToken)
        {
           
            EkartProductCategory category = await _categoriesRepository.FindAsync(createProductCategoryCommand.Name, cancellationToken);     
            if (category == null)
            {
                category = _mapper.Map<EkartProductCategory>(createProductCategoryCommand);
                category.CreatedBy = await _session.GetCurrentUser(cancellationToken);
                category.CreatedOn = DateTime.UtcNow;
                int rowCount = await _categoriesRepository.AddCategoryAsync(category, cancellationToken);
            }
            else
            {
                throw new Exception("Duplicate Entry");
            }
            _categoriesRepository.Dispose();
            return Unit.Value;
        }
    }
}
