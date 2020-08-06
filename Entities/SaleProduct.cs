namespace Entities
{
    public class SaleProduct
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
