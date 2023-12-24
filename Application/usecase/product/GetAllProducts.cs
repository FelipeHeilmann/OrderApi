using Application.repository;
using Domain.product.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecase.product
{
    public class GetAllProducts
    {
        private readonly ProductRepository _repository;
        public GetAllProducts(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Product>> Execute()
        {
            var products = await _repository.GetAll();


            return products;
        }
    }
}
