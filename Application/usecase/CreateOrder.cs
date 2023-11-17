using Application.dto;
using Application.repository;
using Domain.order.entitiy;
using Domain.order.entity;
using Domain.product.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.usecase
{
    public class CreateOrder
    {
        private readonly OrderRepository _repository;
        private readonly ProductRepository _productRepository;

        public CreateOrder(OrderRepository repository, ProductRepository productRepository) {
            _productRepository = productRepository;
            _repository = repository;
        }

        public async Task<Order> Execute(List<OrderProductDTO> request)
        {

            var order = Order.Create();

            foreach (var orderProduct in request)
            {
                var product = await _productRepository.Get(orderProduct.ProductId);
                order.AddItem(OrderProduct.Create(order.Id, product.Id, product, orderProduct.Quantity));
            }

            await _repository.Save(order);

            return order;
        }

    }
}
