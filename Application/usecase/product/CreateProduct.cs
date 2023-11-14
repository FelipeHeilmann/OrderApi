using Application.dto;
using Application.repository;
using Domain.product.entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecase.product
{
    
    public class CreateProduct
    {
        private readonly ProductRepository _repository;
        public CreateProduct(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Execute(ProductDTO productDTO)
        {
            var product = Product.Create(productDTO.Name, productDTO.Description, productDTO.ImagePath, productDTO.Price);

            await _repository.Save(product);

            return product;
        }
    }
}
