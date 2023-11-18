using Application.repository;
using Domain.order.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.usecase.order
{
    public class GetAllOrders
    {
        private readonly OrderRepository _repository;
        public GetAllOrders(OrderRepository repository) => _repository = repository;

        public async Task<List<Order>> Execute()
        {
            var products = await _repository.GetAll();

            return products;
        }
    }
}
