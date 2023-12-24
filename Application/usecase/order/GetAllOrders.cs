using Application.dto;
using Application.repository;
using Domain.order.entity;
using System;
using System.Collections;
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

        public async Task<ICollection<OrderResponse>> Execute()
        {
            var orders = await _repository.GetAll();

            var ordersResponse = (ICollection<OrderResponse>)orders.Select(order => new OrderResponse(order.Id,order.Total,order.Status, order.Products.Select(product => new OrderProductResponse(product.ProductId, product.Product.Name, product.Product.Description, product.Product.Price, product.Product.ImagePath, product.Quantity)).ToList()));

            return ordersResponse;
        }
    }
}
