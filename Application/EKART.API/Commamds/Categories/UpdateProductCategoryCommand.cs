using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EKART.API.Commamds.Categories
{
    public class UpdateProductCategoryCommand : ProductCategoryCommand, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
