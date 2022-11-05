namespace Luftborn.Dtos
{
    public class CreateProductDto
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public int Amount { get; set; }

        public double Cost { get; set; }
    }
}
