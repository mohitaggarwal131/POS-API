using BusinessLayer.Interface;
using DataTransferObject;
using Entities;
using InfrastructureLayer.Interfaces;
using System;
using System.Net;
using Utility;
using Utility.CustomException;

namespace BusinessLayer.Implementations
{
    public class SaleService : ISaleService
    {
        #region Private Fields

        private readonly IUnitOfWork _unitOfWork;
        private Object lockObject = new Object();

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="unitOfWork">Object of UnitOfWork</param>
        public SaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        /// <summary>
        /// Creates a sale record
        /// </summary>
        /// <param name="saleDto">saleDto</param>
        public void Create(SaleDto saleDto)
        {
            lock (lockObject) {
                Sale sale = new Sale()
                {
                    InvoiceNumber = Guid.NewGuid(),
                    SaleDate = DateTime.Now,
                    Discount = saleDto.Discount,
                    VATAmount = saleDto.VATAmount,
                    TotalAmount = saleDto.TotalAmount
                };
                var user = _unitOfWork.UserRepository.GetById(saleDto.UserId) ?? throw new CustomException(HttpStatusCode.NotFound, Constants.ErrorUserNotFound);
                sale.UserId = user.Id;
                foreach (var saleItem in saleDto.SaleItems)
                {
                    var product = _unitOfWork.ProductRepository.GetById(saleItem.ProductId) ?? throw new CustomException(HttpStatusCode.NotFound, Constants.ErrorProductNotFound);
                    if (product.AvailableQuantity < saleItem.Quantity)
                    {
                        throw new CustomException(HttpStatusCode.NotAcceptable, Constants.InvalidProductQuantity);
                    }
                    product.AvailableQuantity -= saleItem.Quantity;
                    SaleProduct saleProduct = new SaleProduct
                    {
                        InvoiceNumber = sale.InvoiceNumber.ToString(),
                        ProductId = saleItem.ProductId,
                        Quantity = saleItem.Quantity
                    };
                    _unitOfWork.SaleProductRepository.Insert(saleProduct);
                }
                _unitOfWork.SaleRepository.Insert(sale);
                _unitOfWork.Commit(); 
            }
        }
    }
}
