using DataTransferObject;
using Entities;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// Retrieves list of products for a store
        /// </summary>
        /// <returns>List of Products</returns>
        IEnumerable<Product> GetAll();

        /// <summary>
        /// Creates a product for a store
        /// </summary>
        /// <param name="productDto">CreateProductDto</param>
        void Create(CreateProductDto productDto);

        /// <summary>
        /// Edit product details 
        /// </summary>
        /// <param name="productDto">CreateProductDto</param>
        ProductDto Edit(EditProductDto productDto);

        /// <summary>
        /// Delete products from a store 
        /// </summary>
        /// <param name="id">id</param>
        void Delete(int id);
    }
}
