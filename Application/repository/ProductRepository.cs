using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.product.entity;

namespace Application.repository
{
    public interface ProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task<Product> Get(Guid id);
        public Task Save(Product product);
        public Task Update(Product product);
        public Task<bool> Delete(Product product);

    }
}
