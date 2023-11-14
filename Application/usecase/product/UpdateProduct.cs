using Application.dto;
using Application.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecase.product
{
    public class UpdateProduct
    {
        private readonly ProductRepository _repository;
        
        public UpdateProduct(ProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Execute(ProductDTO request, Guid id)
        {
            var product = await _repository.Get(id);

            product.Update(request.Description, request.ImagePath, request.Name, request.Price);

            await _repository.Update(product);
        }
    }
}
