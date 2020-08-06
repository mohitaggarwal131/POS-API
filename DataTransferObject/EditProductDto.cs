namespace DataTransferObject
{
    public class EditProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int AvailableQuantity { get; set; }

        public string Image { get; set; }
    }
}
