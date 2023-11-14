using Application.repository;
using Domain.product.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecase.product
{
    public class GetProductById
    {
        private readonly ProductRepository _repository;
        public GetProductById(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Execute(Guid id)
        {
            var product = await _repository.Get(id);

            return product;
        }
    }
}
