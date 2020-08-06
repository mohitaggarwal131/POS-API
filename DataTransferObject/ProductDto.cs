using System;

namespace DataTransferObject
{
    public class ProductDto
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int AvailableQuantity { get; set; }

        public string Image { get; set; }
    }
}
