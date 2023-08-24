using EKART.API.Models.Category;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EKART.API.Queries.Categories
{
    public class GetAllProductCategoryQuery : IRequest<IEnumerable<ProductCategoryListItem>>
    {
        [Required]
        public bool IsActive { get; set; }  
    }
}
