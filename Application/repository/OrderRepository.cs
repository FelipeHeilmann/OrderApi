using Domain.order.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.repository
{
    public interface OrderRepository
    {
        public Task<List<Order>> GetAll();
        public Task<Order> Get(Guid id);
        public Task Save(Order order);
        public Task Update(Order order);
        public Task Delete(Guid id);
    }
}
