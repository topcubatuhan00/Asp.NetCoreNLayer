namespace Core.DTos
{
    public class ProductFeatureDto : BaseDto
    {
        public int Id { get; set; }
        public string Color { get; set; }

        public int ProductId { get; set; }

    }
}
