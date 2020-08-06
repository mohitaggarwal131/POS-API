using DataTransferObject;

namespace BusinessLayer.Interface
{
    public interface ISaleService
    {
        /// <summary>
        /// Creates a sale record
        /// </summary>
        /// <param name="saleDto">saleDto</param>
        void Create(SaleDto saleDto);
    }
}
