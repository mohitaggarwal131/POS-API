using BusinessLayer.Interface;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Utility.CustomException;

namespace POSApi.Controllers
{
    [Route("sale")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,User")]
    public class SaleController : ControllerBase
    {
        #region Private Fields

        private readonly ISaleService _saleService;

        #endregion

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="saleService">saleService instance</param>
        /// <param name="logger">logger instance of saleController</param>
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// To create a sale record
        /// </summary>
        /// <param name="saleDto">SaleDto</param>
        [HttpPost]
        public IActionResult Create(SaleDto saleDto)
        {
            try
            {
                 _saleService.Create(saleDto);
                return Ok();
            }
            catch (CustomException exception)
            {
                return StatusCode(exception.ErrorDetails.StatusCode, exception.ErrorDetails);
            }
        }
    }
}
