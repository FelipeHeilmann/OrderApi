using Application.repository;
using Domain.product.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecase.product
{
    public class DeleteProduct
    {
        private readonly ProductRepository _repository;

        public DeleteProduct(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Execute(Guid id)
        {
            var product = await _repository.Get(id);

            var success = await _repository.Delete(product);

            return success;
        }
    }
}
