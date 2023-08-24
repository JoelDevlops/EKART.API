using System.Text.Json.Serialization;

namespace EKART.API.Commamds.Categories
{
    public class ProductCategoryCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
