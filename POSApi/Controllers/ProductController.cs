using BusinessLayer.Interface;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utility.CustomException;

namespace POSApi.Controllers
{
    [Route("product")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer",Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        #region Private Fields

        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        #endregion

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="productService">productService instance</param>
        /// <param name="logger">logger instance of productController</param>
        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        /// <summary>
        /// Get list of products for the store
        /// </summary>
        /// <returns>list of products</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (CustomException exception)
            {
                return StatusCode(exception.ErrorDetails.StatusCode, exception.ErrorDetails);
            }
        }

        /// <summary>
        /// To create a product for a store
        /// </summary>
        /// <param name="productDto">ProductDto</param>
        [HttpPost]
        public IActionResult Create(CreateProductDto productDto)
        {
            try
            {
                _productService.Create(productDto);
                return Ok();
            }
            catch (CustomException exception)
            {
                return StatusCode(exception.ErrorDetails.StatusCode, exception.ErrorDetails);
            }
        }

        /// <summary>
        /// Edit product information
        /// </summary>
        /// <param name="editProductDto">EditProduct dto</param>
        /// <returns>UserDto</returns>
        [HttpPut]
        public IActionResult Edit(EditProductDto editProductDto)
        {
            try
            {
                var updatedProduct = _productService.Edit(editProductDto);
                return Ok(updatedProduct);
            }
            catch (CustomException exception)
            {
                _logger.LogError(exception.Message);
                var message = exception.ErrorDetails;
                return StatusCode(message.StatusCode, message);
            }
        }

        /// <summary>
        /// Delete a product from a store.
        /// </summary>
        /// <param name="id">Product Id</param>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch (CustomException exception)
            {
                _logger.LogError(exception.Message);
                var errorDetails = exception.ErrorDetails;
                return StatusCode(errorDetails.StatusCode, errorDetails);
            }
        }
    }
}
