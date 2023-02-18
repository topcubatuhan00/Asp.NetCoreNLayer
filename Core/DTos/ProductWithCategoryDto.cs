namespace Core.DTos
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto? Category { get; set; }
    }
}
