namespace Luftborn.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public int Amount { get; set; }

        public double Cost { get; set; }
    }
}
