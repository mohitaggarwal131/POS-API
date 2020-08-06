namespace DataTransferObject
{
    public class CreateProductDto
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int AvailableQuantity { get; set; }
        public string Image { get; set; }
    }
}
