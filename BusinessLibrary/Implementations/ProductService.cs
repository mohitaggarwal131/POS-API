using AutoMapper;
using BusinessLayer.Interface;
using DataTransferObject;
using Entities;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using Utility;
using Utility.CustomException;

namespace BusinessLayer.Implementations
{
    public class ProductService : IProductService
    {
        #region Private Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="unitOfWork">Object of UnitOfWork</param>
        /// <param name ="mapper">Object of AutoMapper</param>
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion

        /// <summary>
        /// Retrieves list of products for a store
        /// </summary>
        /// <returns>List of Products</returns>
        public IEnumerable<Product> GetAll()
        {
            var products =_unitOfWork.ProductRepository.GetAll();
            return products;
        }

        /// <summary>
        /// Creates a product for a store
        /// </summary>
        /// <param name="productDto">CreateProductDto</param>
        public void Create(CreateProductDto productDto)
        {
            Product product = new Product()
            {
                Guid = Guid.NewGuid(),
                Name = productDto.Name,
                UnitPrice = productDto.UnitPrice,
                AvailableQuantity = productDto.AvailableQuantity,
                Image = productDto.Image
            };
            var category = _unitOfWork.CategoryRepository.GetById(productDto.CategoryId) ?? throw new CustomException(HttpStatusCode.NotFound, Constants.ErrorCategoryNotFound);
            product.CategoryId = category.Id;
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Edit Product details
        /// </summary>
        /// <param name="productDto">EditProductDto</param>
        public ProductDto Edit(EditProductDto productDto)
        {
            var product = _unitOfWork.ProductRepository.GetById(productDto.Id) ?? throw new CustomException(HttpStatusCode.NotFound, Constants.ErrorProductNotFound);
            var category = _unitOfWork.CategoryRepository.GetById(productDto.CategoryId) ?? throw new CustomException(HttpStatusCode.NotFound, Constants.ErrorCategoryNotFound);
            product.CategoryId = category.Id;
            product.Name = productDto.Name;
            product.UnitPrice = productDto.UnitPrice;
            product.AvailableQuantity = productDto.AvailableQuantity;
            product.Image = productDto.Image;
            _unitOfWork.Commit();
            return _mapper.Map<ProductDto>(product);
        }

        /// <summary>
        /// Delete products from a store 
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
            var product = _unitOfWork.ProductRepository.GetById(id) ?? throw new CustomException(HttpStatusCode.NotFound, Constants.ErrorProductNotFound);
            _unitOfWork.ProductRepository.Delete(product.Id);
            _unitOfWork.Commit();
        }
    }
}
