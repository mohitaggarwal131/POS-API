using System.Collections.Generic;

namespace DataTransferObject
{
    public class SaleDto
    {
        public int UserId { get; set; }
        public decimal Discount { get; set; }
        public decimal VATAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public IEnumerable<SaleItemDto> SaleItems { get; set; }
    }
}
