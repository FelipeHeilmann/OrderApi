using Application.dto;
using Application.usecase.order;
using Application.usecase.product;
using Domain.order.entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly CreateOrder _create;
        private readonly GetAllOrders _getAll;

        public OrderController(CreateOrder create, GetAllOrders getAll) {
            _create = create;
            _getAll = getAll;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            var orders = await _getAll.Execute();

            return Ok(orders);
        }

        
        [HttpPost]
        public async Task<ActionResult<Order>> Create(List<OrderProductDTO> products)
        {
            var product = await _create.Execute(products);

            return Ok(product);
        }

    }
}
