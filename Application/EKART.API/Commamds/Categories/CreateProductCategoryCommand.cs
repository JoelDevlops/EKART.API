using MediatR;

namespace EKART.API.Commamds.Categories
{
    public class CreateProductCategoryCommand : ProductCategoryCommand, IRequest<Unit>
    {
     
    }
}
