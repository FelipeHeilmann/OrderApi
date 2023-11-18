using Application.repository;
using Domain.order.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecase.order
{
    public class GetOrderById
    {
        private readonly OrderRepository _repository;

        public GetOrderById(OrderRepository repository) => _repository = repository;

        public async Task<Order> Execute(Guid id) 
        {
            return await _repository.Get(id);

        }
    }
}
